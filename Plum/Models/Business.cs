using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plum.Models
{
    public class Business : IDatedEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        public virtual Account Account { get; set; }

        public virtual HashSet<Queue> Queues { get; set; } = new HashSet<Queue>();
    }
}