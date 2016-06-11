using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Plum.ViewModels.Customer;
using Plum.Services;

namespace Plum.Controllers
{
    public partial class CustomerController : AppControllerBase
    {
        protected async Task<Models.Customer> Customer()
        {
            return await Entity<Models.Customer>(
                customer => customer.Include(x => x.Queue).Include(x => x.Queue.Business).Include(x => x.Queue.Customers),
                customer => Security.UserOwns(customer));
        }

        [Authorize]
        [HttpGet, Route("customer/{id:int}")]
        public virtual async Task<ActionResult> Show(int id)
        {
            var customer = await Customer();

            if (customer == null)
            {
                ErrorMessage("We were unabled to find that customer.", "Maybe they've been removed from the list?");
                return JavaScriptRedirect(Url.Action(MVC.Queue.Show(null)));
            }
            else if (!Security.UserOwns(customer))
            {
                return NotAuthorized();
            }

            var model = new CustomerViewModel();
            model.CopyFrom(customer);

            return View(model);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost, Route("customer/create")]
        public virtual async Task<ActionResult> Create(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var queue = await Database.Queues.FindAsync(model.QueueId);

            if (!Security.UserOwns(queue))
            {
                return NotAuthorized();
            }

            var customer = new Plum.Models.Customer();
            model.CopyTo(customer);

            customer.Log(Models.CustomerLogEntryType.AddedToList, "Party added to wait list.");
            customer.SortOrder = queue.Customers.OrderBy(x => x.SortOrder).Select(x => x.SortOrder).LastOrDefault();
            customer.SortOrder++;

            var profanityFilter = new ProfanityFilter(Server.MapPath("~/App_Data/Profanity.txt"));
            customer.GenerateUrlToken(Database, profanityFilter);

            await queue.AddCustomerAsync(customer, TextMessaging, Url);
            await Database.SaveChangesAsync();
            await UpdateHub.BroadcastQueueUpdateToCustomers(queue.Id);
            await UpdateHub.BroadcastQueueUpdateToBusiness(queue.Id);

            string url = Url.Action(MVC.Queue.Show(queue.Id));
            return JavaScriptRedirect(url);
        }

        [Authorize]
        [HttpGet, Route("customer/{id:int}/edit")]
        public virtual async Task<ActionResult> Edit(int id)
        {
            var customer = await Customer();
            if (_result != null) return _result;

            var model = new CustomerViewModel();
            model.CopyFrom(customer);

            return View(model);
        }
               
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPut, Route("customer/{id:int}")]
        public virtual async Task<ActionResult> Update(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customer = await Customer();
            if (_result != null) return _result;

            var queue = await Database.Queues.FindAsync(model.QueueId);
            if (!Security.UserOwns(queue))
            {
                return NotAuthorized();
            }

            string oldPhoneNumber = customer.PhoneNumber;
            model.CopyTo(customer);
            await Database.SaveChangesAsync();
            await UpdateHub.BroadcastQueueUpdateToBusiness(customer.QueueId);
            await UpdateHub.BroadcastQueueUpdateToCustomers(customer.QueueId);

            if (oldPhoneNumber != customer.PhoneNumber && customer.HasPhoneNumber())
            {
                await customer.SendWelcomeTextMessageAsync(TextMessaging, Url);
                await Database.SaveChangesAsync();
            }

            return RedirectToAction(MVC.Customer.Show(customer.Id));
        }

        [ValidateAntiForgeryToken]
        [HttpDelete, Route("customer/{urlToken:length(8)}")]
        public virtual async Task<ActionResult> DestroyWithUrlToken(string urlToken)
        {
            var customer = await Database.Customers
                .FirstOrDefaultAsync(x => x.UrlToken == urlToken);

            if (customer != null)
            {
                int queueId = customer.QueueId;
                Database.Customers.Remove(customer);
                await Database.SaveChangesAsync();
                TempData["CustomerRemovedSelf"] = true;
                await UpdateHub.BroadcastQueueUpdateToCustomers(queueId);
                await UpdateHub.BroadcastQueueUpdateToBusiness(queueId);
            }

            return RedirectToAction(MVC.Home.RemovedFromList());
        }

        [ValidateAntiForgeryToken]
        [HttpDelete, Route("customer/{id:int}")]
        public virtual async Task<ActionResult> Destroy(int id)
        {
            var customer = await Customer();

            if (customer != null && Security.UserOwns(customer))
            {
                int queueId = customer.Queue.Id;
                Database.Customers.Remove(customer);
                await Database.SaveChangesAsync();
                await UpdateHub.BroadcastQueueUpdateToCustomers(queueId);
                await UpdateHub.BroadcastQueueUpdateToBusiness(queueId);
                return RedirectToAction(MVC.Queue.Show(queueId));
            }

            return RedirectToAction(MVC.Business.Show(AppSession.BusinessId.Value));
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost, Route("customer/{id:int}/send-ready-message")]
        public virtual async Task<ActionResult> SendReadyMessage(int id)
        {
            var customer = await Customer();
            if (_result != null) return _result;

            int queueId = customer.Queue.Id;
            await customer.SendReadyTextMessageAsync(TextMessaging, Url);
            await Database.SaveChangesAsync();

            var model = new CustomerViewModel();
            model.CopyFrom(customer);
            return View(MVC.Customer.Views.Show, model);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost, Route("customer/{id:int}/move-to-end-of-list")]
        public virtual async Task<ActionResult> MoveToEndOfList(int id)
        {
            var customer = await Customer();
            if (_result != null) return _result;

            int queueId = customer.Queue.Id;
            customer.Queue.MoveCustomerToEndOfList(customer);
            await Database.SaveChangesAsync();
            await UpdateHub.BroadcastQueueUpdateToCustomers(queueId);
            await UpdateHub.BroadcastQueueUpdateToBusiness(queueId);

            var model = new CustomerViewModel();
            model.CopyFrom(customer);
            return View(MVC.Customer.Views.Show, model);
        }
    }
}