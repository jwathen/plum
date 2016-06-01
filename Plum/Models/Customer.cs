using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

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
            return DateTime.UtcNow.Subtract(DateAdded);
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
            char[] characters = "abcdefghijklmnopqrstuvwxyz".ToArray();
            var random = new Random();

            do
            {
                token = string.Empty;
                while (token.Length < 8)
                {
                    token += characters[random.Next(0, characters.Length - 1)];
                }
            }
            while (db.Customers.Any(x => x.UrlToken == token));

            UrlToken = token.ToString();
        }
    }
}