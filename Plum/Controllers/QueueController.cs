using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using System.Data.Entity;
using Plum.ViewModels.Customer;

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
                return HttpNotFound();
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

            if (model == null)
            {
                model = new Models.Queue();
                model.BusinessId = AppSession.BusinessId.Value;
                Database.Queues.Add(model);
                await Database.SaveChangesAsync();
                return RedirectToAction(MVC.Queue.Manage(model.Id));
            }

            return View(model);
        }

        [GET("/queue/manage_customer_modal")]
        public virtual async Task<ActionResult> ManageCustomerModal(int customerId)
        {
            var customer = await Database.Customers
                .Include(x => x.LogEntries)
                .FirstOrDefaultAsync(x => x.Id == customerId);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        [ValidateAntiForgeryToken]
        [POST("/queue/remove_customer")]
        public virtual async Task<ActionResult> RemoveCustomer(int customerId)
        {
            var customer = await Database.Customers
                .Include(x => x.Queue)
                .FirstOrDefaultAsync(x => x.Id == customerId);

            if (customer == null)
            {
                if (AppSession.BusinessId.HasValue)
                {
                    return RedirectToAction(MVC.Queue.Manage(AppSession.BusinessId.Value));
                }
                else
                {
                    return RedirectToAction(MVC.Home.Index());
                }
            }
            else
            {
                Database.Customers.Remove(customer);
                await Database.SaveChangesAsync();
                return RedirectToAction(MVC.Queue.Manage(customer.Queue.BusinessId));
            }
        }

        [ValidateAntiForgeryToken]
        [POST("/queue/add_customer")]
        public virtual async Task<ActionResult> AddCustomer(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var queue = await Database.Queues.FindAsync(model.QueueId);

            var customer = new Plum.Models.Customer();
            customer.Name = model.Name;
            customer.NumberInParty = model.NumberInParty;
            customer.PhoneNumber = new string(model.PhoneNumber.Where(x => char.IsDigit(x)).ToArray());
            customer.DateAdded = DateTime.UtcNow;
            customer.Log(Models.CustomerLogEntryType.AddedToList, "Party added to wait list.");
            customer.SortOrder = queue.Customers.OrderBy(x => x.SortOrder).Select(x => x.SortOrder).FirstOrDefault();
            customer.SortOrder++;
            customer.GenerateUrlToken(Database);
            queue.Customers.Add(customer);
            await Database.SaveChangesAsync();

            return RedirectToAction(MVC.Queue.Manage(queue.Id));
        }
    }
}