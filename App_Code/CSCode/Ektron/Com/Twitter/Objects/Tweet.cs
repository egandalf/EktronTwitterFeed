using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ektron.Com.Twitter.Objects
{
    /// <summary>
    /// Summary description for Tweet
    /// </summary>
    public class Tweet
    {
		public string created_at { get; set; }
		public long id { get; set; }
		public string id_str { get; set; }
		public string text { get; set; }
		public string source { get; set; }
		public bool truncated { get; set; }
		public long? in_reply_to_status_id { get; set; }
		public string in_reply_to_status_id_str { get; set; }
		public long? in_reply_to_user_id { get; set; }
		public string in_reply_to_user_id_str { get; set; }
		public string in_reply_to_screen_name { get; set; }
		public User user { get; set; }
		public int retweet_count { get; set; }
		public int favorite_count { get; set; }
		public TweetEntities entities { get; set; }
		public bool favorited { get; set; }
		public bool retweeted { get; set; }
		public string lang { get; set; }
		public RetweetedStatus retweeted_status { get; set; }
        public Tweet(){}

        public string ToHtmlString()
        {
            return ToHtmlString(false);
        }

        public string ToHtmlString(bool UseOriginalTweet) {
            string unalteredText = (UseOriginalTweet && this.retweeted_status != null) ? this.retweeted_status.text : this.text;
            string markup = unalteredText;
            var entityObject = (UseOriginalTweet && this.retweeted_status != null) ? this.retweeted_status.entities : this.entities;
            string textToReplace = string.Empty;
            foreach (var url in entityObject.urls)
            {
                textToReplace = GetSubString(unalteredText, url.indices);
                markup = markup.Replace(textToReplace, string.Format("<a href=\"{0}\" target=\"_blank\">{1}</a>", url.url, textToReplace));
            }
            foreach (var hashtag in entityObject.hashtags)
            {
                textToReplace = GetSubString(unalteredText, hashtag.indices);
                markup = markup.Replace(textToReplace, string.Format("<a href=\"https://twitter.com/hashtag/{0}\" target=\"_blank\">{1}</a>", hashtag.text, textToReplace));
            }
            foreach (var mention in entityObject.user_mentions)
            {
                textToReplace = GetSubString(unalteredText, mention.indices);
                markup = markup.Replace(textToReplace, string.Format("<a href=\"https://twitter.com/{0}\" target=\"_blank\">{1}</a>", mention.screen_name, textToReplace));
            }
            if (entityObject.media != null)
            {
                foreach (var media in entityObject.media)
                {
                    textToReplace = GetSubString(unalteredText, media.indices);
                    markup = markup.Replace(textToReplace, string.Format("<a href=\"{0}\" target=\"_blank\">{1}</a>", media.url, textToReplace));
                }
            }
            markup = markup.Replace("\n", "<br />");
            return markup;
        }

        private string GetSubString(string text, List<int> indices)
        {
            return text.Substring(indices[0], indices[1] - indices[0]);
        }
    }
}