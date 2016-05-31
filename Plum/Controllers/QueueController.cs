using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using System.Data.Entity;

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
    }
}