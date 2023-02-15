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
    public class DS_SocialActivist: BaseDataSql
    {
        BaseDal BaseDal;
        public DS_SocialActivist(LogManager log) : base(log) 
        {
            BaseDal = new BaseDal(Log);
        }


        public DataTable Send_getSocialActivistListQuery()
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_SocialActivist \ Send_getSocialActivistListQuery ran Successfully - ");
                return SqlQuery.Read_Table_FormDB("select * from Social_Activist");
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }
        }

        public DataTable MoneyByTwitterQuery(string userInfoCode)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_SocialActivist \ MoneyByTwitterQuery ran Successfully - ");
                string updateQuery = $"update Social_Activist set Money_Status = Money_Status + 5 where code = {userInfoCode}";
                return SqlQuery.Read_Table_FormDB(updateQuery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }
        }


        public DataTable Send_getOrderDetailQuery(string BC_code)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_SocialActivist \ Send_getOrderDetailQuery ran Successfully - ");
                return SqlQuery.Read_Table_FormDB("select Orders.*, SA.FirstName+' '+ SA.LastName as SA_Name, BC.Name as BC_Name, Campaigns.Name as Campaign_Name, Products.Name as Product_Name, \r\nSA.Address as Activist_Address, SA.Phone_Number as Activist_Phone,\r\nSA.Email as Activist_Email, Campaigns.Email as Campaign_Email \r\nfrom Orders\r\ninner join Social_Activist as SA on Orders.SA_code = SA.Code\r\ninner join Buisness_Companies as BC on Orders.BC_code = BC.Code\r\ninner join Campaigns on Orders.Campaign_code = Campaigns.Code\r\ninner join Products on Orders.Product_code = Products.Code where Orders.BC_code= " + BC_code);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }
        }
    }
}
