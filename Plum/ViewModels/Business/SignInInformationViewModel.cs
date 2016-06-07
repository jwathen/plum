using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Attributes;
using Plum.Models;

namespace Plum.ViewModels.Business
{
    [Validator(typeof(SignInInformationViewModelValidator))]
    public class SignInInformationViewModel
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public string CurrentPassword { get; set; }

        public void CopyFrom(Models.Business business)
        {
            Id = business.Id;
            EmailAddress = business.Account.EmailAddress;
        }
    }

    public class SignInInformationViewModelValidator : AbstractValidator<SignInInformationViewModel>
    {
        public SignInInformationViewModelValidator()
        {
            RuleFor(x => x.EmailAddress)
               .NotEmpty().WithMessage("Email address is required")
               .EmailAddress().WithMessage("Email address is invalid")
               .Must(BeUnique).WithMessage("A different business has already signed up using {0}.", x => x.EmailAddress);
            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("Please enter your current password.");
            RuleFor(x => x.ConfirmNewPassword)
                .Equal(x => x.NewPassword)
                .When(x => !string.IsNullOrWhiteSpace(x.NewPassword))
                .WithMessage("The new password and confirm new password fields do not match.");
        }

        public bool BeUnique(SignInInformationViewModel model, string emailAddress)
        {
            using (var db = new AppDataContext())
            {
                return !db.Businesses.Any(x => x.Id != model.Id && x.Account.EmailAddress == emailAddress);
            }
        }
    }
}