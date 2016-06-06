using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plum.Lib.Services
{
    public class TextMessageTemplateService
    {
        public static readonly string SAMPLE_PLACE_IN_LINE_URL = "https://plumlist.com/q/4l3oj6ny";

        public string BuildWelcomeMessage(Models.Business business, string placeInLineUrl)
        {
            if (!string.IsNullOrWhiteSpace(business.WelcomeTextMessage))
            {
                return business.WelcomeTextMessage + " " + placeInLineUrl;
            }
            else
            {
                return $"Hey it's {business.Name}! You've been added to our wait list. You can see your place in line at {placeInLineUrl}";
            }
        }

        public string BuildReadyMessage(Models.Business business)
        {
            if (!string.IsNullOrWhiteSpace(business.ReadyTextMessage))
            {
                return business.ReadyTextMessage;
            }
            else
            {
                return $"It's {business.Name}. We're ready for you.";
            }
        }
    }
}