using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ektron.Com.Twitter.Objects
{
    /// <summary>
    /// Summary description for TwitterUserTimelineRequest
    /// </summary>
    public class TwitterUserTimelineRequest
    {
		public string APIUrl { get; set; }
		public TwitterToken Token { get; set; }
		public int Count { get; set; }
		public string ScreenName { get; set; }
		public bool ReturnCompleteUserData { get; set; }
		public bool ExcludeReplies { get; set; }

        public TwitterUserTimelineRequest(TwitterToken token)
        {
            Token = token;
            ReturnCompleteUserData = false;
            ExcludeReplies = false;
            APIUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json";
        }
        public TwitterUserTimelineRequest()
        {
            Token = null;
            ReturnCompleteUserData = false;
            ExcludeReplies = false;
            APIUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json";
        }
    }
}