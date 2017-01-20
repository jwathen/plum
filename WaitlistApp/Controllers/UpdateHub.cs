using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using WaitlistApp.Models;
using System.Data.Entity;
using WaitlistApp.Web;

namespace WaitlistApp.Controllers
{
    public class UpdateHub : Hub
    {
        private AppDataContext _db;
        private AppSecurity _security;

        private AppSecurity Security
        {
            get
            {
                if (_security == null)
                {
                    _security = new AppSecurity(new AppSession(Context.Request.GetHttpContext()));
                }
                return _security;
            }
        }

        public UpdateHub()
        {
            _db = new AppDataContext();
        }

        public async Task SubscribeToQueueAsCustomer(string urlToken)
        {
            int? queueId = await _db.Customers
                .Where(x => x.UrlToken == urlToken)
                .Select(x => x.QueueId).FirstOrDefaultAsync();

            if (queueId.HasValue)
            {
                string groupName = $"Queue-{queueId}-Customers";
                if (MvcApplication.IS_TEST)
                {
                    return;
                }
                await Groups.Add(Context.ConnectionId, groupName);
            }
        }

        public static async Task BroadcastQueueUpdateToCustomers(int queueId)
        {
            if (MvcApplication.IS_TEST)
            {
                return;
            }

            string groupName = $"Queue-{queueId}-Customers";
            var updateHub = GlobalHost.ConnectionManager.GetHubContext<UpdateHub>();
            await updateHub.Clients.Group(groupName).queueUpdated();
        }

        public async Task SubscribeToQueueAsBusiness(int queueId)
        {
            var queue = await _db.Queues
                .Include(x => x.Business)
                .FirstOrDefaultAsync(x => x.Id == queueId);
            if (MvcApplication.IS_TEST)
            {
                return;
            }

            if (queue != null && Security.UserOwns(queue))
            {
                string groupName = $"Queue-{queueId}-Business";
                await Groups.Add(Context.ConnectionId, groupName);
            }
        }

        public static async Task BroadcastQueueUpdateToBusiness(int queueId, int? customerId = null)
        {
            if (MvcApplication.IS_TEST)
            {
                return;
            }

            string groupName = $"Queue-{queueId}-Business";
            var updateHub = GlobalHost.ConnectionManager.GetHubContext<UpdateHub>();
            await updateHub.Clients.Group(groupName).queueUpdated(customerId);
        }

        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
            base.Dispose(disposing);
        }
    }
}