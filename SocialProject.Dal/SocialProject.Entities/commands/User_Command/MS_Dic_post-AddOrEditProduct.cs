using MyUtilities_CS_yoni;
using Newtonsoft.Json.Linq;
using SocialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities.commands.User_Command
{
    public class MS_Dic_post_AddOrEditProduct : BaseCommand, ICommand
    {
        public MS_Dic_post_AddOrEditProduct(LogManager log) : base(log) { }

        public (string, object) Run(params object[] arg)
        {
            try
            {
                Log.LogEvent(@"Entities \ commands \ MS_Dic_post_AddOrEditProduct \ Run, ran Successfully - ");
                if (arg[0] == "Add")
                {
                    M_Product m_Product = new M_Product();
                    m_Product = System.Text.Json.JsonSerializer.Deserialize<M_Product>((string)arg[2]);
                    MainManager.Instance.UsersManager.SendProductForm_ToDB(m_Product);
                  
                }
                else if (arg[0] == "Edit")
                {
                    M_Product m_Product = new M_Product();
                    m_Product = System.Text.Json.JsonSerializer.Deserialize<M_Product>((string)arg[2]);
                    MainManager.Instance.UsersManager.SendEditProductForm_ToDB(m_Product);
                  
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
