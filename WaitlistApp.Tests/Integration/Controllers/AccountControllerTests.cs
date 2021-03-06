﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaitlistApp.Controllers;
using WaitlistApp.Tests.TestHelpers;
using WaitlistApp.ViewModels.Account;
using TestStack.FluentMVCTesting;
using Should;
using WaitlistApp.Tests.TestHelpers.Mvc;
using System.Web.Mvc;

namespace WaitlistApp.Tests.Integration.Controllers
{
    public class AccountControllerTests : WebTestBase<AccountController>
    {
        public void SignUp_Renders()
        {
            _controller.WithCallTo(x => x.SignUp())
                .ShouldRenderDefaultViewHtml();
        }

        public void SignUp_CreatesABusiness()
        {
            Database.Businesses.RemoveRange(Database.Businesses.Where(x => x.Account.EmailAddress == "new_business@site.com"));
            Database.SaveChanges();

            var model = new SignUpViewModel();
            model.BusinessName = "New Business";
            model.EmailAddress = "new_business@site.com";
            model.Password = "password";
            _controller.WithCallTo(x => x.SignUp(model))
                .ShouldRedirectTo(MVC.Queue.Name, MVC.Queue.ActionNames.Show, new { id = NewBusiness.Queues.First().Id });

            NewBusiness.Name.ShouldEqual("New Business");
            NewBusiness.Queues.First().Name.ShouldEqual("Default");
        }

        public void SignIn_Renders()
        {
            _controller.WithCallTo(x => x.SignIn())
                .ShouldRenderDefaultViewHtml();
        }

        public void SignIn_GivenCorrectPassword_SignsIn()
        {
            var model = new SignInViewModel();
            model.EmailAddress = TestBusiness.Account.EmailAddress;
            model.Password = "passw0rd";
            int queueId = TestBusiness.Queues.First().Id;

            _controller.WithCallTo(x => x.SignIn(model))
                .ShouldRedirectTo(MVC.Queue.Name, MVC.Queue.ActionNames.Show, new { id = queueId });

            AppSession.BusinessName.ShouldEqual("Test Business");
        }

        public void SignIn_GivenReturnUrl_RedirectsToReturnUrl()
        {
            var model = new SignInViewModel();
            model.EmailAddress = TestBusiness.Account.EmailAddress;
            model.Password = "passw0rd";
            int queueId = TestBusiness.Queues.First().Id;

            Request.QueryString.Add("ReturnUrl", "/somepage");

            _controller.WithCallTo(x => x.SignIn(model))
                .ShouldRedirectTo("/somepage");

            AppSession.BusinessName.ShouldEqual("Test Business");
        }

        public void SignOut_RedirectsToHome()
        {
            _controller.WithCallTo(x => x.SignOut())
                .ShouldRedirectTo<AccountController>(x => x.SignIn());
        }
    }
}
