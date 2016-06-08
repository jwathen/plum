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
using System.Web.Mvc;

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
                .ShouldJavaScriptRedirectTo(Url.Action(MVC.Queue.Show(null)));
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
                .ShouldJavaScriptRedirectTo(Url.Action(MVC.Queue.Show(queueId)));

            var customer = TestBusiness.Queues.First().Customers.OrderByDescending(x => x.Id).First();
            customer.Name.ShouldEqual("Jack");
            customer.NumberInParty.ShouldEqual(4);
            customer.PhoneNumber.ShouldEqual("9723743329");
            customer.UrlToken.ShouldNotBeNull();
            customer.QuotedTimeInMinutes.ShouldEqual(25);
            customer.Note.ShouldEqual("his name is Jack");

            var sentTextMessage = _controller.TextMessageService.SentMessages.Single();
            sentTextMessage.Message.ShouldNotBeNull();
            sentTextMessage.Destination.ShouldEqual("19723743329");
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

        public void Edit_GivenValidCustomerId_ReturnsView()
        {
            SignIn();            
            int customerId = TestBusiness.Queues.First().Customers.First().Id;
            SetRouteId(customerId);

            _controller.WithCallTo(x => x.Edit(customerId))
                .ShouldRenderDefaultViewHtml();
        }

        public void Edit_GivenCustomerIdForOtherBusiness_ReturnsNotAuthorized()
        {
            SignIn();
            int customerId = OtherBusiness.Queues.First().Customers.First().Id;
            SetRouteId(customerId);

            _controller.WithCallTo(x => x.Edit(customerId))
                .ShouldRedirectTo(MVC.Home.Name, MVC.Home.ActionNames.NotAuthorized);
        }

        public void Edit_GivenInvalidCustomerId_Returns404()
        {
            SignIn();
            int customerId = -1;
            SetRouteId(customerId);

            _controller.WithCallTo(x => x.Edit(customerId))
                .ShouldGiveHttpStatus(404);
        }

        public void Update_GivenValidModel_UpdateTheCustomer()
        {
            SignIn();
            var customer = TestBusiness.Queues.First().Customers.First();
            int customerId = customer.Id;
            SetRouteId(customerId);

            var model = new CustomerViewModel();
            model.CopyFrom(customer);

            model.Name = "New Name";
            model.Note = "New Note";
            model.NumberInParty = 45;
            model.PhoneNumber = "4444444444";
            model.QuotedTimeInMinutes = 150;

            _controller.WithCallTo(x => x.Update(model))
                .ShouldRedirectTo(MVC.Customer.Name, MVC.Customer.ActionNames.Show, new { id = customerId });

            customer = TestBusiness.Queues.First().Customers.First();
            customer.Name.ShouldEqual("New Name");
            customer.Note.ShouldEqual("New Note");
            customer.NumberInParty.ShouldEqual(45);
            customer.PhoneNumber.ShouldEqual("4444444444");
            customer.QuotedTimeInMinutes.ShouldEqual(150);
        }

        public void DestroyWithUrlToken_GivenInvalidToken_NoException()
        {
            _controller.WithCallTo(x => x.DestroyWithUrlToken("invalid token"))
                .ShouldRedirectTo<HomeController>(x => x.RemovedFromList());
        }

        public void DestroyWithUrlToken_GivenValidToken_RemovesCustomer()
        {
            int countBefore = TestBusiness.Queues.First().Customers.Count;

            _controller.WithCallTo(x => x.DestroyWithUrlToken("john-token"))
                .ShouldRedirectTo<HomeController>(x => x.RemovedFromList());

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
                .ShouldRedirectTo(MVC.Queue.Name, MVC.Queue.ActionNames.Show, new { id = queueId });

            Database.Customers.Find(customerId).ShouldBeNull();
        }

        public void Destroy_GivenCustomerIdForOtherBusiness_DoesNotRemoveTheCustomer()
        {
            SignIn();
            int customerId = OtherBusiness.Queues.First().Customers.First().Id;
            SetRouteId(customerId);

            _controller.WithCallTo(x => x.Destroy(customerId))
                .ShouldRedirectTo(MVC.Business.Name, MVC.Queue.ActionNames.Show, new { id = TestBusiness.Id    });

            Database.Customers.Find(customerId).ShouldNotBeNull();
        }

        public void Destroy_GivenInvalidCustomerId_NoException()
        {
            SignIn();
            int customerId = -1;
            SetRouteId(customerId);

            _controller.WithCallTo(x => x.Destroy(customerId))
                .ShouldRedirectTo(MVC.Business.Name, MVC.Queue.ActionNames.Show, new { id = TestBusiness.Id });
        }

        public void SendReadyMessage_GivenValidCustomerId_SendsTheReadyTextMessage()
        {
            SignIn();
            var customer = TestBusiness.Queues.First().Customers.First();
            SetRouteId(customer.Id);

            _controller.WithCallTo(x => x.SendReadyMessage(customer.Id))
                .ShouldRenderViewHtml(MVC.Customer.Views.Show);

            var sentMessageLogEntry = customer.LogEntries.Where(x => x.Type == Models.CustomerLogEntryType.ReadyTextMessageSent).ToList().Last();
            sentMessageLogEntry.ShouldNotBeNull();

            var sentTextMessage = _controller.TextMessageService.SentMessages.Single();
            sentTextMessage.Message.ShouldNotBeNull();
            sentTextMessage.Destination.ShouldEqual("11234567890");
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
                .ShouldGiveHttpStatus(404);

            short sortOrderAfter = Database.Customers.Find(customer.Id).SortOrder;
            sortOrderAfter.ShouldEqual(sortOrderBefore);
        }

        public void MoveToEndOfList_GivenInvalidCustomerId_NoException()
        {
            SignIn();
            int customerId = -1;

            _controller.WithCallTo(x => x.MoveToEndOfList(customerId))
                .ShouldGiveHttpStatus(404);
        }
    }
}
