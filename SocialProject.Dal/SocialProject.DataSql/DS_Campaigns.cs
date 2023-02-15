using MyUtilities_CS_yoni;
using SocialProject.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.DataSql
{
    public class DS_Campaigns: BaseDataSql
    {
        BaseDal BaseDal;
        public DS_Campaigns(LogManager log) : base(log) 
        {
            BaseDal = new BaseDal(Log);
        }

        public DataTable Send_getAllCampaignsListByNPO_CodeQuery(string NPO_code)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_Campaigns \ Send_getAllCampaignsListByNPO_CodeQuery ran Successfully - ");
                return SqlQuery.Read_Table_FormDB("select * from Campaigns where NPO_code =" + NPO_code);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }
           
        }

        public DataTable Send_getAllCampaignsListQuery()
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_Twitter \ ShowNPOListFromDB ran Successfully - ");
                return SqlQuery.Read_Table_FormDB("select * from Campaigns");
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }

        }
    }
}
