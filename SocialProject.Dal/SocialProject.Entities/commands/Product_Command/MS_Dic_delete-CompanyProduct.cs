using MyUtilities_CS_yoni;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities.commands.Product_Command
{
    public class MS_Dic_delete_CompanyProduct : BaseCommand, ICommand
    {
        public MS_Dic_delete_CompanyProduct(LogManager log) : base(log) { }

        public (string, object) Run(params object[] arg)
        {
            try
            {
                Log.LogEvent(@"Event: Entities \ commands \ MS_Dic_delete_CompanyProduct \ Run, ran Successfully - ");
                MainManager.Instance.ProductManager.Delete_Product((string)arg[0]);

                return ("OkObjectResult", "success Delete_Product Request");
            }
            catch (Exception ex)
            {
                Log.LogException($@"Exception: An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return ("BadRequestObjectResult", "Error while getting role: " + ex.Message);
            }
        }
    }
}
