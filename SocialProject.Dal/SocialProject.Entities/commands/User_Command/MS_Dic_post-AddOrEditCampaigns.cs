using MyUtilities_CS_yoni;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SocialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities.commands.User_Command
{
    public class MS_Dic_post_AddOrEditCampaigns : BaseCommand, ICommand
    {

        public MS_Dic_post_AddOrEditCampaigns(LogManager log) : base(log) { }

        public (string, object) Run(params object[] arg)
        {
            try
            {
                Log.LogEvent(@"Entities \ commands \ MS_Dic_post_AddOrEditCampaigns \ Run, ran Successfully - ");
                if (arg[0] == "Add")
                {
                    M_Campaign m_Campaign = new M_Campaign();
                    m_Campaign = System.Text.Json.JsonSerializer.Deserialize<M_Campaign>((string)arg[2]);
                    MainManager.Instance.UsersManager.SendCampaignForm_ToDB(m_Campaign);
                }
                else if (arg[0] == "Edit")
                {
                    M_Campaign m_Campaign = new M_Campaign();
                    m_Campaign = System.Text.Json.JsonSerializer.Deserialize<M_Campaign>((string)arg[2]);
                    MainManager.Instance.UsersManager.SendEditCampaignForm_ToDB(m_Campaign); 
                }
                return ("OkObjectResult", "success post Request");
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return ("BadRequestObjectResult", "Error while getting role: " + ex.Message);
            }
          
        }
    }
}
