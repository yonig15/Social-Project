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
    public class DS_UsersQ : BaseDataSql
    {
        BaseDal BaseDal;
        public DS_UsersQ(LogManager log) : base(log)
        {
            BaseDal = new BaseDal(Log);
        }


        //******************************** NPO + company + social_Activist ***********************************

        public DataTable Send_UserInfoQuery(string email,string role)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_UsersQ \ Send_UserInfoQuery ran Successfully - ");
                if (role == "N.P.O")
                {
                    return SqlQuery.Read_Table_FormDB("select * from Non_Profit_Organizations where Email='" + email + "' ");
                }
                else if (role == "company")
                {
                    return SqlQuery.Read_Table_FormDB("select * from Buisness_Companies where Email='" + email + "' ");
                }
                else
                {
                    return SqlQuery.Read_Table_FormDB("select * from Social_Activist where Email='" + email + "' ");
                }
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }
           
        }


        public DataTable Send_getPendingListQuery()
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_UsersQ \ Send_getPendingListQuery ran Successfully - ");
                return SqlQuery.Read_Table_FormDB("select * from Register_Applications where Is_Approved = 0");
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }
            
        }


        public bool? Send_PenddingQuery(string email)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_UsersQ \ Send_PenddingQuery ran Successfully - ");
                string Is_Approved = "select Is_Approved from Register_Applications where Email like '" + email + "'";
                bool? Pending = (bool?)SocialProject.Dal.SqlQuery.Read_Scalar_FromDB(Is_Approved);
                return Pending;
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }  
        }


        public void EnterContactUsFormToDB(M_ContactUs M_ContactUs)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_UsersQ \ EnterContactUsFormToDB ran Successfully - ");
                string sqlQuery = "insert into Contact_Us values ('" + M_ContactUs.FirstName + "','" + M_ContactUs.LastName + "','" + M_ContactUs.Email + "','" + M_ContactUs.Message + "','" + M_ContactUs.JoinedNewsletter + "',getdate())";
                SqlQuery.Write_ToDB(sqlQuery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }

        public void EnterSocialActivistFormToDB(M_SocialActivist m_Social)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_UsersQ \ EnterSocialActivistFormToDB ran Successfully - ");
                string Register_ApplicationsQuery = "insert into Register_Applications values ('" + m_Social.FirstName + m_Social.LastName + "', '" + m_Social.Email + "', 'Activist', 0)";
                SqlQuery.Write_ToDB(Register_ApplicationsQuery);

                string sqlQuery = "insert into Social_Activist values ('" + m_Social.FirstName + "','" + m_Social.LastName + "','" + m_Social.Email + "','" + m_Social.Address + "','" + m_Social.Phone_Number + "',0,'" + m_Social.Image + "' ,getdate(),'" + m_Social.Twitter_Name + "')";
                SqlQuery.Write_ToDB(sqlQuery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }

        public void EnterNPOFormToDB(M_NonProfitOrganization m_NonProfit)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_UsersQ \ EnterNPOFormToDB ran Successfully - ");
                string Register_ApplicationsQuery = "insert into Register_Applications values ('" + m_NonProfit.Name + "', '" + m_NonProfit.Email + "', 'N.P.O', 0)";
                SqlQuery.Write_ToDB(Register_ApplicationsQuery);

                string sqlQuery = "insert into Non_Profit_Organizations values ('" + m_NonProfit.Name + "','" + m_NonProfit.Email + "','" + m_NonProfit.Website_URL + "','" + m_NonProfit.Image + "',getdate())";
                SqlQuery.Write_ToDB(sqlQuery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

        public void EnterCompanyFormToDB(M_BusinessCompany m_Company)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_UsersQ \ EnterCompanyFormToDB ran Successfully - ");
                string Register_ApplicationsQuery = "insert into Register_Applications values ('" + m_Company.Name + "', '" + m_Company.Email + "', 'Company', 0)";
                SqlQuery.Write_ToDB(Register_ApplicationsQuery);

                string sqlQuery = "insert into Buisness_Companies values ('" + m_Company.Name + "','" + m_Company.Email + "','" + m_Company.Image + "',getdate())";
                SqlQuery.Write_ToDB(sqlQuery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

        public void ApproveUserQuery(M_Register_Applications m_Register_App)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_UsersQ \ ApproveUserQuery ran Successfully - ");
                string updateQuery = "update Register_Applications set Is_Approved = 1 where code = " + m_Register_App.Code + "";
                SqlQuery.Write_ToDB(updateQuery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

        public void Is_ActiveCampaignsQuery(M_Campaign m_Campaign)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_UsersQ \ Is_ActiveCampaignsQuery ran Successfully - ");
                string updateQuery = "update Campaigns set Is_Active = ~Is_Active where code = " + m_Campaign.Code + "";
                SqlQuery.Write_ToDB(updateQuery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);

            }

        }

        public void EnterCampaignFormToDB(M_Campaign m_Campaign)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_UsersQ \ EnterCampaignFormToDB ran Successfully - ");
                string sqlQuery = "insert into Campaigns values ('" + m_Campaign.Name + "','" + m_Campaign.Email + "','" + m_Campaign.Description + "','" + m_Campaign.Landing_Page_URL + "','" + m_Campaign.HashTag + "','" + m_Campaign.NPO_code + "','" + m_Campaign.Image + "',1)";
                SqlQuery.Write_ToDB(sqlQuery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }

        public void EnterEditCampaignFormToDB(M_Campaign m_Campaign)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_UsersQ \ EnterEditCampaignFormToDB ran Successfully - ");
                string sqlQuery = "update Campaigns set Name = '" + m_Campaign.Name + "', Email = '" + m_Campaign.Email + "', Description = '" + m_Campaign.Description + "', Landing_Page_URL = '" + m_Campaign.Landing_Page_URL + "',HashTag = '" + m_Campaign.HashTag + "', Image = '" + m_Campaign.Image + "' where Code = " + m_Campaign.Code;
                SqlQuery.Write_ToDB(sqlQuery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }

        public void Is_sendForOrderQuery(M_Order m_Order)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_UsersQ \ Is_sendForOrderQuery ran Successfully - ");
                string updateQuery = "update Orders set Is_Sent = ~Is_Sent where code = " + m_Order.Code + "";
                SqlQuery.Write_ToDB(updateQuery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

        public void EnterProductFormToDB(M_Product m_Product)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_UsersQ \ EnterProductFormToDB ran Successfully - ");
                string sqlQuery = "insert into Products values ('" + m_Product.Name + "','" + m_Product.Price + "','" + m_Product.Description + "','" + m_Product.Units_In_Stock + "','" + m_Product.BC_code + "','" + m_Product.Campaign_code + "','" + m_Product.Image + "')";
                SqlQuery.Write_ToDB(sqlQuery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }

        public void EnterEditProductFormToDB(M_Product m_Product)
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_UsersQ \ EnterEditProductFormToDB ran Successfully - ");
                string sqlQuery = "update Products set Name = '" + m_Product.Name + "', Price = '" + m_Product.Price + "', Description = '" + m_Product.Description + "', Units_In_Stock = '" + m_Product.Units_In_Stock + "',BC_code = '" + m_Product.BC_code + "', Campaign_code = '" + m_Product.Campaign_code + "', Image = '" + m_Product.Image + "' where Code = " + m_Product.Code;
                SqlQuery.Write_ToDB(sqlQuery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }
    }
}
