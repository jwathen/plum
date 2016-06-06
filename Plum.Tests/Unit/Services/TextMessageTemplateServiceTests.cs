using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plum.Services;
using Plum.Tests.TestHelpers;
using Should;

namespace Plum.Tests.Unit.Services
{
    public class TextMessageTemplateServiceTests : TestBase
    {
        TextMessageTemplateService _templateService = new TextMessageTemplateService();

        public void BuildWelcomeMessage_BuildsDefaultMessage()
        {
            string message = _templateService.BuildWelcomeMessage(OtherBusiness, TextMessageTemplateService.SAMPLE_PLACE_IN_LINE_URL);

            string expected = "Hey it's Other Business! You've been added to our wait list. You can see your place in line at https://plumlist.com/q/4l3oj6ny";

            message.ShouldEqual(expected);
        }

        public void BuildReadyMessage_BuildsDefaultMessage()
        {
            string message = _templateService.BuildReadyMessage(OtherBusiness);

            string expected = "It's Other Business. We're ready for you.";

            message.ShouldEqual(expected);
        }

        public void BuildWelcomeMessage_BuildsCustomMessage()
        {
            string message = _templateService.BuildWelcomeMessage(TestBusiness, TextMessageTemplateService.SAMPLE_PLACE_IN_LINE_URL);

            string expected = "Yo it's Test Business. https://plumlist.com/q/4l3oj6ny";

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
