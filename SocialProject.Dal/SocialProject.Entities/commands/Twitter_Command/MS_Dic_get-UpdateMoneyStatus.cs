using MyUtilities_CS_yoni;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities.commands.Twitter_Command
{
    public class MS_Dic_get_UpdateMoneyStatus : BaseCommand, ICommand
    {
        public MS_Dic_get_UpdateMoneyStatus(LogManager log) : base(log) { }

        public (string, object) Run(params object[] arg)
        {
            try
            {
                Log.LogEvent(@"Event: Entities \ commands \ MS_Dic_get_UpdateMoneyStatus \ Run, ran Successfully - ");

                MainManager.Instance.twitterManager.ShowNewMoneyStatusForActivistFromDB((string)arg[0], (string)arg[1]);
                string responseMessage = JsonConvert.SerializeObject(MainManager.Instance.twitterManager.getNewMoneyStatusForActivist);
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
