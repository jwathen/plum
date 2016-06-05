using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plum.Models
{
    public interface IDatedEntity
    {
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
    }
}