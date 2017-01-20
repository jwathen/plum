using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaitlistApp.Services
{
    public class PlivoException : Exception
    {
        public PlivoException(string errorMessage)
            : base(errorMessage)
        {

        }
    }
}