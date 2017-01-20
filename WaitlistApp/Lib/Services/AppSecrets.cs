using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WaitlistApp.Services
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
                AppSettingsOverride("PlivoAuthId");
                AppSettingsOverride("PlivoAuthToken");
                AppSettingsOverride("PlivoIncomingSmsRoute");
                AppSettingsOverride("SendGridUserName");
                AppSettingsOverride("SendGridPassword");
            }
        }

        private void AppSettingsOverride(string key)
        {
            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings[key]))
            {
                _secrets[key] = ConfigurationManager.AppSettings[key];
            }
        }

        private T GetSecret<T>(string key)
        {
            Init();
            return (T)_secrets[key];
        }

        public string PlivoAuthId
        {
            get
            {
                return GetSecret<string>("PlivoAuthId");
            }
        }

        public string PlivoAuthToken
        {
            get
            {
                return GetSecret<string>("PlivoAuthToken");
            }
        }

        public string PlivoIncomingSmsRoute
        {
            get
            {
                return GetSecret<string>("PlivoIncomingSmsRoute");
            }
        }

        public string SendGridUserName
        {
            get
            {
                return GetSecret<string>("SendGridUserName");
            }
        }

        public string SendGridPassword
        {
            get
            {
                return GetSecret<string>("SendGridPassword");
            }
        }
    }
}