using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plum.ViewModels.Business
{
    public class ShowViewModel
    {
        public int QueueId { get; set; }
        public BusinessInformationViewModel BusinessInformation { get; set; }
        public SignInInformationViewModel SignInInformation { get; set; }
        public TextMessagesViewModel TextMessages { get; set; }

        public void CopyFrom(Models.Business business)
        {
            QueueId = business.Queues.First().Id;

            BusinessInformation = new BusinessInformationViewModel();
            BusinessInformation.CopyFrom(business);

            SignInInformation = new SignInInformationViewModel();
            SignInInformation.CopyFrom(business);

            TextMessages = new TextMessagesViewModel();
            TextMessages.CopyFrom(business);
        }
    }
}