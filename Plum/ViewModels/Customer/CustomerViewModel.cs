using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Attributes;
using Humanizer;
using Humanizer.Localisation;
using Plum.Helpers;

namespace Plum.ViewModels.Customer
{
    [Validator(typeof(CustomerViewModelValidator))]
    public class CustomerViewModel
    {
        protected static readonly TimeSpan QUOTED_WAIT_TIME_OPTIONS_START = TimeSpan.Parse(AppSettings.App.QuotedWaitTimeOptions.Start);
        protected static readonly TimeSpan QUOTED_WAIT_TIME_OPTIONS_END = TimeSpan.Parse(AppSettings.App.QuotedWaitTimeOptions.End);
        protected static readonly TimeSpan QUOTED_WAIT_TIME_OPTIONS_INCREMENT = TimeSpan.Parse(AppSettings.App.QuotedWaitTimeOptions.Increment);

        public CustomerViewModel()
        {
            NumberInParty = 2;
        }

        public int Id { get; set; }
        public int QueueId { get; set; }
        public string Name { get; set; }
        public int NumberInParty { get; set; }
        public string PhoneNumber { get; set; }
        public int? QuotedTimeInMinutes { get; set; }
        public string Note { get; set; }
        public Models.Customer Customer { get; set; }

        public void CopyFrom(Models.Customer customer)
        {
            Id = customer.Id;
            QueueId = customer.QueueId;
            Name = customer.Name;
            NumberInParty = customer.NumberInParty;
            PhoneNumber = customer.PhoneNumber;
            QuotedTimeInMinutes = customer.QuotedTimeInMinutes;
            Note = customer.Note;
            Customer = customer;
        }

        public void CopyTo(Models.Customer customer)
        {
            customer.QueueId = QueueId;
            customer.Name = Name;
            customer.NumberInParty = NumberInParty;
            if (!string.IsNullOrWhiteSpace(PhoneNumber))
            {
                customer.PhoneNumber = new string(PhoneNumber.Where(x => char.IsDigit(x)).ToArray());
            }
            else
            {
                customer.PhoneNumber = null;
            }
            customer.QuotedTimeInMinutes = QuotedTimeInMinutes;
            customer.Note = Note;
        }

        public IEnumerable<SelectListItem> GetQuotedWaitTimeOptions()
        {
            TimeSpan current = QUOTED_WAIT_TIME_OPTIONS_START;
            var options = new List<SelectListItem>();
            do
            {
                options.Add(new SelectListItem
                {
                    Text = current.Humanize(precision: 2, countEmptyUnits: false, maxUnit: TimeUnit.Hour, minUnit: TimeUnit.Minute),
                    Value = current.TotalMinutes.ToString()
                });

                current = current.Add(QUOTED_WAIT_TIME_OPTIONS_INCREMENT);
            } while (current <= QUOTED_WAIT_TIME_OPTIONS_END);

            return options;
        }
    }

    public class CustomerViewModelValidator : AbstractValidator<CustomerViewModel>
    {
        public CustomerViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.");
            RuleFor(x => x.PhoneNumber)
                .Must(ValidationHelpers.BeA10DigitPhoneNumber)
                .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber))
                .WithMessage("Please enter a valid 10-digit phone number.");
        }
    }
}