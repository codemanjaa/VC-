
namespace TweetBL
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;

    public class ManageTweet
    {
        private IList<Tweet> Tweets { get; set; }

        public ManageTweet()
        {
            if (File.Exists("M:/ManageTweetDBFile.dat"))
            {
                var formatter = new BinaryFormatter();
                using (var stream = new FileStream("M:/ManageTweetDBFile.dat", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    this.Tweets = (List<Tweet>)formatter.Deserialize(stream);
                }
            }
            else
            {
                this.Tweets = new List<Tweet>();
                SeedTweets();
            }
        }

        private void SeedTweets()
        {        
            // 1st Tweet
            this.Tweets.Add( 
                new Tweet()
                {
                    Id = 1,
                    PostedBy = "Mayura",
                    Text = "First step is always best!"
                });

            // 2nd Tweet
            this.Tweets.Add(
                new Tweet()
                {
                    Id = 2,
                    PostedBy = "Mayura",
                    Text = "Nothing impossible."
                });

            // 3rd Tweet
            this.Tweets.Add(
                new Tweet()
                {
                    Id = 3,
                    PostedBy = "Mayura",
                    Text = "Lets see if we can use a WCF Service to Get/Update/Delete and Save Tweets to our local file."
                });

            // 4th Tweet
            this.Tweets.Add(
                new Tweet()
                {
                    Id = 4,
                    PostedBy = "Mayura",
                    Text = "Javascript rules the web!!!"
                });

            SaveTweet();
        }

        private void SaveTweet()
        {
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream("M:/ManageTweetDBFile.dat", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, this.Tweets);
            }
        }

        public IList<Tweet> GetTweets()
        {
            return this.Tweets;
        }

        public Tweet GetTweetById(int id)
        {
            return this.Tweets.SingleOrDefault(tweet => tweet.Id == id);
        }

        public void UpdateTweet(Tweet tweetForUpdate)
        {
            Tweet updateTweet = this.Tweets.SingleOrDefault(tweet => tweet.Id == tweetForUpdate.Id);

            if (updateTweet != null)
            {
                // Employ advantage of List - Remove and Add Functions! Not a real application
                // No need for any validations
                this.Tweets.Remove(updateTweet);
                this.Tweets.Add(tweetForUpdate);
                SaveTweet();
            }
        }

        public void CreateTweet(Tweet addNewTweet)
        {
            int lastTweetdId = this.Tweets.Max(tweet => tweet.Id);
            addNewTweet.Id = lastTweetdId + 1;
            this.Tweets.Add(addNewTweet);
            SaveTweet();
        }

        public void DeleteTweet(int tweetId)
        {
            Tweet deleteTweet = this.Tweets.SingleOrDefault(tweet => tweet.Id == tweetId);
            this.Tweets.Remove(deleteTweet);
            SaveTweet();
        }
    }
}
