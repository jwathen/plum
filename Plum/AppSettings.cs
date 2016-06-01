using System.Configuration;

namespace Plum
{
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute]
    public static class AppSettings
    {
        public static string ApplicationName
        {
            get { return ConfigurationManager.AppSettings["ApplicationName"]; }
        }

        public static string ClientValidationEnabled
        {
            get { return ConfigurationManager.AppSettings["ClientValidationEnabled"]; }
        }

        public static string ReleaseProfile
        {
            get { return ConfigurationManager.AppSettings["ReleaseProfile"]; }
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

