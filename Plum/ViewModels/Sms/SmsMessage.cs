using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plum.ViewModels.Sms
{
    public class SmsMessage
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
    }
}