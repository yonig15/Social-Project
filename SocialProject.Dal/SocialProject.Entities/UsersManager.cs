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
    public class UsersManager: BaseEntity
    {
        BaseDataSql baseDataSql;
        private DS_UsersQ dS_UsersQ;
        public UsersManager(LogManager log) : base(log)
        {
            baseDataSql = new BaseDataSql(Log);
            dS_UsersQ = new DS_UsersQ(Log);
        }
       

        //*************************************************************** User-Info for NPO + company + social_Activist ***********************************

        public DataTable getUserInfo = new DataTable();
        public void get_UserInfo_FromDB(string email, string role)
        {
            try
            {
               getUserInfo.Clear();
               getUserInfo = dS_UsersQ.Send_UserInfoQuery(email, role);
               Log.LogEvent(@"Entities \ UsersManager \ get_UserInfo_FromDB ran Successfully - ");
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }


        public DataTable getPendingList = new DataTable();
        public void ShowAllPendingListFromDB()
        {
            try
            {
                Log.LogEvent(@"Entities \ UsersManager \ ShowAllPendingListFromDB ran Successfully - ");
                getPendingList.Clear();
                getPendingList = dS_UsersQ.Send_getPendingListQuery();
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }
        public bool? get_Pending_FromDB(string email)
        {
            try
            {
                Log.LogEvent(@"Entities \ UsersManager \ get_Pending_FromDB ran Successfully - ");
                return dS_UsersQ.Send_PenddingQuery(email);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return null;
            }

        }

        public void SendContactUsFormToDB(M_ContactUs m_ContactUs)
        {
            try
            {
                Log.LogEvent(@"Entities \ UsersManager \ SendContactUsFormToDB ran Successfully - ");
                dS_UsersQ.EnterContactUsFormToDB(m_ContactUs);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

        public void SendSocialActivistFormToDB(M_SocialActivist m_Social)
        {
            try
            {
                Log.LogEvent(@"Entities \ UsersManager \ SendSocialActivistFormToDB ran Successfully - ");
                dS_UsersQ.EnterSocialActivistFormToDB(m_Social);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }

        public void SendNPOFormToDB(M_NonProfitOrganization m_NonProfit)
        {
            try
            {
                Log.LogEvent(@"Entities \ UsersManager \ SendNPOFormToDB ran Successfully - ");
                dS_UsersQ.EnterNPOFormToDB(m_NonProfit);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);

            }

        }

        public void SendCompanyFormToDB(M_BusinessCompany m_Company)
        {
            try
            {
                Log.LogEvent(@"Entities \ UsersManager \ SendCompanyFormToDB ran Successfully - ");
                dS_UsersQ.EnterCompanyFormToDB(m_Company);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

        public void UpdateApproveUserInDB(M_Register_Applications m_Register_App)
        {
            try
            {
                Log.LogEvent(@"Entities \ UsersManager \ UpdateApproveUserInDB ran Successfully - ");
                dS_UsersQ.ApproveUserQuery(m_Register_App);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
           
        }

        public void UpdateIs_ActiveInDB(M_Campaign m_Campaign)
        {
            try
            {
                Log.LogEvent(@"Entities \ UsersManager \ UpdateIs_ActiveInDB ran Successfully - ");
                dS_UsersQ.Is_ActiveCampaignsQuery(m_Campaign);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

        public void SendCampaignForm_ToDB(M_Campaign m_Campaign)
        {
            try
            {
                Log.LogEvent(@"Entities \ UsersManager \ SendCampaignForm_ToDB ran Successfully - ");
                dS_UsersQ.EnterCampaignFormToDB(m_Campaign);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

        public void SendEditCampaignForm_ToDB(M_Campaign m_Campaign)
        {
            try
            {
                Log.LogEvent(@"Entities \ UsersManager \ SendEditCampaignForm_ToDB ran Successfully - ");
                dS_UsersQ.EnterEditCampaignFormToDB(m_Campaign);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }

        public void UpdateIs_sendInDB(M_Order m_Order)
        {
            try
            {
                Log.LogEvent(@"Entities \ UsersManager \ UpdateIs_sendInDB ran Successfully - ");
                dS_UsersQ.Is_sendForOrderQuery(m_Order);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }

        public void SendProductForm_ToDB(M_Product m_Product)
        {
            try
            {
                Log.LogEvent(@"Entities \ UsersManager \ SendProductForm_ToDB ran Successfully - ");
                dS_UsersQ.EnterProductFormToDB(m_Product);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
           
        }
        public void SendEditProductForm_ToDB(M_Product m_Product)
        {
            try
            {
                Log.LogEvent(@"Entities \ UsersManager \ SendEditProductForm_ToDB ran Successfully - ");
                dS_UsersQ.EnterEditProductFormToDB(m_Product);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }

    }

}
