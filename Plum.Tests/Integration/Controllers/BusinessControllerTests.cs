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
    }
}
