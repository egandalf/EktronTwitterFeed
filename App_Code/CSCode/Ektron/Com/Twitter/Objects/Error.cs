using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ektron.Com.Twitter.Objects
{
    /// <summary>
    /// Summary description for Error
    /// </summary>
    public class Error
    {
        public int code { get; set; }
        public string label { get; set; }
        public string message { get; set; }
        public Error(){}
    }
}