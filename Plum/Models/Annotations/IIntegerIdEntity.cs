﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plum.Models.Annotations
{
    public interface IIntegerIdEntity
    {
        int Id { get; set; }
    }
}