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
    public class MS_Dic_update_Is_Approved : BaseCommand, ICommand
    {
        public MS_Dic_update_Is_Approved(LogManager log) : base(log) { }

        public (string, object) Run(params object[] arg)
        {
            try
            {
                Log.LogEvent(@"Entities \ commands \ MS_Dic_update_Is_Approved \ Run, ran Successfully - ");
                M_Register_Applications Is_ApprovedUpdate = System.Text.Json.JsonSerializer.Deserialize<M_Register_Applications>((string)arg[2]);
                MainManager.Instance.UsersManager.UpdateApproveUserInDB(Is_ApprovedUpdate);
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
