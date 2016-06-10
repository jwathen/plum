using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Plum.Models.Annotations;
using Plum.Services;

namespace Plum.Models
{
    public class Business : IDatedEntity, IIntegerIdEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string WelcomeTextMessage { get; set; }
        public string ReadyTextMessage { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        public virtual Account Account { get; set; }

        public virtual HashSet<Queue> Queues { get; set; } = new HashSet<Queue>();

        public string SampleWelcomeTextMessage()
        {
            var templateService = new TextMessageTemplateService();
            return templateService.BuildWelcomeMessage(this, TextMessageTemplateService.SAMPLE_PLACE_IN_LINE_URL);
        }

        public string SampleReadyTextMessage()
        {
            var templateService = new TextMessageTemplateService();
            return templateService.BuildReadyMessage(this);
        }

        public bool HasPhoneNumber()
        {
            return !string.IsNullOrEmpty(PhoneNumber);
        }
    }
}