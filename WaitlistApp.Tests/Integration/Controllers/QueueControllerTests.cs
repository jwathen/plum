using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaitlistApp.Controllers;
using WaitlistApp.Tests.TestHelpers;
using TestStack.FluentMVCTesting;
using WaitlistApp.Tests.TestHelpers.Mvc;
using Should;
using WaitlistApp.ViewModels.Customer;

namespace WaitlistApp.Tests.Integration.Controllers
{
    public class QueueControllerTests : WebTestBase<QueueController>
    {
        public void ShowCustomer_GivenInvalidToken_ReturnsCustomerNotFound()
        {
            _controller.WithCallTo(x => x.ShowCustomer("invalid token"))
                .ShouldRenderViewHtml(MVC.Queue.Views.CustomerNotFound);
        }

        public void ShowCustomer_GivenValidToken_ReturnsView()
        {
            _controller.WithCallTo(x => x.ShowCustomer("john-token"))
                .ShouldRenderDefaultViewHtml()
                .ShouldContainText("John (2)")
                .ShouldContainText("B (6)");
        }

        public void CustomerViewQueueList_GivenValidToken_ReturnsView()
        {
            _controller.WithCallTo(x => x.CustomerViewQueueList("john-token"))
               .ShouldRenderDefaultViewHtml()
               .ShouldContainText("John (2)")
               .ShouldContainText("B (6)");
        }

        public void Show_GivenQueueId_ReturnsView()
        {
            SignIn();
            int queueId = TestBusiness.Queues.First().Id;
            SetRouteId(queueId);

            _controller.WithCallTo(x => x.Show(queueId))
                .ShouldRenderDefaultViewHtml()
                .ShouldContainText("John (2)")
                .ShouldContainText("Bill (6)");
        }

        public void Show_GivenQueueIdForOtherBusiness_ReturnNotAuthorized()
        {
            SignIn();
            int otherBusinessQueueId = OtherBusiness.Queues.First().Id;
            SetRouteId(otherBusinessQueueId);

            _controller.WithCallTo(x => x.Show(otherBusinessQueueId))
                .ShouldRedirectTo<HomeController>(x => x.NotAuthorized());
        }

        public void Show_GivenInvalidQueueId_Return404()
        {
            _controller.WithCallTo(x => x.Show(-1))
                .ShouldGiveHttpStatus(404);
        }

        public void BusinessViewQueueList_GivenQueueId_ReturnsView()
        {
            SignIn();
            int queueId = TestBusiness.Queues.First().Id;
            SetRouteId(queueId);

            _controller.WithCallTo(x => x.BusinessViewQueueList(queueId))
                .ShouldRenderDefaultViewHtml()
                .ShouldContainText("John (2)")
                .ShouldContainText("Bill (6)");
        }

        public void Sort_GiventCustomerList_ReordersTheCustomers()
        {
            SignIn();
            int queueId = TestBusiness.Queues.First().Id;
            var originalOrder = TestBusiness.Queues.First().OrderedCustomers().Select(x => x.Id).ToArray();
            int[] expectedOrder = originalOrder.Reverse().ToArray();

            _controller.WithCallTo(x => x.Sort(queueId, expectedOrder))
                .ShouldReturnJson();

            int[] actualOrder = TestBusiness.Queues.First().OrderedCustomers().Select(x => x.Id).ToArray(); ;
            actualOrder.SequenceEqual(expectedOrder).ShouldBeTrue();
        }
    }
}
