using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ektron.Com.Twitter.Objects
{
    /// <summary>
    /// Summary description for User
    /// </summary>
    public class User
    {
		public long id { get; set; }
		public string id_str { get; set; }
		public string name { get; set; }
		public string screen_name { get; set; }
		public string location { get; set; }
		public string description { get; set; }
		public string url { get; set; }
		public UserEntities entities { get; set; }
		public bool @protected { get; set; }
		public long followers_count { get; set; }
		public long friends_count { get; set; }
		public long listed_count { get; set; }
		public string created_at { get; set; }
		public long favourites_count { get; set; }
		public int? utc_offset { get; set; }
		public string time_zone { get; set; }
		public bool geo_enabled { get; set; }
		public bool verified { get; set; }
		public long statuses_count { get; set; }
		public string lang { get; set; }
		public bool contributors_enabled { get; set; }
		public bool is_translator { get; set; }
		public bool is_translation_enabled { get; set; }
		public string profile_background_color { get; set; }
		public string profile_background_image_url { get; set; }
		public string profile_background_image_url_https { get; set; }
		public bool profile_background_tile { get; set; }
		public string profile_image_url { get; set; }
		public string profile_image_url_https { get; set; }
		public string profile_banner_url { get; set; }
		public string profile_link_color { get; set; }
		public string profile_sidebar_border_color { get; set; }
		public string profile_sidebar_fill_color { get; set; }
		public string profile_text_color { get; set; }
		public bool profile_use_background_image { get; set; }
		public bool default_profile { get; set; }
		public bool default_profile_image { get; set; }
        public User(){}
    }
}