using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plum.Services;
using Humanizer;
using Humanizer.Localisation;
using System.Data.Entity;

namespace Plum.Models
{
    public class Customer : IDatedEntity
    {
        public virtual int Id { get; set; }
        public virtual int QueueId { get; set; }
        public virtual string Name { get; set; }
        public virtual int NumberInParty { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string UrlToken { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        public virtual short SortOrder { get; set; }
        public int? QuotedTimeInMinutes { get; set; }
        public string Note { get; set; }

        public virtual Queue Queue { get; set; }
        public virtual HashSet<CustomerLogEntry> LogEntries { get; set; } = new HashSet<CustomerLogEntry>();

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
            TimeSpan timeWaited = DateTime.UtcNow.Subtract(DateCreated);
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

        public string QuotedTimeWords()
        {
            if (QuotedTimeInMinutes.HasValue)
            {
                return TimeSpan.FromMinutes(QuotedTimeInMinutes.Value)
                    .Humanize(precision: 2, countEmptyUnits: false, maxUnit: TimeUnit.Hour, minUnit: TimeUnit.Minute);
            }
            else
            {
                return string.Empty;
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
                string customerViewUrl = urlHelper.ActionAbsolute(MVC.Queue.ShowCustomer(this.UrlToken));
                string message = $"Hey it's {Queue.Business.Name}! You've been added to our wait list. {customerViewUrl}";
                SendTextMessage(secrets, message);
                Log(CustomerLogEntryType.WelcomeTextMessageSent, $"\"{message}\"");
            }
        }

        public void SendReadyTextMessage(UrlHelper urlHelper, AppSecrets secrets)
        {
            if (this.HasPhoneNumber())
            {
                string message = $"It's {Queue.Business.Name}. We're ready for you.";
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