using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ektron.Com.Twitter.Objects
{
    /// <summary>
    /// Summary description for TwitterToken
    /// </summary>
    public class TwitterToken
    {
		public string access_token { get; set; }
		public string token_type { get; set; }
        public TwitterToken(){}
    }
}