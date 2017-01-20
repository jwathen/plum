using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WaitlistApp.Models.Annotations;

namespace WaitlistApp.Models
{
    public class CustomerLogEntry : IDatedEntity
    {
        public virtual int Id { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        public virtual DateTime? DateRead { get; set; }
        public virtual string Message { get; set; }
        public virtual CustomerLogEntryType Type { get; set; }

        public TimeSpan Age()
        {
            var age = DateTime.UtcNow.Subtract(DateCreated);
            if (age < TimeSpan.FromSeconds(1))
            {
                age = TimeSpan.FromSeconds(1);
            }

            return age;
        }

        public string Icon()
        {
            switch (Type)
            {
                case CustomerLogEntryType.ReadyTextMessageSent:
                case CustomerLogEntryType.WelcomeTextMessageSent:
                case CustomerLogEntryType.MessageReceivedFromCustomer:
                case CustomerLogEntryType.CustomTextMessageSent:
                    return "fa-comment";
                case CustomerLogEntryType.CancelMessageReceivedFromCustomer:
                    return "fa-ban";
                case CustomerLogEntryType.OnMyWayMessageReceivedFromCustomer:
                    return "fa-check";
                default:
                    return "fa-clock-o";
            }
        }
    }
}