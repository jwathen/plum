using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plum.Services;

namespace Plum.Models
{
    public class Queue : IDatedEntity, IIntegerIdEntity
    {
        public virtual int Id { get; set; }
        public virtual int BusinessId { get; set; }
        public virtual string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual Business Business { get; set; }
        public virtual HashSet<Customer> Customers { get; set; } = new HashSet<Customer>();

        public IEnumerable<Customer> OrderedCustomers()
        {
            return Customers.OrderBy(x => x.SortOrder)
                .ThenBy(x => x.DateCreated);
        }

        public int NumberOfPartiesAheadOf(Customer customer)
        {
            return OrderedCustomers()
                .TakeWhile(x => x != customer)
                .Count();
        }

        public void AddCustomer(Customer customer, UrlHelper url, AppSecrets secrets)
        {
            this.Customers.Add(customer);
            customer.Queue = this;
            customer.SendWelcomeTextMessage(url, secrets);
        }

        public void MoveCustomerToEndOfList(Customer customer)
        {
            var orderedCustomers = OrderedCustomers().ToList();
            orderedCustomers.Remove(customer);
            orderedCustomers.Add(customer);
            
            for(short i = 0; i < orderedCustomers.Count; i++)
            {
                orderedCustomers[i].SortOrder = (short)(i - 1);
            }

            customer.Log(CustomerLogEntryType.MovedToEndOfList, "Moved to end of list.");
        }
    }
}