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
    public class DS_BCompany: BaseDataSql
    {
        BaseDal BaseDal;
        public DS_BCompany(LogManager log) : base(log) 
        {
            BaseDal = new BaseDal(Log);
        }

        public DataTable Send_getCompanyListQuery()
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_BCompany \ Send_getCompanyListQuery ran Successfully - ");
                return SqlQuery.Read_Table_FormDB("select * from Buisness_Companies");
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }

        }

    }
}
