using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaitlistApp.Models.Annotations
{
    public interface IDatedEntity
    {
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
    }
}