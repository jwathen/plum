using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace Plum.Services
{
    public class ProfanityFilter
    {
        private string _dataFilePath;

        public ProfanityFilter(string dataFilePath = null)
        {
            _dataFilePath = dataFilePath ?? HostingEnvironment.MapPath("~/App_Data/Profanity.txt");
        }

        public bool ContainsProfanity(string input)
        {
            input = input.Replace('1', 'l');
            input = input.Replace('3', 'e');
            input = input.Replace('4', 'a');
            input = input.Replace('5', 's');
            input = input.Replace('7', 't');
            input = input.Replace('8', 'b');
            input = input.Replace('9', 'g');
            input = input.Replace('0', 'o');

            List<string> profanity = (List<string>)HttpRuntime.Cache["Profanity.txt"];
            if (profanity == null)
            {
                profanity = new List<string>(File.ReadAllLines(_dataFilePath));
                HttpRuntime.Cache.Insert("Profanity.txt", profanity, new CacheDependency(_dataFilePath));
            }

            bool containsProfanity = profanity.Any(x => input.Contains(x));
            return containsProfanity;
        }
    }
}