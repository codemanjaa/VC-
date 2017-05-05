<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TweetClient.aspx.cs" Inherits="Tweet.WCFService.AJAX.TweetClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Button2 {
            width: 88px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Services>
                <asp:ServiceReference Path="~/TweetService.svc" />
            </Services>
        </asp:ScriptManager>

        <br />
        <input id="Button2" type="button" value="Show All" onclick="showAll()" /><br />
        <br />

        <input id="Button1" type="button" value="New Tweet" onclick="twitterOn()" /><br />
        <br />
        <br />

        <br />

        <%--Code to use the TweetService Javascript Proxy Class!--%>

        <div>
            <table id="allTweetList"></table>
        </div>

        <script type="text/javascript">
            var tweetService = new TweetService();

            function twitterOn() {
                // Get access to the TweetService!
                // Create instance of our Service.
              

                // Create a Tweet
                tweetService.CreateTweet({
                    PostedBy: "Mayura!",
                    Text: "Tweet Client @Mayura domain Test Successful.. Yeah!!"
                }, function () {
                    // On Success
                    alert("Tweet has been created successfully!");
                }, function (error) {
                    // On Error
                    alert("Ouch! errr...Tweet could not be created!" +
                        " Something went WRONG.");
                });

                //tweetService.UpdateTweet({
                //    Id: 1,
                //    PostedBy: "Updated by Tweet Client!",
                //    Text: "Tweet 1 is updated by Tweet Client ASPX!"
                //}, function () {
                //    // On Success
                //    alert("Tweet with id 1 has been successfully Updated!");
                //}, function (error) {
                //    // On Error
                //    alert("Ouch! errr...Tweet at id 1 could not be" + 
                //        "updated! Something went WRONG.");
                //});

                //tweetService.DeleteTweet(2               
                //, function () {
                //    // On Success
                //    alert("Tweet at id 2 has been successfully Deleted!");
                //}, function (error) {
                //    // On Error
                //    alert("Ouch! errr...Tweet at id 2 could not be" +
                //        "Deleted! Something went WRONG." + error.get_message);
                //});

                // Retrieve all Tweets
                showAll();
            }

            function showAll() {
                tweetService.GetTweets(function (tweets) {
                    var tweetTable = document.getElementById("allTweetList");
                    //alert(tweets.length);

                    var output = "";
                    for (var i = 0; i < tweets.length; i++) {
                        output += "<tr><td>" + tweets[i].Id + "</td><td>" +
                            tweets[i].PostedBy + "</td><td>" + tweets[i].Text + "</td></tr>";
                    }
                    tweetTable.innerHTML = output;
                });
            }
        </script>

        
    </form>



</body>
</html>






