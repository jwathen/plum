using System.Configuration;

namespace Plum
{
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute]
    public static class AppSettings
    {
        public static class App
        {
            public static class QuotedWaitTimeOptions
            {
                public static string End
                {
                    get { return ConfigurationManager.AppSettings["App:QuotedWaitTimeOptions:End"]; }
                }

                public static string Increment
                {
                    get { return ConfigurationManager.AppSettings["App:QuotedWaitTimeOptions:Increment"]; }
                }

                public static string Start
                {
                    get { return ConfigurationManager.AppSettings["App:QuotedWaitTimeOptions:Start"]; }
                }
            }
        }

        public static string ApplicationName
        {
            get { return ConfigurationManager.AppSettings["ApplicationName"]; }
        }

        public static string ClientValidationEnabled
        {
            get { return ConfigurationManager.AppSettings["ClientValidationEnabled"]; }
        }

        public static class Elmah
        {
            public static class Mvc
            {
                public static string AllowedUsers
                {
                    get { return ConfigurationManager.AppSettings["elmah.mvc.allowedUsers"]; }
                }

                public static string RequiresAuthentication
                {
                    get { return ConfigurationManager.AppSettings["elmah.mvc.requiresAuthentication"]; }
                }

                public static string Route
                {
                    get { return ConfigurationManager.AppSettings["elmah.mvc.route"]; }
                }
            }
        }

        public static string ReleaseProfile
        {
            get { return ConfigurationManager.AppSettings["ReleaseProfile"]; }
        }

        public static string TwilioPhoneNumber
        {
            get { return ConfigurationManager.AppSettings["TwilioPhoneNumber"]; }
        }

        public static string UnobtrusiveJavaScriptEnabled
        {
            get { return ConfigurationManager.AppSettings["UnobtrusiveJavaScriptEnabled"]; }
        }

        public static string UsePhysicalViewsIfNewer
        {
            get { return ConfigurationManager.AppSettings["UsePhysicalViewsIfNewer"]; }
        }

        public static string Version
        {
            get { return ConfigurationManager.AppSettings["Version"]; }
        }

        public static class Vs
        {
            public static string EnableBrowserLink
            {
                get { return ConfigurationManager.AppSettings["vs:EnableBrowserLink"]; }
            }
        }

        public static class Webpages
        {
            public static string Enabled
            {
                get { return ConfigurationManager.AppSettings["webpages:Enabled"]; }
            }

            public static string Version
            {
                get { return ConfigurationManager.AppSettings["webpages:Version"]; }
            }
        }
    }
}

