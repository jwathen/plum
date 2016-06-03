using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Plum.Services
{
    public class AppSecrets
    {
        private readonly string _dataFilePath;
        private Dictionary<string, object> _secrets = null;

        public AppSecrets(string dataFilePath)
        {
            _dataFilePath = dataFilePath;
        }

        private void Init()
        {
            if (_secrets == null)
            {
                string dataFile = File.ReadAllText(_dataFilePath);
                _secrets = JsonConvert.DeserializeObject<Dictionary<string, object>>(dataFile);

                // Override with app settings if they exist.
                if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["TwilioAccountSid"]))
                {
                    _secrets["TwilioAccountSid"] = ConfigurationManager.AppSettings["TwilioAccountSid"];
                }
                if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["TwilioAuthToken"]))
                {
                    _secrets["TwilioAuthToken"] = ConfigurationManager.AppSettings["TwilioAuthToken"];
                }
            }
        }

        public string TwilioAccountSid
        {
            get
            {
                Init();
                return (string)_secrets["TwilioAccountSid"];
            }
        }

        public string TwilioAuthToken
        {
            get
            {
                Init();
                return (string)_secrets["TwilioAuthToken"];
            }
        }
    }
}