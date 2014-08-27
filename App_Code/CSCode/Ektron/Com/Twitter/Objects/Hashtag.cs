using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ektron.Com.Twitter.Objects
{
    /// <summary>
    /// Summary description for Hashtag
    /// </summary>
    public class Hashtag
    {
        public string text { get; set; }
        public List<int> indices { get; set; }
        public Hashtag(){ }
    }
}