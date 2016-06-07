using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Plum.Services;

namespace Plum.ViewModels.Business
{
    public class TextMessagesViewModel
    {
        TextMessageTemplateService _textMessageTemplates = new TextMessageTemplateService();

        public int Id { get; set; }
        public string WelcomeTextMessage { get; set; }
        public string ReadyTextMessage { get; set; }
        public string DefaultWelcomeMessage { get; set; }
        public string DefaultReadyMessage { get; set; }
        public string SampleWelcomeMessage { get; set; }
        public string SampleReadyMessage { get; set; }

        public void CopyFrom(Models.Business business)
        {
            Id = business.Id;
            WelcomeTextMessage = business.WelcomeTextMessage;
            ReadyTextMessage = business.ReadyTextMessage;

            var textMessageTemplates = new TextMessageTemplateService();
            DefaultWelcomeMessage = textMessageTemplates.GetDefaultWelcomeMessage(business);
            DefaultReadyMessage = textMessageTemplates.GetDefaultReadyMessage(business);

            SampleWelcomeMessage = textMessageTemplates.BuildWelcomeMessage(business, TextMessageTemplateService.SAMPLE_PLACE_IN_LINE_URL);
            SampleReadyMessage = textMessageTemplates.BuildReadyMessage(business);
        }
    }
}