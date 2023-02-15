using MyUtilities_CS_yoni;
using SocialProject.DataSql;
using SocialProject.Entities.commands;
using SocialProject.Entities.commands.BCompany_Command;
using SocialProject.Entities.commands.Campaigns_Command;
using SocialProject.Entities.commands.NPO_Command;
using SocialProject.Entities.commands.Product_Command;
using SocialProject.Entities.commands.SocialActivist_Command;
using SocialProject.Entities.commands.Twitter_Command;
using SocialProject.Entities.commands.User_Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities
{
    public interface ICommand
    {
        (string, object) Run(params object[] arg);
    }

    public class CommandsManager : BaseEntity
    {
        public CommandsManager(LogManager log) : base(log) { }


        private Dictionary<string, ICommand> _commandList = null;
        public Dictionary<string, ICommand> CommandList
        {
            get
            {
                if (_commandList == null) init();
                return _commandList;
            }
        }
        void init()
        {
            _commandList = new Dictionary<string, ICommand>();
            //Build all Dictionary

            //all user micro services
            _commandList.Add("get-RolesData", new MS_Dic_get_RolesData(Log));
            _commandList.Add("get-Pending", new MS_Dic_get_Pending(Log));
            _commandList.Add("get-PendingList", new MS_Dic_get_PendingList(Log));
            _commandList.Add("get-UserInfoData", new MS_Dic_get_UserInfoData(Log));
            _commandList.Add("post-AddOrEditCampaigns", new MS_Dic_post_AddOrEditCampaigns(Log));
            _commandList.Add("get-post-AddOrEditProduct", new MS_Dic_post_AddOrEditProduct(Log));
            _commandList.Add("get-post-Company", new MS_Dic_post_Company(Log));
            _commandList.Add("get-post-ContactUs", new MS_Dic_post_ContactUs(Log));
            _commandList.Add("get-post-NPO", new MS_Dic_post_NPO(Log));
            _commandList.Add("get-post-SocialActivist", new MS_Dic_post_SocialActivist(Log));
            _commandList.Add("get_update-Is_Active", new MS_Dic_update_Is_Active(Log));
            _commandList.Add("get_update_Is_Approved", new MS_Dic_update_Is_Approved(Log));
            _commandList.Add("get_update_Is_send", new MS_Dic_update_Is_send(Log));

            //all socialActivist micro services
            _commandList.Add("get-AllSARows", new MS_Dic_get_AllSARows(Log));
            _commandList.Add("update-AddMoneyStatus", new MS_Dic_update_AddMoneyStatus(Log));

            //all product micro services
            _commandList.Add("delete-CompanyProduct", new MS_Dic_delete_CompanyProduct(Log));
            _commandList.Add("get-AllMyProduct", new MS_Dic_get_AllMyProduct(Log));
            _commandList.Add("get-OrderDetail", new MS_Dic_get_OrderDetail(Log));
            _commandList.Add("get-ProductListForActivist", new MS_Dic_get_ProductListForActivist(Log));
            _commandList.Add("get-ProductPerCompany", new MS_Dic_get_ProductPerCompany(Log));
            _commandList.Add("post-sendToOrderDetails", new MS_Dic_post_sendToOrderDetails(Log));

            //all NPO micro services
            _commandList.Add("get-AllNPORows", new MS_Dic_get_AllNPORows(Log));

            //all campaigns micro services
            _commandList.Add("get-AllCampaigns", new MS_Dic_get_AllCampaigns(Log));
            _commandList.Add("get-AllCampaignsByNPO_code", new MS_Dic_get_AllCampaignsByNPO_code(Log));

            //all BCompany micro services
            _commandList.Add("get-AllSARows", new MS_Dic_get_AllCompanyRows(Log));

            //all tweeter micro services
            _commandList.Add("Post-tweet", new MS_Dic_Post_tweet(Log));
            _commandList.Add("post-MakeATweet", new MS_Dic_post_MakeATweet(Log));
            _commandList.Add("get-UpdateMoneyStatus", new MS_Dic_get_UpdateMoneyStatus(Log));
            _commandList.Add("get-AllTwitted", new MS_Dic_get_AllTwitted(Log));


            //_commandList = new Dictionary<string, ICommand> { 
            //    //Build all Dictionary

            //    //all user micro services
            //    {"get-RolesData", new MS_Dic_get_RolesData(Log)},
            //    {"get-Pending", new MS_Dic_get_Pending(Log)},
            //    {"get-PendingList", new MS_Dic_get_PendingList(Log)},
            //    {"get-UserInfoData", new MS_Dic_get_UserInfoData(Log)},
            //    {"post-AddOrEditCampaigns", new MS_Dic_post_AddOrEditCampaigns(Log)},
            //    {"get-post-AddOrEditProduct", new MS_Dic_post_AddOrEditProduct(Log)},
            //    {"get-post-Company", new MS_Dic_post_Company(Log)},
            //    {"get-post-ContactUs", new MS_Dic_post_ContactUs(Log)},
            //    {"get-post-NPO", new MS_Dic_post_NPO(Log)},
            //    {"get-post-SocialActivist", new MS_Dic_post_SocialActivist(Log)},
            //    {"get_update-Is_Active", new MS_Dic_update_Is_Active(Log)},
            //    {"get_update_Is_Approved", new MS_Dic_update_Is_Approved(Log)},
            //    { "get_update_Is_send", new MS_Dic_update_Is_send(Log)},

            //    //all socialActivist micro services
            //    {"get-AllSARows", new MS_Dic_get_AllSARows(Log) },
            //    {"update-AddMoneyStatus", new MS_Dic_update_AddMoneyStatus(Log)},

            //    //all product micro services
            //    {"delete-CompanyProduct", new MS_Dic_delete_CompanyProduct(Log)},
            //    {"get-AllMyProduct", new MS_Dic_get_AllMyProduct(Log)},
            //    {"get-OrderDetail", new MS_Dic_get_OrderDetail(Log)},
            //    {"get-ProductListForActivist", new MS_Dic_get_ProductListForActivist(Log)},
            //    {"get-ProductPerCompany", new MS_Dic_get_ProductPerCompany(Log)},
            //    { "post-sendToOrderDetails", new MS_Dic_post_sendToOrderDetails(Log)},

            //    //all NPO micro services
            //    {"get-AllNPORows", new MS_Dic_get_AllNPORows(Log)},

            //    //all campaigns micro services
            //    {"get-AllCampaigns", new MS_Dic_get_AllCampaigns(Log)},
            //    {"get-AllCampaignsByNPO_code", new MS_Dic_get_AllCampaignsByNPO_code(Log)},

            //    //all BCompany micro services
            //    {"get-AllSARows", new MS_Dic_get_AllCompanyRows(Log)},

            //    //all tweeter micro services
            //    {"Post-tweet", new MS_Dic_Post_tweet(Log)},
            //    {"post-MakeATweet", new MS_Dic_post_MakeATweet(Log)},
            //    {"get-UpdateMoneyStatus", new MS_Dic_get_UpdateMoneyStatus(Log)},
            //    {"get-AllTwitted", new MS_Dic_get_AllTwitted(Log)},
            //};

        }
    }
}
