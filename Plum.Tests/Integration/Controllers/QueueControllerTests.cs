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
    public class QueueControllerTests : WebTestBase<QueueController>
    {
        public void CustomerView_GivenInvalidToken_Returns404()
        {
            _controller.WithCallTo(x => x.CustomerView("invalid token"))
                .ShouldGiveHttpStatus(404);
        }

        public void CustomerView_GivenValidToken_ReturnsView()
        {
            _controller.WithCallTo(x => x.CustomerView("john-token"))
                .ShouldRenderDefaultViewHtml()
                .ShouldContainText("John (2)")
                .ShouldContainText("B (6)");
        }

        public void CancelPlaceInLine_GivenInvalidToken_NoException()
        {
            _controller.WithCallTo(x => x.CancelPlaceInLine("invalid token"))
                .ShouldRedirectTo<HomeController>(x => x.Index());
        }

        public void CancelPlaceInLine_GivenValidToken_RemovesCustomer()
        {
            int countBefore = TestBusiness.Queues.First().Customers.Count;

            _controller.WithCallTo(x => x.CancelPlaceInLine("john-token"))
                .ShouldRedirectTo<HomeController>(x => x.Index());

            int countAfter = TestBusiness.Queues.First().Customers.Count;
            countAfter.ShouldEqual(countBefore - 1);
        }

        public void Manage_GivenQueueId_ReturnsView()
        {
            SignIn();
            int queueId = TestBusiness.Queues.First().Id;

            _controller.WithCallTo(x => x.Manage(queueId))
                .ShouldRenderDefaultViewHtml()
                .ShouldContainText("John (2)")
                .ShouldContainText("Bill (6)");
        }

        public void Manage_WithoutQueueId_ReturnsRedirectWithQueueId()
        {
            SignIn();
            int queueId = TestBusiness.Queues.First().Id;

            _controller.WithCallTo(x => x.Manage(null))
                .ShouldRedirectTo(MVC.Queue.ActionNames.Manage, new { queueId = queueId });
        }

        public void Manage_GivenQueueIdForOtherBusiness_ReturnNotAuthorized()
        {
            SignIn();
            int otherBusinessQueueId = OtherBusiness.Queues.First().Id;

            _controller.WithCallTo(x => x.Manage(otherBusinessQueueId))
                .ShouldRedirectTo<HomeController>(x => x.NotAuthorized());
        }

        public void Manage_GivenInvalidQueueId_Return404()
        {
            _controller.WithCallTo(x => x.Manage(-1))
                .ShouldGiveHttpStatus(404);
        }

        public void ManageCustomerModal_CusomterId_ReturnsView()
        {
            SignIn();
            int customerId = TestBusiness.Queues.First().Customers.First().Id;

            _controller.WithCallTo(x => x.ManageCustomerModal(customerId))
                .ShouldRenderDefaultViewHtml()
                .ShouldContainText("John");
        }

        public void ManageCustomerModal_GivenCustomerIdForOtherBusiness_ReturnNotAuthorized()
        {
            SignIn();
            int otherBusinessCustomerId = OtherBusiness.Queues.First().Customers.First().Id;

            _controller.WithCallTo(x => x.ManageCustomerModal(otherBusinessCustomerId))
                .ShouldRedirectTo<HomeController>(x => x.NotAuthorized());
        }

        public void RemoveCustomer_CusomterId_RemovesTheCustomer()
        {
            SignIn();
            int queueId = TestBusiness.Queues.First().Id;
            int customerId = TestBusiness.Queues.First().Customers.First().Id;

            _controller.WithCallTo(x => x.RemoveCustomer(customerId))
                .ShouldRedirectTo(MVC.Queue.Name, MVC.Queue.ActionNames.Manage, new { queueId = queueId });

            Database.Customers.Find(customerId).ShouldBeNull();
        }

        public void RemoveCustomer_GivenCustomerIdForOtherBusiness_DoesNotRemoveTheCustomer()
        {
            SignIn();
            int customerId = OtherBusiness.Queues.First().Customers.First().Id;

            _controller.WithCallTo(x => x.RemoveCustomer(customerId))
                .ShouldRedirectTo(MVC.Queue.Name, MVC.Queue.ActionNames.Manage);

            Database.Customers.Find(customerId).ShouldNotBeNull();
        }

        public void RemoveCustomer_GivenInvalidCustomerId_NoException()
        {
            SignIn();
            int customerId = -1;

            _controller.WithCallTo(x => x.RemoveCustomer(customerId))
                .ShouldRedirectTo(MVC.Queue.Name, MVC.Queue.ActionNames.Manage);
        }
    }
}
