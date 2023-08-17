using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SocialProject.Entities;
using SocialProject.Model;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using Tweetinvi;
using System.Data;

namespace SocialProject.MicroServer
{
    public static class MS_Twitter
    {
        [FunctionName("Twitter")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "twitter/{action}/{value?}/{value2?}")] HttpRequest req,
            string action, string value, string value2, ILogger log)
        {

            string requestBody1 = await req.ReadAsStringAsync();

            try
            {
                (string response, object result) = MainManager.Instance.CommandsManager.CommandList[action].Run(value, value2, requestBody1);
                switch (response)
                {
                    case "OkObjectResult":
                        return new OkObjectResult(result);
                    case "NotFoundResult":
                        return new NotFoundResult();
                    case "BadRequestObjectResult":
                        return new BadRequestObjectResult(result);
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MainManager.Instance.LogManager.LogException($"exception while execute {action} command: ", ex);
            }

            return null;
        }
    }
}




//object data;
//dynamic dataD;
//string requestBody;
//string responseMessage;

//string ConsumerKey = MainManager.Instance.M_Configuration.TwitterConsumerKey;
//string ConsumerKeySecret = MainManager.Instance.M_Configuration.TwitterConsumerKeySecret;
//string AccessKey = MainManager.Instance.M_Configuration.TwitterAccessKey;
//string AccessKeySecret = MainManager.Instance.M_Configuration.TwitterAccessKeySecret;
//string TwitterBearerCode = $"Bearer {MainManager.Instance.M_Configuration.TwitterBearerCode}";

//var userClient = new TwitterClient(ConsumerKey, ConsumerKeySecret, AccessKey, AccessKeySecret);

//var user = await userClient.Users.GetAuthenticatedUserAsync();
//Console.WriteLine(user);

//switch (action)
//{
//    // *********************************************All Get Request*******************************
//    case "get-twitterPostForUpdate":

//        try
//        {
//            List<M_SocialActivist> SAList = MainManager.Instance.twitterManager.FillSocialActivistListFromDB();

//            List<M_Campaign> CampaignsList = MainManager.Instance.twitterManager.FillAllCampaignsListFromDB();

//            foreach (M_SocialActivist SA in SAList)
//            {
//                if (SA.Twitter_Name[0] == '@')
//                {
//                    SA.Twitter_Name = SA.Twitter_Name.Substring(1);
//                }
//                foreach (M_Campaign Campaign in CampaignsList)
//                {
//                    if (Campaign.HashTag[0] == '#')
//                    {
//                        Campaign.HashTag = Campaign.HashTag.Substring(1);
//                    }

//                    var tweetsURL = $"https://api.twitter.com/2/tweets/search/recent?query=from:{SA.Twitter_Name}%20%23SocialProject%20%23{Campaign.HashTag}";
//                    var client = new RestClient(tweetsURL);
//                    var request = new RestRequest("", Method.Get);
//                    request.AddHeader("authorization", TwitterBearerCode);
//                    var response = client.Execute(request);
//                    Console.WriteLine(response.Content);
//                    if (response.IsSuccessful && !response.Content.Contains("\"result_count\":0"))
//                    {
//                        JObject json = JObject.Parse(response.Content);

//                        JArray tweets = (JArray)json["data"];

//                        foreach (var tweet in tweets)
//                        {
//                            string tweetId = tweet["id"].ToString();
//                            string tweet_Content = tweet["text"].ToString();
//                            M_Tweets newTweet = new M_Tweets();
//                            newTweet.SA_code = SA.Code;
//                            newTweet.Campaign_code = Campaign.Code;
//                            newTweet.HashTag = Campaign.HashTag;
//                            newTweet.Landing_Page_URL = Campaign.Landing_Page_URL;
//                            newTweet.Tweet_Content = tweet_Content;
//                            newTweet.Tweet_id = tweetId;
//                            MainManager.Instance.twitterManager.UpdateTweetAndMoneyInDB(newTweet);
//                        }
//                    }
//                }
//            }
//            return null;
//        }
//        catch (Exception)
//        {

//            throw;
//        }

//case "get-AllTwitted":

//    try
//    {
//        MainManager.Instance.twitterManager.ShowTweetsListFromDB();
//        responseMessage = JsonConvert.SerializeObject(MainManager.Instance.twitterManager.getTweetsList);
//        return new OkObjectResult(responseMessage);
//    }
//    catch (Exception)
//    {

//        throw;
//    }

//case "get-UpdateMoneyStatus":

//    try
//    {
//        MainManager.Instance.twitterManager.ShowNewMoneyStatusForActivistFromDB(value, value2);
//        responseMessage = JsonConvert.SerializeObject(MainManager.Instance.twitterManager.getNewMoneyStatusForActivist);
//        return new OkObjectResult(responseMessage);
//    }
//    catch (Exception)
//    {

//        throw;
//    }

// *********************************************All Post Request*******************************

//case "post-MakeATweet":

//    try
//    {
//        dataD = JsonConvert.DeserializeObject(await new StreamReader(req.Body).ReadToEndAsync());
//        if (dataD.Quantity > 1)
//        {
//            var tweet = await userClient.Tweets.PublishTweetAsync("#" + dataD.Twitter_Name + " just donated " + dataD.Quantity + " " + dataD.ProductName + "`s to support the " + dataD.CampaignName + " campaign, thank you for your kind donatinon\nsearch #SocialProject and " + dataD.CampaignHashTag + " for more info!");
//            Console.WriteLine("You published the tweet : " + tweet);
//        }
//        else
//        {
//            var tweet = await userClient.Tweets.PublishTweetAsync("#" + dataD.Twitter_Name + " just donated " + dataD.ProductName + " to support the " + dataD.CampaignName + " campaign, thank you for your kind donatinon\nsearch #SocialProject and " + dataD.CampaignHashTag + " for more info!");
//            Console.WriteLine("You published the tweet : " + tweet);
//        }

//        break;
//    }
//    catch (Exception)
//    {

//        throw;
//    }

//case "Post-tweet":

//    try
//    {
//        M_Campaign m_Campaign1 = new M_Campaign();
//        m_Campaign1 = System.Text.Json.JsonSerializer.Deserialize<M_Campaign>(req.Body);
//        MainManager.Instance.twitterManager.SendTweetToDB(m_Campaign1, value);
//        break;
//    }
//    catch (Exception)
//    {

//        throw;
//    }


//    default:
//        break;
//}