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
        protected async Task<Models.Queue> Queue()
        {
            var routeValues = ControllerContext.RouteData.Values;
            if (routeValues["id"] != null)
            {
                int id = Convert.ToInt32(routeValues["id"]);
                var queue = await Database.Queues
                    .Include(x => x.Business)
                    .FirstOrDefaultAsync(x => x.Id == id);
                return queue;
            }

            return null;
        }

        [GET("/q/{urlToken:length(8)}")]
        public virtual async Task<ActionResult> ShowCustomer(string urlToken)
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

        [GET("/queue/{urlToken:length(8)}/customer_view_queue_list")]
        public virtual async Task<ActionResult> CustomerViewQueueList(string urlToken)
        {
            var customer = await Database.Customers
                .Include(x => x.Queue)
                .Include(x => x.Queue.Business)
                .Include(x => x.Queue.Customers)
                .FirstOrDefaultAsync(x => x.UrlToken == urlToken);

            if (customer == null)
            {
                return JavaScriptRedirect(Url.Action(MVC.Queue.ShowCustomer(urlToken)));
            }

            return View(customer);
        }

        [Authorize]
        [GET("/queue/{id:int}")]
        public virtual async Task<ActionResult> Show(int id)
        {
            var queue = await Queue();

            if (queue == null)
            {
                return HttpNotFound();
            }
            else if (!Security.UserOwns(queue))
            {
                return NotAuthorized();
            }

            return View(queue);
        }

        [Authorize]
        [GET("/queue/{id:int}/business_view_queue_list")]
        public virtual async Task<ActionResult> BusinessViewQueueList(int queueId)
        {
            var queue = await Queue();

            if (queue == null)
            {
                return HttpNotFound();
            }
            else if (!Security.UserOwns(queue))
            {
                return NotAuthorized();
            }

            return View(queue);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [POST("/queue/{id:int}/sort")]
        public virtual async Task<ActionResult> Sort(int id, int[] customerIds)
        {
            if (customerIds != null && customerIds.Any())
            {
                var customers = await Database.Customers
                    .Include(x => x.Queue)
                    .Include(x => x.Queue.Business)
                    .Where(x => x.QueueId == id && customerIds.Contains(x.Id))
                    .ToListAsync();

                if (customers.All(x => Security.UserOwns(x)))
                {
                    short sortOrder = 1;
                    foreach (int customerId in customerIds)
                    {
                        var customer = customers.FirstOrDefault(x => x.Id == customerId);
                        if (customer != null)
                        {
                            customer.SortOrder = sortOrder;
                            sortOrder++;
                        }
                    }

                    await Database.SaveChangesAsync();
                    await UpdateHub.BroadcastQueueUpdateToCustomers(id);
                }
            }

            return Json(true);
        }
    }
}