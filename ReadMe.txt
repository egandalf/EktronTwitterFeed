Ektron Twitter Widget Readme

Built for Ektron.com in August 2014 by James 'eGandalf' Stout
Twitter: @egandalf

This widget requires:
	* An API Key and Secret which you can create using your (or your company's) Twitter 
	  account at https://dev.twitter.com/
	* Modifications to the Web.config
	* Additions to App_Code which are used to read the config file settings, map Twitter 
	  JSON objects to .NET, and perform API requests

Other Notes: 
	* Built using Ektron CMS version 9.1 CU4
	* Twitter's API is weird. In this widget, you have the option to exclude replies from 
	  the feed. However, that appears to happen only AFTER Twitter generates the feed. If 
	  you ask for 10 Tweets, 8 of which are replies, Twitter will return 2. Therefore you 
	  must enter two numbers into the widget, the number to retrieve and the number to 
	  show. I can't explain what that is. The idea here, if you wish to exclude replies, 
	  is to evaluate your own Tweet-to-Reply ratio and set a sufficiently high Retrieve 
	  number that you can depend on the Show number to work. If you set it to 10, then 
	  Reply 10 times, you're screwed.
	* While not a requirement, this widget does make use of GlyphIcons and related classes
	  provided by Twitter Bootstrap for Reply, Retweet, and Favorite actions. If you do not 
	  use Bootstrap, you will need to find replacements for those images.
	* Twitter Icon retrieved from BrandsOfTheWorld.com.

INSTALLATION & USE
1. Extract
	Extract files into your Ektron CMS application root.

	Folders: 
	~/App_Code
		/Ektron
			/Com
				/Twitter (contains Settings class for web.config entry and API manager)
					/Objects (object classes for deserialization of Twitter JSON responses)
	~/Widgets (widget files)
		/EktronTwitterFeed
			/css (style information specific to the widget)
			/js  (client scripts specific to the widget)
		
2. Web.config
	Add two lines to web.config.

	First, add the following line within the configSections node:
	<section name="TwitterSettings" type="Ektron.Com.Twitter.TwitterSettings"/>

	Second, add the following line as a sibling to the configSections node:
	<TwitterSettings APIKey="[your API key]" APISecret="[your API secret]"/>

3. Test
	This widget is written so that it may be used with or without the Ektron PageBuilder context,
	meaning that it may be used as a standard .NET user control -OR- as an Ektron PageBuilder widget.

	Therefore, it's recommended that you first test the widget outside of the PageBuilder context
	in order to work out any bugs or conflicts that may be specific to your implementation.

	To test:

	1. Create a new, blank WebForm template (.aspx). If you're checking for possible JavaScript 
	   conflicts, inherit from your own master page.
	2. Register the control in the template using the following line.
	<%@ Register Src="~/widgets/EktronTwitterFeed.ascx" TagName="TwitterFeed" TagPrefix="EK" %>
	3. Add the control to the template.
	<EK:TwitterFeed id="uxTwitterFeed" runat="server" ScreenName="egandalf" NumberToRetrieve="20" NumberToShow="5" Heading="Tweets from eGandalf" ExcludeReplies="true" />
	4. Run the page, changing some of the property values to modify the resulting output. Correct 
	   for any conflicts.
	5. Adjust HTML markup, JavaScript, and styles to meet your own site needs.

4. Use in PageBuilder (many steps to make it super-simple)

	1. Log in to your site and go to Settings > Configuration > Personalizations > Widgets
	2. Click the button at the top: Synchronize Widgets from Widgets Folder
	3. Go to Settings > Configuration > Template Configuration
	4. Select the Wireframe Template in which you would like to use this widget.
	5. Enable the EktronTwitterFeed widget for the template.
	6. Repeat steps 4 & 5 for other templates as desired.
	7. Go to Content and browse to the folder which contains a PageBuilder Layout or Master 
	   Layout on which you would like to use this widget.
	8. Edit the page.
	9. Add the widget.
	10. Edit the widget.
	11. Set Heading, Screen Name, and other options as desired.
	12. Repeat steps 7-11 as desired.
	13. Enjoy the Twitter goodness on your site.
