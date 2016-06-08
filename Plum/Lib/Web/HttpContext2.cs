using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plum.Web
{
    public static class HttpContext2
    {
        private static HttpContextBase _context = null;

        public static HttpContextBase Current
        {
            get
            {
                return _context ?? new HttpContextWrapper(HttpContext.Current);
            }
            set
            {
                _context = value;
            }
        }
    }
}