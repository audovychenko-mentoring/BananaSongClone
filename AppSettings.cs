using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;

namespace BananaSongClone
{
    public class AppSettings
    {
        private static NameValueCollection Settings => ConfigurationManager.GetSection("Settings") as NameValueCollection;

        public static string Url => Settings["Url"];
    }
}
