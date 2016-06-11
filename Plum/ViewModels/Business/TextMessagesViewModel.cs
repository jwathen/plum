using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Attributes;
using Plum.Services;

namespace Plum.ViewModels.Business
{
    [Validator(typeof(TextMessagesViewModelValidator))]
    public class TextMessagesViewModel
    {
        TextMessageTemplateService _textMessageTemplates = new TextMessageTemplateService();

        public Models.Business Business { get; set; }
        public int Id { get; set; }
        public string WelcomeTextMessage { get; set; }
        public string ReadyTextMessage { get; set; }
        public string SampleWelcomeMessage { get; set; }
        public string SampleReadyMessage { get; set; }

        public void CopyFrom(Models.Business business)
        {
            Id = business.Id;
            Business = business;
            WelcomeTextMessage = business.WelcomeTextMessage;
            ReadyTextMessage = business.ReadyTextMessage;

            var textMessageTemplates = new TextMessageTemplateService();

            if (string.IsNullOrWhiteSpace(WelcomeTextMessage))
            {
                WelcomeTextMessage = textMessageTemplates.GetDefaultWelcomeMessage(business);
            }

            if (string.IsNullOrWhiteSpace(ReadyTextMessage))
            {
                ReadyTextMessage = textMessageTemplates.GetDefaultReadyMessage(business);
            }            

            SampleWelcomeMessage = textMessageTemplates.BuildWelcomeMessage(business, TextMessageTemplateService.SAMPLE_PLACE_IN_LINE_URL);
            SampleReadyMessage = textMessageTemplates.BuildReadyMessage(business);
        }

        public void CopyTo(Models.Business business)
        {
            business.WelcomeTextMessage = WelcomeTextMessage;
            business.ReadyTextMessage = ReadyTextMessage;
        }
    }

    public class TextMessagesViewModelValidator : AbstractValidator<TextMessagesViewModel>
    {
        public TextMessagesViewModelValidator()
        {
            RuleFor(x => x.WelcomeTextMessage)
                .NotEmpty()
                .WithMessage("A welcome text message is required.");
            RuleFor(x => x.ReadyTextMessage)
                .NotEmpty()
                .WithMessage("A ready text message is required.");
        }
    }
}