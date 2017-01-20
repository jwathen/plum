using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaitlistApp.ViewModels.Queue
{
    public class ManageCustomerViewModel
    {
        public int CustomerId { get; set; }
        public ManageCustomerCommand Command { get; set; }
    }

    public enum ManageCustomerCommand
    {
        SendReadyTextMessage,
        RemoveFromList,
        MoveToEndOfList
    }
}