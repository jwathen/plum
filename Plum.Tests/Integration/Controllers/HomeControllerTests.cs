using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plum.Controllers;
using Plum.Tests.TestHelpers;
using TestStack.FluentMVCTesting;
using Plum.Tests.TestHelpers.Mvc;
using Plum.ViewModels.Home;
using Should;

namespace Plum.Tests.Integration.Controllers
{
    public class HomeControllerTests : WebTestBase<HomeController>
    {
        public void Index_Renders()
        {
            _controller.WithCallTo(x => x.Index())
                .ShouldRenderDefaultViewHtml()
                .ShouldMatchCss("div.jumbo");
        }

        public void NotAuthorized_Renders()
        {
            _controller.WithCallTo(x => x.NotAuthorized())
                .ShouldRenderDefaultViewHtml();
        }

        public void NotFound_Renders()
        {
            _controller.WithCallTo(x => x.NotFound())
                .ShouldRenderDefaultViewHtml();
        }

        public void PrivacyPolicy_Renders()
        {
            _controller.WithCallTo(x => x.PrivacyPolicy())
                .ShouldRenderDefaultViewHtml();
        }

        public void TermsOfuUse_Renders()
        {
            _controller.WithCallTo(x => x.TermsOfUse())
                .ShouldRenderDefaultViewHtml();
        }

        public void RemovedFromList_Renders()
        {
            _controller.WithCallTo(x => x.RemovedFromList())
                .ShouldRenderDefaultViewHtml();
        }

        public void ContactUs_Renders()
        {
            _controller.WithCallTo(x => x.ContactUs())
                .ShouldRenderDefaultViewHtml();
        }

        public void ContactUs_WhenSignedIn_RendersWithEmailAddress()
        {
            SignIn();

            _controller.WithCallTo(x => x.ContactUs())
                .ShouldRenderDefaultViewHtml()
                .ShouldContainHtml(TestBusiness.Account.EmailAddress);
        }

        public void ContactUs_GivenMessage_SendsMessage()
        {
            var model = new ContactUsViewModel();
            model.EmailAddress = "from@site.com";
            model.Message = "some message";

            _controller.WithCallTo(x => x.ContactUs(model))
                .ShouldRedirectTo(MVC.Home.Name, MVC.Home.ActionNames.ContactUs);

            var sentMessage = _controller.Email.SentMessages.Last();
            sentMessage.From.Address.ShouldEqual("from@site.com");
            sentMessage.To[0].Address.ShouldEqual(AppSettings.App.Email.ComapanyEmailAddress);
            sentMessage.Body.ShouldEqual("some message");
        }
    }
}
