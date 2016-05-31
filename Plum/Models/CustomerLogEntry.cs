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
    }
}