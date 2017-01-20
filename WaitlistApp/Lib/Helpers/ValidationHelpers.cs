using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaitlistApp.Helpers
{
    public static class ValidationHelpers
    {
        public static bool BeA10DigitPhoneNumber(string input)
        {
            return input
                .Replace("(", string.Empty)
                .Replace(")", string.Empty)
                .Replace("-", string.Empty)
                .Replace("#", string.Empty)
                .Count(x => char.IsDigit(x)) == 10;
        }
    }
}