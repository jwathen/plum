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
using Plum.ViewModels.Customer;

namespace Plum.Tests.Integration.Controllers
{
    public class QueueControllerTests : WebTestBase<QueueController>
    {
        public void CustomerView_GivenInvalidToken_ReturnsCustomerNotFound()
        {
            _controller.WithCallTo(x => x.CustomerView("invalid token"))
                .ShouldRenderViewHtml(MVC.Queue.Views.CustomerNotFound);
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
                .ShouldReturnJavaScriptResult();

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

        public void AddCustomer_GivenValidCustomer_CreatesCustomer()
        {
            SignIn();
            int queueId = TestBusiness.Queues.First().Id;

            var model = new CustomerViewModel();
            model.Name = "Jack";
            model.NumberInParty = 4;
            model.PhoneNumber = "9723743329";
            model.QueueId = queueId;
            
            _controller.WithCallTo(x => x.AddCustomer(model))
                .ShouldRedirectTo(MVC.Queue.Name, MVC.Queue.ActionNames.Manage, new { queueId = queueId });

            var customer = TestBusiness.Queues.First().Customers.OrderByDescending(x => x.Id).First();
            customer.Name.ShouldEqual("Jack");
            customer.NumberInParty.ShouldEqual(4);
            customer.PhoneNumber.ShouldEqual("9723743329");
            customer.UrlToken.ShouldNotBeNull();
        }

        public void AddCustomer_GivenQueueIdForOtherBusiness_ReturnsNotAuthorized()
        {
            SignIn();
            int otherBusinessQueueId = OtherBusiness.Queues.First().Id;

            var model = new CustomerViewModel();
            model.Name = "Jack";
            model.NumberInParty = 4;
            model.PhoneNumber = "9723743329";
            model.QueueId = otherBusinessQueueId;

            _controller.WithCallTo(x => x.AddCustomer(model))
                .ShouldRedirectTo<HomeController>(x => x.NotAuthorized());
        }

        public void MoveToEndOfList_GivenValidCustomer_MovesTheCustomer()
        {
            SignIn();
            int queueId = TestBusiness.Queues.First().Id;
            int customerId = TestBusiness.Queues.First().Customers.First().Id;

            _controller.WithCallTo(x => x.MoveToEndOfList(customerId))
                .ShouldRenderViewHtml(MVC.Queue.Views.ManageCustomerModal);

            Database.Queues.Find(queueId).OrderedCustomers().Last().Id.ShouldEqual(customerId);
        }

        public void MoveToEndOfList_GivenCustomerIdForOtherBusiness_DoesNotMoveTheCustomer()
        {
            SignIn();
            var customer = OtherBusiness.Queues.First().Customers.First();
            short sortOrderBefore = customer.SortOrder;

            _controller.WithCallTo(x => x.MoveToEndOfList(customer.Id))
                .ShouldRedirectTo(MVC.Queue.Name, MVC.Queue.ActionNames.Manage);

            short sortOrderAfter = Database.Customers.Find(customer.Id).SortOrder;
            sortOrderAfter.ShouldEqual(sortOrderBefore);
        }

        public void MoveToEndOfList_GivenInvalidCustomerId_NoException()
        {
            SignIn();
            int customerId = -1;

            _controller.WithCallTo(x => x.MoveToEndOfList(customerId))
                .ShouldRedirectTo(MVC.Queue.Name, MVC.Queue.ActionNames.Manage);
        }

        public void SortQueue_Test()
        {
            throw new NotImplementedException();
        }
    }
}
