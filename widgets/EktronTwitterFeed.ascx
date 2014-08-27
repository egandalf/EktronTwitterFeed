<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EktronTwitterFeed.ascx.cs" Inherits="widgets_EktronTwitterFeed" %>
<%@ Import Namespace="Ektron.Com.Twitter.Objects" %>
<asp:MultiView ID="ViewSet" runat="server" ActiveViewIndex="0">
    <asp:View ID="View" runat="server">
        <div id="uxStarterWidget" runat="server">
            <asp:Literal ID="uxOutput" runat="server" />
            <section role="region">
                <h4 class="ektron-band"><asp:Literal ID="uxHeadingText" runat="server" /></h4>
                <asp:ListView ID="uxTweets" runat="server" ItemPlaceholderID="ItemPlaceholder" EnableViewState="false">
                    <LayoutTemplate>
                        <ul class="ek-twitter-feed ektron-medlarge-right-padding">
                            <asp:Literal ID="ItemPlaceholder" runat="server" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li class="ek-tweet">
                            <div class="ek-twitter-user">
                                <div class="ek-twitter-user-image">
                                    <a href="https://twitter.com/<%#((Tweet)Container.DataItem).user.screen_name %>" target="_blank">
                                        <img src="<%#((Tweet)Container.DataItem).user.profile_image_url_https %>" alt="<%#((Tweet)Container.DataItem).user.screen_name %>" width="40" height="40" />
                                    </a>
                                </div>
                                <div class="ek-tweet-details">
                                    <div class="ek-twitter-user-info">
                                        <a href="https://twitter.com/<%#((Tweet)Container.DataItem).user.screen_name %>" target="_blank">
                                            @<%#((Tweet)Container.DataItem).user.screen_name %>
                                        </a>
                                        <div runat="server" id="TwitterVia" visible="<%#((Tweet)Container.DataItem).retweeted_status != null %>">
                                            <i>
                                                via
                                                <a href="https://twitter.com/<%#((Tweet)Container.DataItem).retweeted_status != null ? ((Tweet)Container.DataItem).retweeted_status.user.screen_name : string.Empty %>" target="_blank">
                                                    @<%#((Tweet)Container.DataItem).retweeted_status != null ? ((Tweet)Container.DataItem).retweeted_status.user.screen_name : string.Empty %>
                                                </a>
                                            </i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="ek-tweet-text">
                                <%#((Tweet)Container.DataItem).ToHtmlString(true) %>
                            </div>
                            <div class="ek-tweet-actions">
                                <a href="https://twitter.com/intent/tweet?in_reply_to=<%#((Tweet)Container.DataItem).id_str %>"><span class="icon-share-alt"></span> Reply</a>
                                <a href="https://twitter.com/intent/retweet?tweet_id=<%#((Tweet)Container.DataItem).id_str %>"><span class="icon-retweet"></span> Retweet</a>
                                <a href="https://twitter.com/intent/favorite?tweet_id=<%#((Tweet)Container.DataItem).id_str %>"><span class="icon-star"></span> Favorite</a>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:ListView>
            </section>
        </div>
    </asp:View>
    <asp:View ID="Edit" runat="server">
        <div id="<%=ClientID%>_edit" class="ek-edit" style="max-height: 500px; overflow: auto;">
            <table border="0">
                <tr>
                    <td><asp:Label ID="uxHeadingLabel" runat="server" AssociatedControlID="uxHeading" Text="Heading Text:" /></td>
                    <td>
                        <asp:TextBox ID="uxHeading" runat="server" ValidationGroup="TwitterFeed" />
                        <asp:RequiredFieldValidator ID="uxHeadingRequired" runat="server" Display="Dynamic" SetFocusOnError="true" EnableClientScript="true" ControlToValidate="uxHeading" ErrorMessage="Required" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="uxScreenNameLabel" runat="server" AssociatedControlID="uxScreenName" Text="Screen Name:" /></td>
                    <td>
                        <asp:TextBox ID="uxScreenName" runat="server" ValidationGroup="TwitterFeed" />
                        <asp:RequiredFieldValidator ID="uxScreenNameRequired" runat="server" ControlToValidate="uxScreenName" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ErrorMessage="Required" ValidationGroup="TwitterFeed" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <p>
                            <i>Note that Twitter's filter for replies occurs after the tweets are retrieved. If you request 10 tweets and nine of those are replies, the API will return one tweet.</i>
                        </p>
                        <p>
                            <i>Unfortunately, this means that we must request more than we intend to show if we exclude replies, or apply other filters, in order to get enough Tweets. Therefore there are two values to be set: The number of Tweets you want from Twitter, and the number you want to display after any filtering (such as replies) has been set.</i>
                        </p>
                        <p>
                            <i>It is therefore recommended that you set the count from Twitter to be 3x to 10x the number to be shown if you exclude replies, then set the number to be shown.</i>
                        </p>
                        <p>
                            <i>If you do not filter out any Tweets, the two numbers should be equal.</i>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="uxNumberToRetrieveLabel" runat="server" AssociatedControlID="uxNumberToRetrieve" Text="Number of Tweets from Twitter:" />
                    </td>
                    <td>
                        <asp:TextBox ID="uxNumberToRetrieve" runat="server" ValidationGroup="TwitterFeed" TextMode="Number" />
                        <asp:RequiredFieldValidator ID="uxNumberToRetrieveRequired" runat="server" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="uxNumberToRetrieve" ErrorMessage="Required" ValidationGroup="TwitterFeed" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="uxNumberToShowLabel" runat="server" AssociatedControlID="uxNumberToShow" Text="Number of Tweets to Display:" />
                    </td>
                    <td>
                        <asp:TextBox ID="uxNumberToShow" runat="server" ValidationGroup="TwitterFeed" TextMode="Number" />
                        <asp:RequiredFieldValidator ID="uxNumberToShowRequired" runat="server" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="uxNumberToShow" ErrorMessage="Required" ValidationGroup="TwitterFeed" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="uxExcludeRepliesLabel" runat="server" AssociatedControlID="uxExcludeReplies" Text="Exclude Replies from Results:" /></td>
                    <td>
                        <asp:CheckBox ID="uxExcludeReplies" runat="server" ValidationGroup="TwitterFeed" />
                    </td>
                </tr>
            </table>
            <asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClick="CancelButton_Click" CausesValidation="false" ValidationGroup="TwitterFeed" />
            <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" ValidationGroup="TwitterFeed" />
        </div>
    </asp:View>
</asp:MultiView>