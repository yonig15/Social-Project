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
    public class BCompanyManager : BaseEntity
    {
        BaseDataSql baseDataSql;
        DS_BCompany DS_BCompany;
        public BCompanyManager(LogManager log) : base(log)
        {
            baseDataSql = new BaseDataSql(Log);
            DS_BCompany = new DS_BCompany(Log);
        }

        public DataTable getCompanyList = new DataTable();
        public void ShowCompanyListFromDB()
        {
            try
            {
                Log.LogEvent(@"Entities \ BCompanyManager \ ShowCompanyListFromDB ran Successfully - ");
                getCompanyList.Clear();
                getCompanyList = DS_BCompany.Send_getCompanyListQuery();
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

    }
}
