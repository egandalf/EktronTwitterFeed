using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Text;
using Ektron.Com.Twitter.Objects;
using System.Net;
using System.Web.Script.Serialization;

namespace Ektron.Com.Twitter
{
    /// <summary>
    /// Summary description for Methods
    /// </summary>
    public class TwitterFeedManager
    {
        private JavaScriptSerializer _jser = null;
        private JavaScriptSerializer jser
        {
            get
            {
                if (_jser == null)
                    _jser = new JavaScriptSerializer();
                return _jser;
            }
        }

        public TwitterFeedManager() { }

        public string GetCredentials()
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");
            TwitterSettings settings = (TwitterSettings)config.GetSection("TwitterSettings");
            string EncodedAPIKey = HttpUtility.UrlEncode(settings.APIKey);
            string EncodedAPISecret = HttpUtility.UrlEncode(settings.APISecret);
            string MergedCredentials = string.Format("{0}:{1}", EncodedAPIKey, EncodedAPISecret);
            var MergedCredendialBytes = Encoding.Default.GetBytes(MergedCredentials);
            string EncodedMergedCredentials = Convert.ToBase64String(MergedCredendialBytes);
            return EncodedMergedCredentials;
        }

        public TwitterToken GetBearerToken()
        {
            string Credentials = GetCredentials();
            TwitterToken token = null;
            using (var client = new WebClient())
            {
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded;charset=UTF-8";
                client.Headers["Authorization"] = string.Format("Basic {0}", Credentials);
                try
                {
                    var response = client.UploadString("https://api.twitter.com/oauth2/token", "grant_type=client_credentials");
                    token = jser.Deserialize<TwitterToken>(response);
                }
                catch (Exception ex)
                {

                }
            }
            return token;
        }

        public List<Tweet> GetTwitterFeed(TwitterUserTimelineRequest request)
        {
            if (request.Token == null)
            {
                TwitterToken authToken = null;
                /*
                 * This uses my own caching solution, which is not part of this package. 
                 * I highly recommend you find some storage solution for the bearer token,
                 * which allows you to access the Twitter APIs.
                 * 
                 * For the actual Tweets, I implement similar caching within the Control.
                 */
                //Caches.TwitterTokenObjectCache.TryGetAndSet("TwitterAuthToken", () => GetBearerToken(), out authToken, new System.Runtime.Caching.CacheItemPolicy() { SlidingExpiration = new TimeSpan(1, 0, 0) });
                authToken = GetBearerToken();
                request.Token = authToken;
            }
            List<Tweet> response = null;
            if (request.Token != null && !string.IsNullOrEmpty(request.Token.access_token))
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        client.Headers["Authorization"] = string.Format("Bearer {0}", request.Token.access_token);
                        client.QueryString["count"] = request.Count.ToString();
                        client.QueryString["screen_name"] = request.ScreenName;
                        client.QueryString["trim_user"] = (!request.ReturnCompleteUserData).ToString().ToLower();
                        client.QueryString["exclude_replies"] = request.ExcludeReplies.ToString().ToLower();
                        string twitterDownload = client.DownloadString(request.APIUrl);
                        response = jser.Deserialize<List<Tweet>>(twitterDownload);
                    }
                }
                catch (Exception ex)
                {
                    Ektron.Cms.EkException.LogException(ex);
                }
            }
            return response;
        }
    }
}