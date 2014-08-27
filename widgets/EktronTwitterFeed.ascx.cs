using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Ektron.Cms.Widget;
using Ektron.Cms;
using Ektron.Cms.Common;
using Ektron.Cms.PageBuilder;
using Ektron.Cms.Framework.UI;
using System.Configuration;
using System.Collections.Generic;
using Ektron.Com;
using System.Linq;


public partial class widgets_EktronTwitterFeed : System.Web.UI.UserControl, IWidget
{
    #region properties
    [WidgetDataMember("")]
    public string Heading { get; set; }
    [WidgetDataMember("")]
    public string ScreenName { get; set; }
    [WidgetDataMember(false)]
    public bool ExcludeReplies { get; set; }
    [WidgetDataMember(0)]
    public int NumberToRetrieve { get; set; }
    [WidgetDataMember(0)]
    public int NumberToShow { get; set; }
    #endregion

    #region declarations
    private IWidgetHost _host;
    private PageBuilder _page = null;
    #endregion declarations

    #region singleton
    private CommonApi _commonAPI = null;
    private CommonApi CommonAPI
    {
        get
        {
            if (_commonAPI == null)
                _commonAPI = new CommonApi();
            return _commonAPI;
        }
    }
    private string _sitePath = string.Empty;
    private string SitePath
    {
        get
        {
            if (string.IsNullOrEmpty(_sitePath))
                _sitePath = CommonAPI.SitePath;
            return _sitePath;
        }
    }
    #endregion singleton

    #region constructor
    /// <summary>
    /// Sets default values when used as a user control rather than widget.
    /// </summary>
    public widgets_EktronTwitterFeed()
    {
        this.ScreenName = string.Empty;
        this.ExcludeReplies = false;
        this.NumberToRetrieve = 0;
        this.NumberToShow = 0;
    }
    #endregion constructor

    #region page events
    protected void Page_Init(object sender, EventArgs e)
    {   
        string sitepath = new CommonApi().SitePath;
        try
        {
            _host = Ektron.Cms.Widget.WidgetHost.GetHost(this);
            if (_host != null) // this check allows the widget to be used as a user control
            {
                _page = Page as PageBuilder;
                _host.Title = "Ektron Twitter Feed";
                _host.Edit += new EditDelegate(EditEvent);
                _host.Maximize += new MaximizeDelegate(delegate() { Visible = true; });
                _host.Minimize += new MinimizeDelegate(delegate() { Visible = false; });
                _host.Create += new CreateDelegate(delegate() { EditEvent(""); });
            }
        }
        catch (Exception ex)
        {
            // do nothing - error arises from using widget as control in pagebuilder page
            //EkException.LogException(ex, System.Diagnostics.EventLogEntryType.Error);
        }
        ViewSet.SetActiveView(View);
    }
    protected override void OnPreRender(EventArgs e)
    {
        SetJS();
        if (NumberToRetrieve > 0 && NumberToShow > 0 && !string.IsNullOrWhiteSpace(ScreenName))
        {
            var TwitterManager = new Ektron.Com.Twitter.TwitterFeedManager();
            var Request = new Ektron.Com.Twitter.Objects.TwitterUserTimelineRequest()
            {
                Count = NumberToRetrieve,
                ReturnCompleteUserData = true,
                ExcludeReplies = ExcludeReplies,
                ScreenName = ScreenName
            };
            var Tweets = new List<Ektron.Com.Twitter.Objects.Tweet>();
            /*
             * This uses my own caching solution, which is not part of this package. 
             * I highly recommend you find some caching solution for the tweets
             * in order to reduce API call latency.
             * 
             * For the Twitter Token, I implement similar caching within the TwitterFeedManager.
             */
            //Caches.TwitterFeedObjectCache.TryGetAndSet("TwitterFeed:" + ScreenName, () => TwitterManager.GetTwitterFeed(Request), out Tweets);
            Tweets = TwitterManager.GetTwitterFeed(Request);
            if (Tweets.Any())
            {
                this.uxHeadingText.Text = Heading;
                if (Tweets.Count > NumberToShow)
                {
                    Tweets = Tweets.Take(NumberToShow).ToList();
                }
                uxTweets.DataSource = Tweets;
                uxTweets.DataBind();
            }
            else
            {
                if (_page != null && _page.Status != Mode.Editing)
                {
                    this.Visible = false;
                }
            }
        }
        else if (_page != null && _page.Status == Mode.Editing)
        {
            uxOutput.Text = "Edit the widget to configure the Twitter feed.";
        }
    }
    #endregion page events

    #region widget edit events
    void EditEvent(string settings)
    {
        uxHeading.Text = Heading;
        uxScreenName.Text = ScreenName;
        uxExcludeReplies.Checked = ExcludeReplies;
        uxNumberToRetrieve.Text = NumberToRetrieve.ToString();
        uxNumberToShow.Text = NumberToShow.ToString();
        ViewSet.SetActiveView(Edit);
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        Page.Validate("TwitterFeed");
        if (Page.IsValid)
        {
            Heading = uxHeading.Text;
            ScreenName = uxScreenName.Text;
            ExcludeReplies = uxExcludeReplies.Checked;
            NumberToRetrieve = int.Parse(uxNumberToRetrieve.Text);
            NumberToShow = int.Parse(uxNumberToShow.Text);
            _host.SaveWidgetDataMembers();
            ViewSet.SetActiveView(View);
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        ViewSet.SetActiveView(View);
    }
    #endregion widget edit events

    #region private helpers
    private void SetJS()
    {
        if (ViewSet.GetActiveView() == Edit)
        {
            JavaScript.Register(this, SitePath + "widgets/EktronTwitterFeed/js/EditUI.js");
            Css.Register(this, SitePath + "widgets/EktronTwitterFeed/css/EditUI.css");
            
            string settings = "{" + 
                "ContainerID:'" + this.ClientID + "_edit'" + 
            "}";
            JavaScript.RegisterJavaScriptBlock(this, "Ektron.PFWidgets.EktronTwitterFeed_Edit.init(" + settings + ");");
        }
        else
        {
            JavaScript.Register(this, SitePath + "widgets/EktronTwitterFeed/js/Output.js");
            Css.Register(this, SitePath + "widgets/EktronTwitterFeed/css/Output.css");

            string settings = "{" +
                "ContainerID:'" + uxStarterWidget.ClientID + "' " +
            "}";
            JavaScript.RegisterJavaScriptBlock(this, "Ektron.PFWidgets.EktronTwitterFeed.init(" + settings + ");");
        }
    }
    #endregion private helpers
}

