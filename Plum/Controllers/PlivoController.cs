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
                message.Text = (message.Text ?? string.Empty).Trim();
                if (message.Text == "1")
                {
                    customer.Log(Models.CustomerLogEntryType.OnMyWayMessageReceivedFromCustomer, "Party is on their way.");
                }
                else if (message.Text == "2")
                {
                    customer.Log(Models.CustomerLogEntryType.NeedAFewMinutesMessageReceivedFromCustomer, "Party needs a few minutes.");
                }
                else if (message.Text == "3")
                {
                    customer.Log(Models.CustomerLogEntryType.CancelMessageReceivedFromCustomer, "Party would like to cancel.");
                }
                else
                {
                    customer.Log(Models.CustomerLogEntryType.MessageReceivedFromCustomer, $"{customer.Name} - \"{message.Text}\"");
                }
                await Database.SaveChangesAsync();
                await UpdateHub.BroadcastQueueUpdateToBusiness(customer.QueueId, customer.Id);
            }

            return new HttpStatusCodeResult(200);
        }
    }
}