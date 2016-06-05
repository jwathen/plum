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
    public class CustomerControllerTests : WebTestBase<CustomerController>
    {
        public void Show_GivenCusomterId_ReturnsView()
        {
            SignIn();
            int customerId = TestBusiness.Queues.First().Customers.First().Id;
            SetRouteId(customerId);

            _controller.WithCallTo(x => x.Show(customerId))
                .ShouldRenderDefaultViewHtml()
                .ShouldContainText("John");
        }

        public void Show_GivenCustomerIdForOtherBusiness_ReturnNotAuthorized()
        {
            SignIn();
            int otherBusinessCustomerId = OtherBusiness.Queues.First().Customers.First().Id;

            _controller.WithCallTo(x => x.Show(otherBusinessCustomerId))
                .ShouldGiveHttpStatus(404);
        }

        public void Create_GivenValidCustomer_CreatesCustomer()
        {
            SignIn();
            int queueId = TestBusiness.Queues.First().Id;

            var model = new CustomerViewModel();
            model.Name = "Jack";
            model.NumberInParty = 4;
            model.PhoneNumber = "9723743329";
            model.QueueId = queueId;
            model.QuotedTimeInMinutes = 25;
            model.Note = "his name is Jack";

            _controller.WithCallTo(x => x.Create(model))
                .ShouldReturnJavaScriptResult();

            var customer = TestBusiness.Queues.First().Customers.OrderByDescending(x => x.Id).First();
            customer.Name.ShouldEqual("Jack");
            customer.NumberInParty.ShouldEqual(4);
            customer.PhoneNumber.ShouldEqual("9723743329");
            customer.UrlToken.ShouldNotBeNull();
            customer.QuotedTimeInMinutes.ShouldEqual(25);
            customer.Note.ShouldEqual("his name is Jack");
        }

        public void Create_GivenQueueIdForOtherBusiness_ReturnsNotAuthorized()
        {
            SignIn();
            int otherBusinessQueueId = OtherBusiness.Queues.First().Id;

            var model = new CustomerViewModel();
            model.Name = "Jack";
            model.NumberInParty = 4;
            model.PhoneNumber = "9723743329";
            model.QueueId = otherBusinessQueueId;

            _controller.WithCallTo(x => x.Create(model))
                .ShouldRedirectTo<HomeController>(x => x.NotAuthorized());
        }

        public void Edit_Test()
        {
            throw new NotImplementedException("Tests for CustomerController.Edit have not been implemented yet.");
        }

        public void Update_Test()
        {
            throw new NotImplementedException("Tests for CustomerController.Update have not been implemented yet.");
        }

        public void DestroyWithUrlToken_GivenInvalidToken_NoException()
        {
            _controller.WithCallTo(x => x.DestroyWithUrlToken("invalid token"))
                .ShouldRedirectTo<HomeController>(x => x.Index());
        }

        public void DestroyWithUrlToken_GivenValidToken_RemovesCustomer()
        {
            int countBefore = TestBusiness.Queues.First().Customers.Count;

            _controller.WithCallTo(x => x.DestroyWithUrlToken("john-token"))
                .ShouldRedirectTo<HomeController>(x => x.Index());

            int countAfter = TestBusiness.Queues.First().Customers.Count;
            countAfter.ShouldEqual(countBefore - 1);
        }

        public void Destroy_CusomterId_RemovesTheCustomer()
        {
            SignIn();
            int queueId = TestBusiness.Queues.First().Id;
            int customerId = TestBusiness.Queues.First().Customers.First().Id;
            SetRouteId(customerId);

            _controller.WithCallTo(x => x.Destroy(customerId))
                .ShouldReturnJavaScriptResult();

            Database.Customers.Find(customerId).ShouldBeNull();
        }

        public void Destroy_GivenCustomerIdForOtherBusiness_DoesNotRemoveTheCustomer()
        {
            SignIn();
            int customerId = OtherBusiness.Queues.First().Customers.First().Id;
            SetRouteId(customerId);

            _controller.WithCallTo(x => x.Destroy(customerId))
                .ShouldRedirectTo(MVC.Businesses.Name, MVC.Queue.ActionNames.Show, new { id = TestBusiness.Id    });

            Database.Customers.Find(customerId).ShouldNotBeNull();
        }

        public void Destroy_GivenInvalidCustomerId_NoException()
        {
            SignIn();
            int customerId = -1;
            SetRouteId(customerId);

            _controller.WithCallTo(x => x.Destroy(customerId))
                .ShouldRedirectTo(MVC.Businesses.Name, MVC.Queue.ActionNames.Show, new { id = TestBusiness.Id });
        }

        public void SendReadyMessage_Test()
        {
            throw new NotImplementedException("Tests for CustomerController.SendReadyMessage have not been implemented yet.");
        }

        public void MoveToEndOfList_GivenValidCustomer_MovesTheCustomer()
        {
            SignIn();
            int queueId = TestBusiness.Queues.First().Id;
            int customerId = TestBusiness.Queues.First().Customers.First().Id;
            SetRouteId(customerId);

            _controller.WithCallTo(x => x.MoveToEndOfList(customerId))
                .ShouldRenderViewHtml(MVC.Customer.Views.Show);

            Database.Queues.Find(queueId).OrderedCustomers().Last().Id.ShouldEqual(customerId);
        }

        public void MoveToEndOfList_GivenCustomerIdForOtherBusiness_DoesNotMoveTheCustomer()
        {
            SignIn();
            var customer = OtherBusiness.Queues.First().Customers.First();
            short sortOrderBefore = customer.SortOrder;

            _controller.WithCallTo(x => x.MoveToEndOfList(customer.Id))
                .ShouldRedirectTo(MVC.Businesses.Name, MVC.Businesses.ActionNames.Show, new { id = TestBusiness.Id });

            short sortOrderAfter = Database.Customers.Find(customer.Id).SortOrder;
            sortOrderAfter.ShouldEqual(sortOrderBefore);
        }

        public void MoveToEndOfList_GivenInvalidCustomerId_NoException()
        {
            SignIn();
            int customerId = -1;

            _controller.WithCallTo(x => x.MoveToEndOfList(customerId))
                .ShouldRedirectTo(MVC.Businesses.Name, MVC.Businesses.ActionNames.Show, new { id = TestBusiness.Id });
        }
    }
}
