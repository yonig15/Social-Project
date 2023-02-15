using MyUtilities_CS_yoni;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities.commands.NPO_Command
{
    public class MS_Dic_get_AllNPORows : BaseCommand, ICommand
    {
        public MS_Dic_get_AllNPORows(LogManager log) : base(log) { }

        public (string, object) Run(params object[] arg)
        {
            try
            {
                Log.LogEvent(@"Event: Entities \ commands \ MS_Dic_get_AllNPORows \ Run, ran Successfully - ");

                MainManager.Instance.NPOManager.ShowNPOListFromDB();
                string responseMessage = JsonConvert.SerializeObject(MainManager.Instance.NPOManager.getNPOList);
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
