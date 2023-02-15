using MyUtilities_CS_yoni;
using SocialProject.DataSql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities
{
    public class CampaignsManager: BaseEntity
    {
        BaseDataSql baseDataSql;
        DS_Campaigns DS_Campaigns;
        public CampaignsManager(LogManager log) : base(log)
        {
            baseDataSql = new BaseDataSql(Log);
            DS_Campaigns = new DS_Campaigns(Log);
        }

    

        public DataTable getAllCampaigns = new DataTable();
        public void ShowAllCampaignsListFromDB()
        {
            try
            {
                Log.LogEvent(@"Entities \ CampaignsManager \ ShowAllCampaignsListFromDB ran Successfully - ");
                getAllCampaigns.Clear();
                getAllCampaigns = DS_Campaigns.Send_getAllCampaignsListQuery();
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
           
        }


        public DataTable getAllCampaignsByCode = new DataTable();
        public void ShowAllCampaignsListByNPOFromDB(string NPO_code)
        {
            try
            {
                Log.LogEvent(@"Entities \ CampaignsManager \ ShowAllCampaignsListByNPOFromDB ran Successfully - ");
                getAllCampaignsByCode.Clear();
                getAllCampaignsByCode = DS_Campaigns.Send_getAllCampaignsListByNPO_CodeQuery(NPO_code);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
          
        }

    }
}
