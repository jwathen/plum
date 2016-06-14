using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Plum.ViewModels.Sms;
using System.Data.Entity;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Plum.Controllers
{
    public partial class PlivoController : AppControllerBase
    {
        [HttpPost]
        public virtual async Task<ActionResult> IncomingSms(SmsMessage message)
        {
            Log.Info(JsonConvert.SerializeObject(message));
            if (message.From.Length > 10)
            {
                message.From = message.From.Substring(1);
            }

            var customer = await Database.Customers.Where(x => x.PhoneNumber == message.From)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();
            if (customer != null)
            {
                customer.Log(Models.CustomerLogEntryType.MessageReceivedFromCustomer, $"{customer.Name} - \"{message.Text}\"");
                await Database.SaveChangesAsync();
                await UpdateHub.BroadcastQueueUpdateToBusiness(customer.QueueId);
            }

            return new HttpStatusCodeResult(200);
        }
    }
}