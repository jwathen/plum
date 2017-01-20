using Plum.Models.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plum.Models
{
    public class Brand : IDatedEntity, IIntegerIdEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Name { get; set; }
        public virtual string BrandColor { get; set; }
        public virtual string JumboColor { get; set; }
        public virtual byte[] JumboImage { get; set; }
        public virtual string FontUrl { get; set; }
        public virtual string FontName { get; set; }
        public virtual string DomainNames { get; set; }
    }
}