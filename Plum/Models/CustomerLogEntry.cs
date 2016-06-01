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
            return "fa-clock-o";

            switch (Type)
            {
                case CustomerLogEntryType.AddedToList:
                    return "fa-plus";
                case CustomerLogEntryType.ReadyTextMessageSent:
                    return "fa-comment";
                case CustomerLogEntryType.MovedToEndOfList:
                    return "fa-arrow-down";
                case CustomerLogEntryType.NameChanged:
                    return "fa-person";
                case CustomerLogEntryType.NumberInPartyChanged:
                    return "fa-person";
                case CustomerLogEntryType.PhoneNumberChanged:
                    return "fa-person";
                default:
                    return "fa-clock-o";
            }
        }
    }
}