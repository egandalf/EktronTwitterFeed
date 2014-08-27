using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Ektron.Com.Twitter
{
    /// <summary>
    /// Summary description for Config
    /// </summary>
    public class TwitterSettings : ConfigurationSection
    {
        [ConfigurationProperty("APIKey", IsRequired = true)]
        public string APIKey
        {
            get { return (string)base["APIKey"]; }
            set { base["APIKey"] = value; }
        }

        [ConfigurationProperty("APISecret", IsRequired = true)]
        public string APISecret
        {
            get { return (string)base["APISecret"]; }
            set { base["APISecret"] = value; }
        }
    }
}