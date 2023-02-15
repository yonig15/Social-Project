using MyUtilities_CS_yoni;
using SocialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities.commands.User_Command
{
    public class MS_Dic_post_Company : BaseCommand, ICommand
    {

        public MS_Dic_post_Company(LogManager log) : base(log) { }

        public (string, object) Run(params object[] arg)
        {
            try
            {
                Log.LogEvent(@"Entities \ commands \ MS_Dic_post_Company \ Run, ran Successfully - ");
                M_BusinessCompany CompanyForm = new M_BusinessCompany();
                CompanyForm = System.Text.Json.JsonSerializer.Deserialize<M_BusinessCompany>((string)arg[2]);
                MainManager.Instance.UsersManager.SendCompanyFormToDB(CompanyForm);
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
