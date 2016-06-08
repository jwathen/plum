using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using Plum.Services;

namespace Plum.Services
{
    public class EmailService
    {
        private readonly AppSecrets _secrets;

        public EmailService(AppSecrets secrets)
        {
            _secrets = secrets;
        }

        public List<MailMessage> SentMessages { get; set; } = new List<MailMessage>();

        public void Send(string from, string to, string subject, string body, bool isBodyHtml = true)
        {
            using (var smtp = new SmtpClient("smtp.sendgrid.net", 587))
            {
                smtp.Credentials = new NetworkCredential(_secrets.SendGridUserName, _secrets.SendGridPassword);

                var mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = isBodyHtml;

                bool isTest = bool.Parse(AppSettings.App.Email.IsTest);
                if (isTest)
                {
                    SentMessages.Add(mail);
                }
                else
                {
                    smtp.Send(mail);
                }
            }
        }
    }
}