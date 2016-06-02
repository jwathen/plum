using System;
using System.Collections.Generic;
using System.Linq;
using Plum.Services;

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

        public void Log(CustomerLogEntryType type, string message)
        {
            LogEntries.Add(new CustomerLogEntry
            {
                DateInserted = DateTime.UtcNow,
                Message = message,
                Type = type
            });
        }

        public void GenerateUrlToken(AppDataContext db)
        {
            string token = string.Empty;
            char[] characters = "abcdefghijklmnopqrstuvwxyz1234567890".ToArray();
            var random = new Random();
            var profanityService = new ProfanityService();

            do
            {
                token = string.Empty;
                while (token.Length < 8)
                {
                    token += characters[random.Next(0, characters.Length - 1)];
                }
            }
            while (profanityService.ContainsProfanity(token) || db.Customers.Any(x => x.UrlToken == token));

            UrlToken = token.ToString();
        }
    }
}