using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaitlistApp.Services;
using WaitlistApp.Tests.TestHelpers;
using Should;

namespace WaitlistApp.Tests.Unit.Services
{
    public class TextMessageTemplateServiceTests : TestBase
    {
        TextMessageTemplateService _templateService = new TextMessageTemplateService();

        public void BuildWelcomeMessage_BuildsDefaultMessage()
        {
            string message = _templateService.BuildWelcomeMessage(OtherBusiness, TextMessageTemplateService.SAMPLE_PLACE_IN_LINE_URL);

            string expected = "Hey it's Other Business! You've been added to our wait list. You can see your place in line at https://waitlistapp.com/q/4l3oj6ny";

            message.ShouldEqual(expected);
        }

        public void BuildReadyMessage_BuildsDefaultMessage()
        {
            string message = _templateService.BuildReadyMessage(OtherBusiness);

            string expected = "It's Other Business. We're ready for you. Respond 1, 2, or 3. 1 = I'm on my way. 2 = I need a few minutes but I'm still coming. 3 = I'd like to cancel.";

            message.ShouldEqual(expected);
        }

        public void BuildWelcomeMessage_BuildsCustomMessage()
        {
            string message = _templateService.BuildWelcomeMessage(TestBusiness, TextMessageTemplateService.SAMPLE_PLACE_IN_LINE_URL);

            string expected = "Yo it's Test Business. https://waitlistapp.com/q/4l3oj6ny";

            message.ShouldEqual(expected);
        }

        public void BuildReadyMessage_BuildsCustomMessage()
        {
            string message = _templateService.BuildReadyMessage(TestBusiness);

            string expected = "Yo it's Test Business. You're up.";

            message.ShouldEqual(expected);
        }
    }
}
