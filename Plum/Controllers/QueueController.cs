using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using System.Data.Entity;
using Plum.ViewModels.Customer;
using Plum.Services;

namespace Plum.Controllers
{
    public partial class QueueController : AppControllerBase
    {
        [GET("/q/{urlToken}")]
        public virtual async Task<ActionResult> CustomerView(string urlToken)
        {
            var customer = await Database.Customers
                .Include(x => x.Queue)
                .Include(x => x.Queue.Business)
                .Include(x => x.Queue.Customers)
                .FirstOrDefaultAsync(x => x.UrlToken == urlToken);

            if (customer == null)
            {
                return View(MVC.Queue.Views.CustomerNotFound);
            }

            return View(customer);
        }

        [ValidateAntiForgeryToken]
        [POST("/queue/cancel")]
        public virtual async Task<ActionResult> CancelPlaceInLine(string urlToken)
        {
            var customer = await Database.Customers.FirstOrDefaultAsync(x => x.UrlToken == urlToken);

            if (customer != null)
            {
                Database.Customers.Remove(customer);
                await Database.SaveChangesAsync();
            }

            return RedirectToAction(MVC.Home.Index());
        }

        [Authorize]
        [GET("/queue/{queueId:int?}")]
        public virtual async Task<ActionResult> Manage(int? queueId)
        {
            Plum.Models.Queue model = null;
            if (queueId.HasValue)
            {
                model = await Database.Queues
                    .Include(x => x.Business)
                    .Include(x => x.Customers)
                    .FirstOrDefaultAsync(x => x.Id == queueId.Value);
            }
            else
            {
                int businessId = AppSession.BusinessId.Value;
                queueId = await Database.Queues
                    .Where(x => x.BusinessId == businessId)
                    .Select(x => x.Id)
                    .FirstAsync();
                return RedirectToAction(MVC.Queue.Manage(queueId));
            }

            if (model == null)
            {
                return HttpNotFound();
            }
            else if (!Security.UserOwns(model))
            {
                return RedirectToAction(MVC.Home.NotAuthorized());
            }

            return View(model);
        }

        [Authorize]
        [GET("/queue/manage_customer_modal")]
        public virtual async Task<ActionResult> ManageCustomerModal(int customerId)
        {
            var customer = await Database.Customers
                .Include(x => x.LogEntries)
                .Include(x => x.Queue)
                .Include(x => x.Queue.Business)
                .Include(x => x.Queue.Customers)
                .FirstOrDefaultAsync(x => x.Id == customerId);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else if (!Security.UserOwns(customer))
            {
                return RedirectToAction(MVC.Home.NotAuthorized());
            }

            return View(customer);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [POST("/queue/remove_customer")]
        public virtual async Task<ActionResult> RemoveCustomer(int customerId)
        {
            var customer = await Database.Customers
                .Include(x => x.Queue)
                .Include(x => x.Queue.Business)
                .FirstOrDefaultAsync(x => x.Id == customerId);

            if (customer != null && Security.UserOwns(customer))
            {
                int queueId = customer.Queue.Id;
                Database.Customers.Remove(customer);
                await Database.SaveChangesAsync();
                return JavaScript($"window.location.href = '{Url.Action(MVC.Queue.Manage(queueId))}';");
            }

            return RedirectToAction(MVC.Queue.Manage());
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [POST("/queue/add_customer")]
        public virtual async Task<ActionResult> AddCustomer(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var queue = await Database.Queues.FindAsync(model.QueueId);
            
            if (!Security.UserOwns(queue))
            {
                return RedirectToAction(MVC.Home.NotAuthorized());
            }

            var customer = new Plum.Models.Customer();
            customer.Name = model.Name;
            customer.NumberInParty = model.NumberInParty;
            if (!string.IsNullOrWhiteSpace(model.PhoneNumber))
            {
                customer.PhoneNumber = new string(model.PhoneNumber.Where(x => char.IsDigit(x)).ToArray());
            }
            customer.DateAdded = DateTime.UtcNow;
            customer.Log(Models.CustomerLogEntryType.AddedToList, "Party added to wait list.");
            customer.SortOrder = queue.Customers.OrderBy(x => x.SortOrder).Select(x => x.SortOrder).LastOrDefault();
            customer.SortOrder++;

            var profanityFilter = new ProfanityFilter(Server.MapPath("~/App_Data/Profanity.txt"));
            customer.GenerateUrlToken(Database, profanityFilter);

            queue.AddCustomer(customer, Url, Secrets);
            await Database.SaveChangesAsync();

            return RedirectToAction(MVC.Queue.Manage(queue.Id));
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [POST("/queue/send_ready_message")]
        public virtual async Task<ActionResult> SendReadyTextMessage(int customerId)
        {
            var customer = await Database.Customers
                .Include(x => x.Queue)
                .Include(x => x.Queue.Business)
                .Include(x => x.Queue.Customers)
                .FirstOrDefaultAsync(x => x.Id == customerId);

            if (customer != null && Security.UserOwns(customer))
            {
                int queueId = customer.Queue.Id;
                customer.SendReadyTextMessage(Url, Secrets);
                await Database.SaveChangesAsync();
                return View(MVC.Queue.Views.ManageCustomerModal, customer);
            }

            return RedirectToAction(MVC.Queue.Manage());
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [POST("/queue/move_to_end_of_list")]
        public virtual async Task<ActionResult> MoveToEndOfList(int customerId)
        {
            var customer = await Database.Customers
                .Include(x => x.Queue)
                .Include(x => x.Queue.Business)
                .Include(x => x.Queue.Customers)
                .FirstOrDefaultAsync(x => x.Id == customerId);

            if (customer != null && Security.UserOwns(customer))
            {
                int queueId = customer.Queue.Id;
                customer.Queue.MoveCustomerToEndOfList(customer);
                await Database.SaveChangesAsync();
                return View(MVC.Queue.Views.ManageCustomerModal, customer);
            }

            return RedirectToAction(MVC.Queue.Manage());
        }
    }
}