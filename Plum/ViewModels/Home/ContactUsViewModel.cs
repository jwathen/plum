using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Attributes;

namespace Plum.ViewModels.Home
{
    [Validator(typeof(ContactUsViewModelValidator))]
    public class ContactUsViewModel
    {
        public string EmailAddress { get; set; }
        public string Message { get; set; }
    }

    public class ContactUsViewModelValidator : AbstractValidator<ContactUsViewModel>
    {
        public ContactUsViewModelValidator()
        {
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage("Please enter your email address.")
                .EmailAddress()
                .WithMessage("Please enter a valid email address.");
            RuleFor(x => x.Message)
                .NotEmpty()
                .WithMessage("Please enter a message.");
        }
    }
}