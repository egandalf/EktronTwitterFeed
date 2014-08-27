using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ektron.Com.Twitter.Objects
{
    /// <summary>
    /// Summary description for TweetEntities
    /// </summary>
    public class TweetEntities
    {
		public List<Mention> user_mentions { get; set; }
		public List<Url> urls { get; set; }
		public List<Hashtag> hashtags { get; set; }
        public List<Media> media { get; set; }
        public TweetEntities(){}
    }
}