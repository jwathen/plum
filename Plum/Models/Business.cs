using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plum.Models
{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Account Account { get; set; }
    }
}