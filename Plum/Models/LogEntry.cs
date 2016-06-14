using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plum.Models
{
    public class LogEntry
    {
        public int Id { get; set; }
        public DateTime Logged { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public string ServerName { get; set; }
        public string Port { get; set; }
        public string Url { get; set; }
        public bool? Https { get; set; }
        public string ServerAddress { get; set; }
        public string RemoteAddress { get; set; }
        public string Logger { get; set; }
        public string CallSite { get; set; }
    }
}