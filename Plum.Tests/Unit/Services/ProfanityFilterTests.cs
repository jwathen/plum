using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plum.Models;
using Plum.Services;
using Should;

namespace Plum.Tests.Unit.Services
{
    public class ProfanityFilterTests
    {
        private ProfanityFilter _profanityService;

        public ProfanityFilterTests()
        {
            string dataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/Profanity.txt");
            _profanityService = new ProfanityFilter(dataFilePath);
        }

        public void ContainsProfanity_GivenCleanWord_ReturnsFalse()
        {
            _profanityService.ContainsProfanity("clean").ShouldBeFalse();
        }

        public void ContainsProfanity_GivenProfaneWord_Returnstrue()
        {
            _profanityService.ContainsProfanity("adamnb").ShouldBeTrue();
        }

        public void ContainsProfanity_GivenProfaneWordWithNumbers_Returnstrue()
        {
            _profanityService.ContainsProfanity("ad4mnb").ShouldBeTrue();
        }
    }
}
