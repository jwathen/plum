using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Attributes;

namespace Plum.ViewModels.Customer
{
    [Validator(typeof(CustomerViewModelValidator))]
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            NumberInParty = 2;
        }

        public int QueueId { get; set; }
        public string Name { get; set; }
        public int NumberInParty { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class CustomerViewModelValidator : AbstractValidator<CustomerViewModel>
    {
        public CustomerViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.");
            RuleFor(x => x.PhoneNumber)
                .Must(BeA10DigitPhoneNumber)
                .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber))
                .WithMessage("Please enter a valid 10-digit phone number.");
        }

        public bool BeA10DigitPhoneNumber(string phoneNumber)
        {
            return phoneNumber
                .Replace("(", string.Empty)
                .Replace(")", string.Empty)
                .Replace("-", string.Empty)
                .Replace("#", string.Empty)
                .Count(x => char.IsDigit(x)) == 10;
        }
    }
}