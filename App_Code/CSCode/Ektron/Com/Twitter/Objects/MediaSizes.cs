using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ektron.Com.Twitter.Objects 
{
	/// <summary>
	/// Summary description for MediaSizes
	/// </summary>
	public class MediaSizes
	{
		public MediaSize medium { get; set; }
		public MediaSize large { get; set; }
		public MediaSize thumb { get; set; }
		public MediaSize small { get; set; }
		public MediaSizes(){}
	}
}