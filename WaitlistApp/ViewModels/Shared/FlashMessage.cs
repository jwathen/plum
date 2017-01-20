using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaitlistApp.ViewModels.Shared
{
    public class FlashMessage
    {
        public enum AlertType
        {
            Success,
            Danger
        }

        public string Text { get; set; }
        public string MinorText { get; set; }
        public AlertType Type { get; set; }
    }
}