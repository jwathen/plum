using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Plum.Models;
using System.Data.Entity;

namespace Plum.Controllers
{
    public class UpdateHub : Hub
    {
        private AppDataContext _db = new AppDataContext();

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

        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
            base.Dispose(disposing);
        }
    }
}