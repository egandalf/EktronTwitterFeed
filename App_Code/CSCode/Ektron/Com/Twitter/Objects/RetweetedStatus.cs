using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ektron.Com.Twitter.Objects
{
    /// <summary>
    /// Summary description for RetweetedStatus
    /// </summary>
    public class RetweetedStatus : Tweet
    {
		public bool possibly_sensitive { get; set; }
        public RetweetedStatus(){}
    }
}