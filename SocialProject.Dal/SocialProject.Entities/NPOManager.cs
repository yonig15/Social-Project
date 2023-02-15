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
    public class NPOManager: BaseEntity
    {
        BaseDataSql baseDataSql;
        DS_NPO DS_NPO;
        public NPOManager(LogManager log) : base(log)
        {
            baseDataSql = new BaseDataSql(Log);
            DS_NPO = new DS_NPO(Log);
        }


        public DataTable getNPOList = new DataTable();
        public void ShowNPOListFromDB()
        {
            try
            {
                Log.LogEvent(@"Entities \ NPOManager \ ShowNPOListFromDB ran Successfully - ");
                getNPOList.Clear();
                getNPOList = DS_NPO.Send_getNPOListQuery();
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
          
        }

    }
}
