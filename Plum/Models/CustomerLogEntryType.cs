using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plum.Models
{
    public enum CustomerLogEntryType
    {
        AddedToList = 1,        
        ReadyTextMessageSent = 2,
        MovedToEndOfList = 3,
        NameChanged = 4,
        NumberInPartyChanged = 5,
        PhoneNumberChanged = 6,
        WelcomeTextMessageSent = 7,
        MessageReceivedFromCustomer = 8,
        OnMyWayMessageReceivedFromCustomer = 9,
        NeedAFewMinutesMessageReceivedFromCustomer = 10,
        CancelMessageReceivedFromCustomer = 11,
    }
}