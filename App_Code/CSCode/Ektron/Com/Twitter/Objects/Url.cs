using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ektron.Com.Twitter.Objects
{
    /// <summary>
    /// Summary description for Url
    /// </summary>
    public class Url
    {
		public string url { get; set; }
		public string expanded_url { get; set; }
		public string display_url { get; set; }
		public List<int> indices { get; set; }
        public Url(){}
    }
}