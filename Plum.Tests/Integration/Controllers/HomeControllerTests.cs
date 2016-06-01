using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plum.Controllers;
using Plum.Tests.TestHelpers;
using TestStack.FluentMVCTesting;

namespace Plum.Tests.Integration.Controllers
{
    public class HomeControllerTests : WebTestBase<HomeController>
    {
        public void Index_Renders()
        {
            _controller.WithCallTo(x => x.Index())
                .ShouldRenderDefaultView();
        }
    }
}
