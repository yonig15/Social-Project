using MyUtilities_CS_yoni;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities.commands.User_Command
{
    public class MS_Dic_get_PendingList : BaseCommand, ICommand
    {
        public MS_Dic_get_PendingList(LogManager log) : base(log) { }

        public (string, object) Run(params object[] arg)
        {
            try
            {
                Log.LogEvent(@"Entities \ commands \ MS_Dic_get_PendingList \ Run, ran Successfully - ");
                MainManager.Instance.UsersManager.ShowAllPendingListFromDB();
                string responseMessage = JsonConvert.SerializeObject(MainManager.Instance.UsersManager.getPendingList);  
                return ("OkObjectResult", responseMessage);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return ("BadRequestObjectResult", "Error while getting role: " + ex.Message);

            }
        }
    }
}
