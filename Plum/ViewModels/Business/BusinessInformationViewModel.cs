using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Attributes;
using Plum.Helpers;

namespace Plum.ViewModels.Business
{
    [Validator(typeof(BusinessInformationViewModelValidator))]
    public class BusinessInformationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public bool HasPhoneNumber()
        {
            return !string.IsNullOrWhiteSpace(PhoneNumber);
        }

        public void CopyFrom(Models.Business business)
        {
            Id = business.Id;
            Name = business.Name;
            PhoneNumber = business.PhoneNumber;
        }

        public void CopyTo(Models.Business business)
        {
            business.Name = Name;
            if (!string.IsNullOrWhiteSpace(PhoneNumber))
            {
                business.PhoneNumber = new string(PhoneNumber.Where(x => char.IsDigit(x)).ToArray());
            }
            else
            {
                business.PhoneNumber = null;
            }
        }
    }

    public class BusinessInformationViewModelValidator : AbstractValidator<BusinessInformationViewModel>
    {
        public BusinessInformationViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Business name is required.");
            RuleFor(x => x.PhoneNumber)
                .Must(ValidationHelpers.BeA10DigitPhoneNumber)
                .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber))
                .WithMessage("Please enter a valid 10-digit phone number.");
        }
    }
}