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
    public class SocialActivistManager: BaseEntity
    {
        BaseDataSql baseDataSql;
        private DS_SocialActivist DS_SocialActivist;
        public SocialActivistManager(LogManager log) : base(log)
        {
            baseDataSql = new BaseDataSql(Log);
            DS_SocialActivist = new DS_SocialActivist(Log);
        }

        public DataTable getSocialActivistList = new DataTable();
        public void ShowSocialActivistListFromDB()
        {
            try
            {
                Log.LogEvent(@"Entities \ SocialActivistManager \ ShowSocialActivistListFromDB ran Successfully - ");
                getSocialActivistList.Clear();
                getSocialActivistList = DS_SocialActivist.Send_getSocialActivistListQuery();
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }


        public DataTable getMoneyStatusForActivist = new DataTable();
        public void UpdateMoneyStatusInDB(string userInfoCode)
        {
            try
            {
                Log.LogEvent(@"Entities \ SocialActivistManager \ UpdateMoneyStatusInDB ran Successfully - ");
                getMoneyStatusForActivist = DS_SocialActivist.MoneyByTwitterQuery(userInfoCode);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }



        public DataTable getOrderDetail = new DataTable();
        public void ShowOrderDetailForCompanyFromDB(string BC_code)
        {
            try
            {
                Log.LogEvent(@"Entities \ SocialActivistManager \ ShowOrderDetailForCompanyFromDB ran Successfully - ");
                getOrderDetail = DS_SocialActivist.Send_getOrderDetailQuery(BC_code);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }
    }
}
