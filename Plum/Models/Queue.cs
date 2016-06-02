using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plum.Models
{
    public class Queue
    {
        public virtual int Id { get; set; }
        public virtual int BusinessId { get; set; }
        public virtual string Name { get; set; }

        public virtual Business Business { get; set; }
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

        public IEnumerable<Customer> OrderedCustomers()
        {
            return Customers.OrderBy(x => x.SortOrder)
                .ThenBy(x => x.DateAdded);
        }

        public int NumberOfPartiesAheadOf(Customer customer)
        {
            return OrderedCustomers()
                .TakeWhile(x => x != customer)
                .Count();
        }
    }
}