using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaitlistApp.Models;
using Should;

namespace WaitlistApp.Tests.Unit.Models
{
    public class AccountTests
    {
        public void CreateAndValidatePassword()
        {
            string password = "passw0rd";
            var account = Account.Create("john@site.com", password);

            account.VerifyPassword(password).ShouldBeTrue();
            account.VerifyPassword("incorrect password").ShouldBeFalse();
        }
    }
}
