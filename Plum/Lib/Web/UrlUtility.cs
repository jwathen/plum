using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace Plum.Web
{
    public static class UrlUtility
    {
        public static string FileVersionUrl(string rootRelativePath)
        {
            if (HttpRuntime.Cache[rootRelativePath] == null)
            {
                string filePath = HostingEnvironment.MapPath("~" + rootRelativePath);
                if (File.Exists(filePath))
                {
                    BigInteger fileHash = 0;
                    using (var md5 = MD5.Create())
                    {
                        using (var fileStream = File.OpenRead(filePath))
                        {
                            fileHash = new BigInteger(md5.ComputeHash(fileStream));
                        }
                    }

                    int index = rootRelativePath.LastIndexOf('/');
                    string result = rootRelativePath.Insert(index, "/v-" + fileHash);
                    HttpRuntime.Cache.Insert(rootRelativePath, result, new CacheDependency(filePath));
                }
            }

            return HttpRuntime.Cache[rootRelativePath] as string;
        }
    }
}