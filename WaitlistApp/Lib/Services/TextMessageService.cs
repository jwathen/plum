using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using WaitlistApp.Lib.Services;
using WaitlistApp.Services;

namespace WaitlistApp.Services
{
    public class TextMessageService
    {
        private readonly AppSecrets _secrets;

        public TextMessageService(AppSecrets secrets)
        {
            _secrets = secrets;
        }

        public List<SentTextMessage> SentMessages { get; set; } = new List<SentTextMessage>();

        public async Task SendAsync(string destination, string message)
        {
            if (destination.Length == 10)
            {
                destination = "1" + destination;
            }

            string basicAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_secrets.PlivoAuthId}:{_secrets.PlivoAuthToken}"));
            string requestUri = $"https://api.plivo.com/v1/Account/{_secrets.PlivoAuthId}/Message/";

            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicAuth);

                var parameters = new Dictionary<string, string>();
                parameters["src"] = AppSettings.App.TextMessaging.PlivoPhoneNumber;
                parameters["dst"] = destination;
                parameters["text"] = message;

                bool testMode = bool.Parse(AppSettings.App.TextMessaging.IsTest);
                if (testMode)
                {
                    SentMessages.Add(new SentTextMessage
                    {
                        Destination = destination,
                        Message = message
                    });
                }
                else
                {
                    var response = await http.PostAsJsonAsync(requestUri, parameters);
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        var ex = new PlivoException(errorMessage);
                        Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                    }
                }
            }
        }
    }
}