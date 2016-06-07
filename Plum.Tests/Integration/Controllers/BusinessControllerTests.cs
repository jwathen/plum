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

        public void Show_GivenInvalidQueueId_Return404()
        {
            _controller.WithCallTo(x => x.Show(-1))
                .ShouldGiveHttpStatus(404);
        }

        public void Edit_GivenBusinessId_ReturnsView()
        {
            SignIn();
            int businessId = TestBusiness.Id;
            SetRouteId(businessId);

            _controller.WithCallTo(x => x.Edit(businessId))
                .ShouldRenderDefaultViewHtml();
        }

        public void Edit_GivenQueueIdForOtherBusiness_ReturnNotAuthorized()
        {
            SignIn();
            int otherBusinessId = OtherBusiness.Id;
            SetRouteId(otherBusinessId);

            _controller.WithCallTo(x => x.Edit(otherBusinessId))
                .ShouldRedirectTo<HomeController>(x => x.NotAuthorized());
        }

        public void Edit_GivenInvalidQueueId_Return404()
        {
            _controller.WithCallTo(x => x.Edit(-1))
                .ShouldGiveHttpStatus(404);
        }

        public void Update_GivenValidModel_ReturnsView()
        {
            SignIn();
            int businessId = TestBusiness.Id;
            SetRouteId(businessId);

            var model = new BusinessInformationViewModel();
            model.CopyFrom(TestBusiness);
            model.Name = "Brand New Name";
            model.PhoneNumber = "3333333333";

            _controller.WithCallTo(x => x.Update(model))
                .ShouldRedirectTo(MVC.Business.Name, MVC.Business.ActionNames.Show, new { id = businessId });
        }

        public void Update_GivenQueueIdForOtherBusiness_ReturnNotAuthorized()
        {
            SignIn();
            int otherBusinessId = OtherBusiness.Id;
            SetRouteId(otherBusinessId);

            var model = new BusinessInformationViewModel();
            model.Id = otherBusinessId;

            _controller.WithCallTo(x => x.Update(model))
                .ShouldRedirectTo<HomeController>(x => x.NotAuthorized());
        }

        public void Update_GivenInvalidQueueId_Return404()
        {
            SignIn();
            SetRouteId(-1);

            var model = new BusinessInformationViewModel();
            model.Id = -1;

            _controller.WithCallTo(x => x.Update(model))
                .ShouldGiveHttpStatus(404);
        }
    }
}
