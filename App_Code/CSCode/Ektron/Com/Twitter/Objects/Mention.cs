using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ektron.Com.Twitter.Objects
{
    /// <summary>
    /// Summary description for Mention
    /// </summary>
    public class Mention
    {
		public string screen_name { get; set; }
		public string name { get; set; }
		public long id { get; set; }
		public long id_str { get; set; }
		public List<int> indices { get; set; }
        public Mention(){}
    }
}