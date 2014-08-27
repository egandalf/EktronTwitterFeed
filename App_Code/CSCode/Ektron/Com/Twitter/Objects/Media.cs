using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ektron.Com.Twitter.Objects 
{
	/// <summary>
	/// Summary description for Media
	/// </summary>
	public class Media
	{
		public long id { get; set; }
		public string id_str { get; set; }
		public List<int> indices { get; set; }
		public string media_url { get; set; }
		public string media_url_https { get; set; }
		public string url { get; set; }
		public string display_url { get; set; }
		public string expanded_url { get; set; }
		public string type { get; set; }
		public MediaSizes sizes { get; set; }
		public long source_status_id { get; set; }
		public string source_status_id_str { get; set; }
		public Media(){}
	}
}