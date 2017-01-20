using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaitlistApp.Models.Annotations
{
    public interface ISoftDeleteEntity
    {
        DateTime? DateDeleted { get; set; }
        string TableName { get; }
        string PrimaryKeyName { get; }
    }
}