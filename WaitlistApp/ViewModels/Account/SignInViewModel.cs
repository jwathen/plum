using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Attributes;
using WaitlistApp.Models;

namespace WaitlistApp.ViewModels.Account
{
    [Validator(typeof(SignInViewModelValidator))]
    public class SignInViewModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class SignInViewModelValidator : AbstractValidator<SignInViewModel>
    {
        public SignInViewModelValidator()
        {
            RuleFor(x => x.EmailAddress)
                .NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("Email address is invalid");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}