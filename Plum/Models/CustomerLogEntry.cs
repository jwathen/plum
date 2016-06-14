using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Plum.Models.Annotations;

namespace Plum.Models
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
                    return "fa-comment";
                case CustomerLogEntryType.WelcomeTextMessageSent:
                    return "fa-comment";
                case CustomerLogEntryType.MessageReceivedFromCustomer:
                    return "fa-comment";
                default:
                    return "fa-clock-o";
            }
        }
    }
}