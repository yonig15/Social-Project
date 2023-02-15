using MyUtilities_CS_yoni;
using SocialProject.Dal;
using SocialProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.DataSql
{
    public class DS_Twitter:BaseDataSql
    {
        BaseDal BaseDal;
        public DS_Twitter(LogManager log) : base(log) 
        {
            BaseDal = new BaseDal(Log);
        }


        public void UpdateTweetAndSA_MoneyQuery(M_Tweets newTweet)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_Twitter \ UpdateTweetAndSA_MoneyQuery ran Successfully - ");
                string updateQuery = "if not exists(select Code from Tweets where Tweet_id like '" + newTweet.Tweet_id + "')\r\n\tbegin\r\n\t\tinsert into Tweets values (" + newTweet.SA_code + ", " + newTweet.Campaign_code + ", '" + newTweet.HashTag + "', '" + newTweet.Landing_Page_URL + "', '" + newTweet.Tweet_Content + "', getdate(), '" + newTweet.Tweet_id + "')\r\n\t\tupdate Social_Activist set Money_Status = Money_Status + 10 where Code = " + newTweet.SA_code + "\r\n\tend";
                SqlQuery.Write_ToDB(updateQuery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }

        public void EnterTweetToDB(M_Campaign m_Campaign, string SA_code)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_Twitter \ EnterTweetToDB ran Successfully - ");
                string sqlQuery = "insert into Tweets values('" + SA_code + "','" + m_Campaign.Code + "','" + m_Campaign.HashTag + "','" + m_Campaign.Landing_Page_URL + "','" + m_Campaign.Description + "', getdate())";
                SqlQuery.Write_ToDB(sqlQuery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

        public DataTable Send_getTweetsListQuery()
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_Twitter \ Send_getTweetsListQuery ran Successfully - ");
                return SqlQuery.Read_Table_FormDB("select * from Tweets");
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }

        }


        public DataTable Send_getNEWMoneyStatusForActivistQuery(string NEWMoneyStatus, string SA_Code)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_Twitter \ Send_getNEWMoneyStatusForActivistQuery ran Successfully - ");
                string updateQuery = "update Social_Activist set Money_Status = '" + NEWMoneyStatus + "' where Code =" + SA_Code;
                SqlQuery.Write_ToDB(updateQuery);

                return SqlQuery.Read_Table_FormDB("select * from Social_Activist");
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }
           
        }
    }
}
