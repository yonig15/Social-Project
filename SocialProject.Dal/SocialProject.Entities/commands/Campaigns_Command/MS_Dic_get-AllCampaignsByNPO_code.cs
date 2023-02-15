using MyUtilities_CS_yoni;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities.commands.Campaigns_Command
{
    public class MS_Dic_get_AllCampaignsByNPO_code : BaseCommand, ICommand
    {
        public MS_Dic_get_AllCampaignsByNPO_code(LogManager log) : base(log) { }

        public (string, object) Run(params object[] arg)
        {
            try
            {
                Log.LogEvent(@"Event: Entities \ commands \ MS_Dic_get_AllCampaignsByNPO_code \ Run, ran Successfully - ");

                MainManager.Instance.CampaignsManager.ShowAllCampaignsListByNPOFromDB((string)arg[0]);
                string responseMessage = JsonConvert.SerializeObject(MainManager.Instance.CampaignsManager.getAllCampaignsByCode);
                return ("OkObjectResult", responseMessage);
            }
            catch (Exception ex)
            {
                Log.LogException($@"Exception: An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return ("BadRequestObjectResult", "Error while getting role: " + ex.Message);
            }
        }
    }
}
