using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Web;

namespace CoffeeShop.Components
{
    public class Utilities
    {
        

        public class Views
        {
            public static string BuildRegistry()
            {
                var registry = new Dictionary<string, string>();
                string virtualPath = "Client";

                var md5 = MD5.Create();

                var dir = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/" + virtualPath));
                foreach (var file in dir.GetFiles("*.html", SearchOption.AllDirectories))
                {
                    string virtual_file = GetVirtualPath(file, virtualPath);
                    using (var fs = File.OpenRead(file.FullName))
                    {
                        string version = HttpServerUtility.UrlTokenEncode(md5.ComputeHash(fs));
                        registry.Add(String.Format("\"{0}\"", virtual_file), version);
                    }
                }

                return Newtonsoft.Json.JsonConvert.SerializeObject(registry);
            }

            private static string GetVirtualPath(FileInfo file, string virtualPath)
            {
                string absolute_virtual = file.FullName.Replace("\\", "/");
                string relative_virtual = absolute_virtual.Substring(absolute_virtual.IndexOf(virtualPath));

                return relative_virtual;
            }
        }

        
    }
}