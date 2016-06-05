using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plum.Models
{
    public class CustomerLogEntry : IDatedEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        public string Message { get; set; }
        public CustomerLogEntryType Type { get; set; }

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
                default:
                    return "fa-clock-o";
            }
        }
    }
}