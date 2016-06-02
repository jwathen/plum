using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plum.Services;
using Humanizer;

namespace Plum.Models
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual int QueueId { get; set; }
        public virtual string Name { get; set; }
        public virtual int NumberInParty { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string UrlToken { get; set; }
        public virtual DateTime DateAdded { get; set; }
        public virtual short SortOrder { get; set; }

        public virtual Queue Queue { get; set; }
        public virtual ICollection<CustomerLogEntry> LogEntries { get; set; } = new List<CustomerLogEntry>();

        public string ObfuscateName(Customer currentCustomer)
        {
            if (currentCustomer == this)
            {
                return currentCustomer.Name;
            }
            else
            {
                return Name[0].ToString();
            }
        }

        public TimeSpan TimeWaited()
        {
            TimeSpan timeWaited = DateTime.UtcNow.Subtract(DateAdded);
            if (timeWaited < TimeSpan.FromSeconds(1))
            {
                timeWaited = TimeSpan.FromSeconds(1);
            }
            return timeWaited;
        }

        public string TimeWaitedWords()
        {
            var timeWaited = TimeWaited();
            if (timeWaited < TimeSpan.FromMinutes(1))
            {
                return "less than a minute";
            }
            else
            {
                return timeWaited.Humanize();
            }
        }

        public bool HasPhoneNumber()
        {
            return !string.IsNullOrWhiteSpace(PhoneNumber);
        }

        public void Log(CustomerLogEntryType type, string message)
        {
            LogEntries.Add(new CustomerLogEntry
            {
                DateInserted = DateTime.UtcNow,
                Message = message,
                Type = type
            });
        }

        public void GenerateUrlToken(AppDataContext db, ProfanityFilter profanityFilter)
        {
            string token = string.Empty;
            char[] characters = "abcdefghijklmnopqrstuvwxyz1234567890".ToArray();
            var random = new Random();

            do
            {
                token = string.Empty;
                while (token.Length < 8)
                {
                    token += characters[random.Next(0, characters.Length - 1)];
                }
            }
            while (profanityFilter.ContainsProfanity(token) || db.Customers.Any(x => x.UrlToken == token));

            UrlToken = token.ToString();
        }

        public void SendWelcomeTextMessage(UrlHelper urlHelper, AppSecrets secrets)
        {
            if (this.HasPhoneNumber())
            {
                string customerViewUrl = urlHelper.ActionAbsolute(MVC.Queue.CustomerView(this.UrlToken));
                string message = $"{Queue.Business.Name}: You've been added to our wait list.  See your place in line at: {customerViewUrl}";
                SendTextMessage(secrets, message);
                Log(CustomerLogEntryType.WelcomeTextMessageSent, $"\"{message}\"");
            }
        }

        public void SendReadyTextMessage(UrlHelper urlHelper, AppSecrets secrets)
        {
            if (this.HasPhoneNumber())
            {
                string message = $"{Queue.Business.Name}: Your table is ready. Reply 1, 2, or 3. 1 = I'm on my way. 2 = I need a few minutes but I'm still coming.  3 = I'd like to cancel.";
                SendTextMessage(secrets, message);
                Log(CustomerLogEntryType.ReadyTextMessageSent, $"\"{message}\"");
            }
        }

        private void SendTextMessage(AppSecrets secrets, string message)
        {
            var twilio = new Twilio.TwilioRestClient(secrets.TwilioAccountSid, secrets.TwilioAuthToken);
            twilio.SendMessage(AppSettings.TwilioPhoneNumber, PhoneNumber, message);
        }
    }
}