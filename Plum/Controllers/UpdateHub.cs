using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Plum.Models;
using System.Data.Entity;
using Plum.Web;

namespace Plum.Controllers
{
    public class UpdateHub : Hub
    {
        private AppDataContext _db;
        private AppSecurity _security;

        public UpdateHub()
        {
            _db = new AppDataContext();
            _security = new AppSecurity(new AppSession(HttpContext2.Current));
        }

        public async Task SubscribeToQueueAsCustomer(string urlToken)
        {
            int? queueId = await _db.Customers
                .Where(x => x.UrlToken == urlToken)
                .Select(x => x.QueueId).FirstOrDefaultAsync();

            if (queueId.HasValue)
            {
                string groupName = $"Queue-{queueId}-Customers";
                await Groups.Add(Context.ConnectionId, groupName);
            }
        }

        public static async Task BroadcastQueueUpdateToCustomers(int queueId)
        {
            var updateHub = GlobalHost.ConnectionManager.GetHubContext<UpdateHub>();
            string groupName = $"Queue-{queueId}-Customers";
            await updateHub.Clients.Group(groupName).queueUpdated();
        }

        public async Task SubscribeToQueueAsBusiness(int queueId)
        {
            var queue = await _db.Queues
                .Include(x => x.Business)
                .FirstOrDefaultAsync(x => x.Id == queueId);

            if (queue != null && _security.UserOwns(queue))
            {
                string groupName = $"Queue-{queueId}-Business";
                await Groups.Add(Context.ConnectionId, groupName);
            }
        }

        public static async Task BroadcastQueueUpdateToBusiness(int queueId, int? customerId = null)
        {
            var updateHub = GlobalHost.ConnectionManager.GetHubContext<UpdateHub>();
            string groupName = $"Queue-{queueId}-Business";
            await updateHub.Clients.Group(groupName).queueUpdated(customerId);
        }

        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
            base.Dispose(disposing);
        }
    }
}