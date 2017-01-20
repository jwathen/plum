using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaitlistApp.Services
{
    public class TextMessageTemplateService
    {
        public static readonly string SAMPLE_PLACE_IN_LINE_URL = "https://waitlistapp.com/q/4l3oj6ny";

        public string BuildWelcomeMessage(Models.Business business, string placeInLineUrl)
        {
            if (!string.IsNullOrWhiteSpace(business.WelcomeTextMessage))
            {
                return business.WelcomeTextMessage.Trim() + " " + placeInLineUrl;
            }
            else
            {
                return GetDefaultWelcomeMessage(business).Trim() + " "  + placeInLineUrl;
            }
        }

        public string GetDefaultWelcomeMessage(Models.Business business)
        {
            return $"Hey it's {business.Name}! You've been added to our wait list. You can see your place in line at ";
        }

        public string BuildReadyMessage(Models.Business business)
        {
            if (!string.IsNullOrWhiteSpace(business.ReadyTextMessage))
            {
                return business.ReadyTextMessage;
            }
            else
            {
                return GetDefaultReadyMessage(business);
            }
        }

        public string GetDefaultReadyMessage(Models.Business business)
        {
            return $"It's {business.Name}. We're ready for you. Respond 1, 2, or 3. 1 = I'm on my way. 2 = I need a few minutes but I'm still coming. 3 = I'd like to cancel.";
        }
    }
}