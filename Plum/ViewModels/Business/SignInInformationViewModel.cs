using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plum.ViewModels.Business
{
    public class SignInInformationViewModel
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }

        public void CopyFrom(Models.Business business)
        {
            Id = business.Id;
            EmailAddress = business.Account.EmailAddress;
        }
    }
}