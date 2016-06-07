using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plum.Controllers;
using Plum.Tests.TestHelpers;
using TestStack.FluentMVCTesting;
using Plum.Tests.TestHelpers.Mvc;
using Should;
using Plum.ViewModels.Business;

namespace Plum.Tests.Integration.Controllers
{
    public class BusinessControllerTests : WebTestBase<BusinessController>
    {
        public void Show_GivenBusinessId_ReturnsView()
        {
            SignIn();
            int businessId = TestBusiness.Id;
            SetRouteId(businessId);

            _controller.WithCallTo(x => x.Show(businessId))
                .ShouldRenderDefaultViewHtml();
        }

        public void Show_GivenQueueIdForOtherBusiness_ReturnNotAuthorized()
        {
            SignIn();
            int otherBusinessId = OtherBusiness.Id;
            SetRouteId(otherBusinessId);

            _controller.WithCallTo(x => x.Show(otherBusinessId))
                .ShouldRedirectTo<HomeController>(x => x.NotAuthorized());
        }

        public void Show_GivenInvalidId_Return404()
        {
            _controller.WithCallTo(x => x.Show(-1))
                .ShouldGiveHttpStatus(404);
        }

        public void ShowBusinessInformation_GivenBusinessId_RendersView()
        {
            SignIn();
            SetRouteId(TestBusiness.Id);

            _controller.WithCallTo(x => x.ShowBusinessInformation(TestBusiness.Id))
                .ShouldRenderDefaultViewHtml();
        }

        public void EditBusinessInformation_GivenBusinessId_RendersView()
        {
            SignIn();
            SetRouteId(TestBusiness.Id);

            _controller.WithCallTo(x => x.EditBusinessInformation(TestBusiness.Id))
                .ShouldRenderDefaultViewHtml();
        }

        public void UpdateBusinessInfomration_GivenValidModel_ReturnsView()
        {
            SignIn();
            int id = TestBusiness.Id;
            SetRouteId(id);

            var model = new BusinessInformationViewModel();
            model.CopyFrom(TestBusiness);
            model.Name = "Brand New Name";
            model.PhoneNumber = "3333333333";

            _controller.WithCallTo(x => x.UpdateBusinessInformation(model))
                .ShouldRedirectTo(MVC.Business.Name, MVC.Business.ActionNames.ShowBusinessInformation, new { id = id });

            TestBusiness.Name.ShouldEqual("Brand New Name");
            TestBusiness.PhoneNumber.ShouldEqual("3333333333");
        }

        public void ShowSignInInformation_GivenBusinessId_RendersView()
        {
            SignIn();
            SetRouteId(TestBusiness.Id);

            _controller.WithCallTo(x => x.ShowSignInInformation(TestBusiness.Id))
                .ShouldRenderDefaultViewHtml();
        }

        public void EditSignInInformation_GivenBusinessId_RendersView()
        {
            SignIn();
            SetRouteId(TestBusiness.Id);

            _controller.WithCallTo(x => x.EditSignInInformation(TestBusiness.Id))
                .ShouldRenderDefaultViewHtml();
        }

        public void UpdateSignInInfomration_GivenValidModel_ReturnsView()
        {
            SignIn();
            var business = TestBusiness;
            int id = business.Id;
            SetRouteId(id);

            var model = new SignInInformationViewModel();
            model.CopyFrom(TestBusiness);
            model.EmailAddress = "brandnewemail@site.com";
            model.NewPassword = "new password";
            model.ConfirmNewPassword = "new password";
            model.CurrentPassword = "passw0rd";

            _controller.WithCallTo(x => x.UpdateSignInInformation(model))
                .ShouldRedirectTo(MVC.Business.Name, MVC.Business.ActionNames.ShowSignInInformation, new { id = id });

            business.Account.EmailAddress.ShouldEqual("brandnewemail@site.com");
            business.Account.VerifyPassword("new password").ShouldBeTrue();
        }
    }
}
