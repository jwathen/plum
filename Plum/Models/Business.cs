using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plum.Models
{
    public class Business
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Account Account { get; set; }

        public virtual ICollection<Queue> Queues { get; set; } = new List<Queue>();
    }
}