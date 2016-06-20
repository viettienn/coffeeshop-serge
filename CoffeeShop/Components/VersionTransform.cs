using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Optimization;

namespace CoffeeShop.Components
{
    public class VersionTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            var md5 = MD5.Create();
            var server = context.HttpContext.Server;
            foreach (var file in response.Files)
            {
                using (var fs = File.OpenRead(server.MapPath(file.IncludedVirtualPath)))
                {
                    string version = server.UrlTokenEncode(md5.ComputeHash(fs));
                    file.IncludedVirtualPath = String.Format("{0}?v={1}", file.IncludedVirtualPath, version);
                }
            }
        }
    }
}