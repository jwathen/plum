using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WaitlistApp.Models;

namespace WaitlistApp.Web
{
    public class AppSecurity
    {
        private readonly AppSession _appSession;

        public AppSecurity(AppSession appSession)
        {
            _appSession = appSession;
        }

        public bool UserOwns(Business business)
        {
            return business.Id == _appSession.BusinessId;
        }

        public bool UserOwns(Queue queue)
        {
            return UserOwns(queue.Business);
        }

        public bool UserOwns(Customer customer)
        {
            return UserOwns(customer.Queue);
        }
    }
}