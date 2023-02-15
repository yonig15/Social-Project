using MyUtilities_CS_yoni;
using Newtonsoft.Json.Linq;
using RestSharp;
using SocialProject.DataSql;
using SocialProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tweetinvi.Core.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SocialProject.Entities
{
    public class TwitterManager: BacePromotionSystem
    {
        private DS_Twitter DS_Twitter;
        private DS_SocialActivist DS_SocialActivist;
        private DS_Campaigns DS_Campaigns;
        public TwitterManager(LogManager log) : base(log)
        {
            DS_Twitter = new DS_Twitter(Log);
            DS_SocialActivist = new DS_SocialActivist(Log);
            DS_Campaigns = new DS_Campaigns(Log);
        }

        static string TwitterBearerCode = $"Bearer {MainManager.Instance.M_Configuration.TwitterBearerCode}";

        public void StartTwitterUpdaterTask()
        {
            Task.Run(TwitterUpdater);
        }
        void TwitterUpdater()
        {
            Log.LogEvent(@"Entities \ TwitterManager \ TwitterUpdater ran Successfully - ");
            while (true)
            {
                try
                {
                    var request = new RestRequest("", Method.Get);
                    request.AddHeader("authorization", TwitterBearerCode);
                    UpdateTweetListAndSAMoney(request);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                }
                Thread.Sleep(3600000);
            }
        }

        public void UpdateTweetListAndSAMoney(RestRequest request)
        {
            try
            {
                Log.LogEvent(@"Entities \ UsersManager \ SendSocialActivistFormToDB ran Successfully - ");
                List<M_SocialActivist> SAList = MainManager.Instance.twitterManager.FillSocialActivistListFromDB();
                List<M_Campaign> CampaignsList = MainManager.Instance.twitterManager.FillAllCampaignsListFromDB();

                RunOnAllSAUsers(SAList, CampaignsList, request);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
           
        }

        void RunOnAllSAUsers(List<M_SocialActivist> SAList, List<M_Campaign> CampaignList, RestRequest request)
        {
            try
            {
                Log.LogEvent(@"Entities \ UsersManager \ SendSocialActivistFormToDB ran Successfully - ");
                foreach (M_SocialActivist SA in SAList)
                {
                    if (SA.Twitter_Name[0] == '@')
                    {
                        SA.Twitter_Name = SA.Twitter_Name.Substring(1);
                    }
                    RunOnAllCampaigns(SA, CampaignList, request);
                }
            }
            catch (Exception ex)
            {

                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

        void RunOnAllCampaigns(M_SocialActivist SA, List<M_Campaign> CampaignList, RestRequest request)
        {
            try
            {
                Log.LogEvent(@"Entities \ UsersManager \ SendSocialActivistFormToDB ran Successfully - ");
                foreach (M_Campaign Campaign in CampaignList)
                {
                    if (Campaign.HashTag[0] == '#')
                    {
                        Campaign.HashTag = Campaign.HashTag.Substring(1);
                    }
                    var tweetsURL = $"https://api.twitter.com/2/tweets/search/recent?query=from:{SA.Twitter_Name}%20%23SocialProject%20%23{Campaign.HashTag}";
                    var client = new RestClient(tweetsURL);
                    var response = client.Execute(request);
                    Console.WriteLine(response.Content);
                    if (response.IsSuccessful && !response.Content.Contains("\"result_count\":0"))
                    {
                        JObject json = JObject.Parse(response.Content);

                        JArray tweets = (JArray)json["data"];

                        UpdateTweetsData(tweets, SA, Campaign);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

        void UpdateTweetsData(JArray tweets, M_SocialActivist SA, M_Campaign Campaign)
        {
            Log.LogEvent(@"Entities \ UsersManager \ SendSocialActivistFormToDB ran Successfully - ");
            foreach (var tweet in tweets)
            {
                string tweetId = tweet["id"].ToString();
                string tweet_Content = tweet["text"].ToString();
                M_Tweets newTweet = new M_Tweets();
                newTweet.SA_code = SA.Code;
                newTweet.Campaign_code = Campaign.Code;
                newTweet.HashTag = Campaign.HashTag;
                newTweet.Landing_Page_URL = Campaign.Landing_Page_URL;
                newTweet.Tweet_Content = tweet_Content;
                newTweet.Tweet_id = tweetId;
                MainManager.Instance.twitterManager.UpdateTweetAndMoneyInDB(newTweet);
            }
        }


        private DataTable getSocialActivist = new DataTable();
        public List<M_SocialActivist> FillSocialActivistListFromDB()
        {
            try
            {
                Log.LogEvent(@"Entities \ TwitterManager \ FillSocialActivistListFromDB ran Successfully - ");
                List<M_SocialActivist> SocialActivistList = new List<M_SocialActivist>();

                getSocialActivist.Clear();
                SocialActivistList.Clear();

                getSocialActivist = DS_SocialActivist.Send_getSocialActivistListQuery();
                int NumOfRows_Activist = getSocialActivist.Rows.Count;

                for (int i = 0; i < NumOfRows_Activist; i++)
                {
                    M_SocialActivist SA = new M_SocialActivist();
                    SA.Code = (int)getSocialActivist.Rows[i][0];
                    SA.Twitter_Name = (string)getSocialActivist.Rows[i][9];
                    SocialActivistList.Add(SA);
                }
                return SocialActivistList;
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }
        }


        private DataTable getAllCampaigns = new DataTable();
        public List<M_Campaign> FillAllCampaignsListFromDB()
        {
            try
            {
                Log.LogEvent(@"Entities \ TwitterManager \ FillAllCampaignsListFromDB ran Successfully - ");
                List<M_Campaign> CampaignList = new List<M_Campaign>();

                getAllCampaigns.Clear();
                CampaignList.Clear();

                getAllCampaigns = DS_Campaigns.Send_getAllCampaignsListQuery();
                int NumOfRows_Campaigns = getAllCampaigns.Rows.Count;

                for (int i = 0; i < NumOfRows_Campaigns; i++)
                {
                    M_Campaign Campaign = new M_Campaign();
                    Campaign.Code = (int)getAllCampaigns.Rows[i][0];
                    Campaign.HashTag = (string)getAllCampaigns.Rows[i][5];
                    Campaign.Landing_Page_URL = (string)getAllCampaigns.Rows[i][4];
                    CampaignList.Add(Campaign);
                }
                return CampaignList;
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }
        }

        public void UpdateTweetAndMoneyInDB(M_Tweets newTweet)
        {
            try
            {
                Log.LogEvent(@"Entities \ TwitterManager \ UpdateTweetAndMoneyInDB ran Successfully - ");
                DS_Twitter.UpdateTweetAndSA_MoneyQuery(newTweet);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }  
        }

        public void SendTweetToDB(M_Campaign m_Campaign, string SA_code)
        {
            try
            {
                Log.LogEvent(@"Entities \ TwitterManager \ SendTweetToDB ran Successfully - ");
                DS_Twitter.EnterTweetToDB(m_Campaign, SA_code);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }


        public DataTable getTweetsList = new DataTable();
        public void ShowTweetsListFromDB()
        {
            try
            {
                Log.LogEvent(@"Entities \ TwitterManager \ ShowTweetsListFromDB ran Successfully - ");
                getTweetsList.Clear();
                getTweetsList = DS_Twitter.Send_getTweetsListQuery();
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }


        public DataTable getNewMoneyStatusForActivist = new DataTable();
        public void ShowNewMoneyStatusForActivistFromDB(string NEWMoneyStatus, string SA_Code)
        {
            try
            {
                Log.LogEvent(@"Entities \ TwitterManager \ ShowNewMoneyStatusForActivistFromDB ran Successfully - ");
                getNewMoneyStatusForActivist = DS_Twitter.Send_getNEWMoneyStatusForActivistQuery(NEWMoneyStatus, SA_Code);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

    }
}


