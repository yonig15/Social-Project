using MyUtilities_CS_yoni;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;

namespace SocialProject.Entities.commands.Twitter_Command
{
    public class MS_Dic_post_MakeATweet : BaseCommand, ICommand
    {
        public MS_Dic_post_MakeATweet(LogManager log) : base(log) { }

        public (string, object) Run(params object[] arg)
        {
            string ConsumerKey = MainManager.Instance.M_Configuration.TwitterConsumerKey;
            string ConsumerKeySecret = MainManager.Instance.M_Configuration.TwitterConsumerKeySecret;
            string AccessKey = MainManager.Instance.M_Configuration.TwitterAccessKey;
            string AccessKeySecret = MainManager.Instance.M_Configuration.TwitterAccessKeySecret;

            var userClient = new TwitterClient(ConsumerKey, ConsumerKeySecret, AccessKey, AccessKeySecret);

            try
            {
                Log.LogEvent(@"Event: Entities \ commands \ MS_Dic_post_MakeATweet \ Run, ran Successfully - ");
                RunAsync(userClient, (string)arg[2]);
                return ("OkObjectResult", "success post tweet");
            }
            catch (Exception ex)
            {
                Log.LogException($@"Exception: An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return ("BadRequestObjectResult", "Error while getting role: " + ex.Message);
            }
        }

        private async void RunAsync(TwitterClient userClient, string requestBody)
        {
            var user = await userClient.Users.GetAuthenticatedUserAsync();
            Console.WriteLine(user);

            dynamic dataD = JsonConvert.DeserializeObject(await new StreamReader(requestBody).ReadToEndAsync());
            if (dataD.Quantity > 1)
            {
                var tweet = await userClient.Tweets.PublishTweetAsync("#" + dataD.Twitter_Name + " just donated " + dataD.Quantity + " " + dataD.ProductName + "`s to support the " + dataD.CampaignName + " campaign, thank you for your kind donatinon\nsearch #SocialProject and " + dataD.CampaignHashTag + " for more info!");
                Console.WriteLine("You published the tweet : " + tweet);
            }
            else
            {
                var tweet = await userClient.Tweets.PublishTweetAsync("#" + dataD.Twitter_Name + " just donated " + dataD.ProductName + " to support the " + dataD.CampaignName + " campaign, thank you for your kind donatinon\nsearch #SocialProject and " + dataD.CampaignHashTag + " for more info!");
                Console.WriteLine("You published the tweet : " + tweet);
            }
        }
    }
}
