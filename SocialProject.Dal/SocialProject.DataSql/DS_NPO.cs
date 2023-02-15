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
    public class DS_NPO : BaseDataSql
    {
        BaseDal BaseDal;
        public DS_NPO(LogManager log) : base(log) 
        {
            BaseDal = new BaseDal(Log);
        }



        public DataTable Send_getNPOListQuery()
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_NPO \ Send_getNPOListQuery ran Successfully - ");
                return SqlQuery.Read_Table_FormDB("select * from Non_Profit_Organizations");
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }
           
        }

    }
}
