using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Attributes;
using WaitlistApp.Models;

namespace WaitlistApp.ViewModels.Account
{
    [Validator(typeof(SignUpViewModelValidator))]
    public class SignUpViewModel
    {
        public string BusinessName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }

    public class SignUpViewModelValidator : AbstractValidator<SignUpViewModel>
    {
        public SignUpViewModelValidator()
        {
            RuleFor(x => x.BusinessName)
                .NotEmpty().WithMessage("Business name is required.")
                .Length(0, 250).WithMessage("Business name must be fewer than 250 characters.");
            RuleFor(x => x.EmailAddress)
                .NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("Email address is invalid")
                .Must(BeUnique).WithMessage("A different business has already signed up using {0}.", x => x.EmailAddress);
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }

        public bool BeUnique(string emailAddress)
        {
            var db = new AppDataContext();
            return !db.Businesses.Any(x => x.Account.EmailAddress == emailAddress);
        }
    }
}