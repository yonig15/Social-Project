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
    public class DS_Product: BaseDataSql
    {
        BaseDal BaseDal;
        public DS_Product(LogManager log) : base(log)
        {
            BaseDal = new BaseDal(Log);
        }

        public DataTable Send_getAllMyProductForActivistQuery(string SA_code)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_Product \ Send_getAllMyProductForActivistQuery ran Successfully - ");
                return SqlQuery.Read_Table_FormDB("SELECT Products.Name as 'Product_Name', Products.Price as 'Price', COUNT(Orders.Code) as 'Total_Donations',\r\nsum(Orders.Quantity) as 'Quantity',Products.Price*sum(Orders.Quantity) as 'Total_Price', Campaigns.Name as 'Campaign_Name'\r\nFROM Orders\r\nJOIN Products ON Products.Code = Orders.Product_code\r\nJOIN Campaigns ON Orders.Campaign_code = Campaigns.Code\r\nWHERE Orders.SA_code = " + SA_code + "\r\nGROUP BY Products.Name, Products.Price, Campaigns.Name;");
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }
        }

        public DataTable Send_getProductListQuery(string BC_code)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_Product \ Send_getProductListQuery ran Successfully - ");
                return SqlQuery.Read_Table_FormDB("select * from Products where BC_Code =" + BC_code);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }
        }

        public DataTable Send_getProductListForActivistQuery(string Campaign_code)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_Product \ Send_getProductListForActivistQuery ran Successfully - ");
                return SqlQuery.Read_Table_FormDB("select * from Products where Campaign_code =" + Campaign_code);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }
        }

        public void EnterOrderDetailsFormToDB(M_Order m_Order, int UnitsInStock)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_Product \ EnterOrderDetailsFormToDB ran Successfully - ");
                string sqlQuery = "insert into Orders values ('" + m_Order.SA_code + "', '" + m_Order.BC_code + "', '" + m_Order.Campaign_code + "', '" + m_Order.Product_code + "'," + UnitsInStock + ", getdate(), 0)  update Products set Units_In_Stock = Units_In_Stock - " + UnitsInStock + "  where Code = " + m_Order.Product_code;
                SqlQuery.Write_ToDB(sqlQuery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

        public void DeleteProductQuery(string productCode)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_Product \ DeleteProductQuery ran Successfully - ");
                string deleteQuery = "delete from Products where Code = " + productCode;
                SqlQuery.Write_ToDB(deleteQuery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }


    }
}
