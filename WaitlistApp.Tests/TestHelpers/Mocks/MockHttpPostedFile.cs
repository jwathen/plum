using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WaitlistApp.Tests.TestHelpers.Mocks
{
    public class MockHttpPostedFile : HttpPostedFileBase
    {
        private int _contentLength;
        private string _contentType;
        private string _filePath;
        private string _fileName;

        public MockHttpPostedFile()
        {
            _contentLength = 0;
        }

        public MockHttpPostedFile(string filePath, string contentType)
        {
            _filePath = filePath;
            _contentType = contentType;
            _fileName = Path.GetFileName(_filePath);
            using (var stream = File.OpenRead(_filePath))
            {
                _contentLength = (int)stream.Length;
            }
        }

        public override int ContentLength
        {
            get
            {
                return _contentLength;
            }
        }

        public override string ContentType
        {
            get
            {
                return _contentType;
            }
        }

        public override Stream InputStream
        {
            get
            {
                return File.OpenRead(_filePath);
            }
        }

        public override string FileName
        {
            get
            {
                return _fileName;
            }
        }
    }
}
