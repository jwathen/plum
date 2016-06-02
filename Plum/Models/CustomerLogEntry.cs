using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plum.Models
{
    public class CustomerLogEntry
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateInserted { get; set; }
        public string Message { get; set; }
        public CustomerLogEntryType Type { get; set; }

        public TimeSpan Age()
        {
            return DateTime.UtcNow.Subtract(DateInserted);
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