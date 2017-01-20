using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WaitlistApp.Tests.TestHelpers.Mocks
{
    public class MockHttpResponse : HttpResponseBase
    {
        private int _statusCode = 0;
        private string _statusDescription = null;
        private NameValueCollection _headers = new NameValueCollection();
        private HttpCookieCollection _cookies = new HttpCookieCollection();
        private StringBuilder _output = new StringBuilder();
        private TextWriter _outputWriter = null;
        private string _contentType;
        private Stream _outputStream = new MemoryStream();

        public override void AddHeader(string name, string value)
        {
            // Do nothing  
        }

        public override void Clear()
        {
            // Do nothing
        }

        public override void Close()
        {
            // Do nothing
        }
        public override void End()
        {
            // Do nothing
        }

        public override void BinaryWrite(byte[] buffer)
        {
            // Do nothing
        }

        public override void Flush()
        {
            // Do nothing
        }

        public override Stream OutputStream
        {
            get
            {
                return _outputStream;   
            }
        }

        public override int StatusCode
        {
            get
            {
                return _statusCode;
            }
            set
            {
                _statusCode = value;
            }
        }

        public override string StatusDescription
        {
            get
            {
                return _statusDescription;
            }

            set
            {
                _statusDescription = value;
            }
        }

        public override NameValueCollection Headers
        {
            get
            {
                return _headers;
            }
        }

        public override HttpCookieCollection Cookies
        {
            get
            {
                return _cookies;
            }
        }

        public override TextWriter Output
        {
            get
            {
                if (_outputWriter == null)
                {
                    _outputWriter = new StringWriter(_output);
                }
                return _outputWriter;
            }
            set
            {
                _outputWriter = value;
            }
        }

        public override string ApplyAppPathModifier(string virtualPath)
        {
            return virtualPath.Replace("~/", "/");
        }

        public string OutputHtml
        {
            get
            {
                return _output.ToString();
            }
        }


        public override string ContentType
        {
            get
            {
                return _contentType;
            }
            set
            {
                 _contentType = value;
            }
        }
    }
}
