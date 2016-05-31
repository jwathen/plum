using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleCrypto;

namespace Plum.Models
{
    public class Account
    {
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public bool VerifyPassword(string candidatePassword)
        {
            PBKDF2 crypto = new PBKDF2();
            crypto.Salt = PasswordSalt;
            crypto.HashIterations = int.Parse(PasswordSalt.Split('.')[0]);
            string candidatePasswordHash = crypto.Compute(candidatePassword);
            return crypto.Compare(candidatePasswordHash, PasswordHash);
        }

        public static Account Create(string emailAddress, string password)
        {
            PBKDF2 crypto = new PBKDF2();
            crypto.HashIterations = 20000;

            Account account = new Account();
            account.EmailAddress = emailAddress;
            account.PasswordSalt = crypto.GenerateSalt();
            account.PasswordHash = crypto.Compute(password);
            
            return account;
        }
    }
}