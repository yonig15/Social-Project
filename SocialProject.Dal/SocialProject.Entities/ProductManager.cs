using MyUtilities_CS_yoni;
using SocialProject.DataSql;
using SocialProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities
{
    public class ProductManager:BaseEntity
    {
        BaseDataSql baseDataSql;
        private DS_Product DS_Product;
        public ProductManager(LogManager log) : base(log)
        {
            baseDataSql = new BaseDataSql(Log);
            DS_Product = new DS_Product(Log);
        }


        public DataTable getAllMyProductForActivist = new DataTable();
        public void ShowAllMyProductForActivistFromDB(string SA_code)
        {
            try
            {
                Log.LogEvent(@"Entities \ ProductManager \ ShowAllMyProductForActivistFromDB ran Successfully - ");
                getAllMyProductForActivist = DS_Product.Send_getAllMyProductForActivistQuery(SA_code);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }


        public DataTable getProductList = new DataTable();
        public void ShowProductListFromDB(string BC_code)
        {
            try
            {
                Log.LogEvent(@"Entities \ ProductManager \ ShowProductListFromDB ran Successfully - ");
                getProductList = DS_Product.Send_getProductListQuery(BC_code);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }


        public DataTable getProductListForActivist = new DataTable();
        public void ShowProductListForActivistFromDB(string Campaign_code)
        {
            try
            {
                Log.LogEvent(@"Entities \ ProductManager \ ShowProductListForActivistFromDB ran Successfully - ");
                getProductListForActivist = DS_Product.Send_getProductListForActivistQuery(Campaign_code);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

        public void SendOrderDetailsFormToDB(M_Order m_Order, int UnitsInStock)
        {
            try
            {
                Log.LogEvent(@"Entities \ ProductManager \ SendOrderDetailsFormToDB ran Successfully - ");
                DS_Product.EnterOrderDetailsFormToDB(m_Order, UnitsInStock);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

        public void Delete_Product(string productCode)
        {
            try
            {
                Log.LogEvent(@"Entities \ ProductManager \ Delete_Product ran Successfully - ");
                DS_Product.DeleteProductQuery(productCode);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

    }
}
