using MyUtilities_CS_yoni;
using SocialProject.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities.commands.User_Command
{
    public class MS_Dic_update_Is_Active : BaseCommand, ICommand
    {
        public MS_Dic_update_Is_Active(LogManager log) : base(log) { }

        public (string, object) Run(params object[] arg)
        {
            try
            {
                Log.LogEvent(@"Entities \ commands \ MS_Dic_update_Is_Active \ Run, ran Successfully - ");
                M_Campaign Is_ActiveUpdate = System.Text.Json.JsonSerializer.Deserialize<M_Campaign>((string)arg[2]);
                MainManager.Instance.UsersManager.UpdateIs_ActiveInDB(Is_ActiveUpdate);
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
