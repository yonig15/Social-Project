using MyUtilities_CS_yoni;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SocialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities.commands.Product_Command
{
    public class MS_Dic_post_sendToOrderDetails : BaseCommand, ICommand
    {
        public MS_Dic_post_sendToOrderDetails(LogManager log) : base(log) { }

        public (string, object) Run(params object[] arg)
        {

            try
            {
                Log.LogEvent(@"Event: Entities \ commands \ MS_Dic_post_sendToOrderDetails \ Run, ran Successfully - ");

                M_Order m_Order = new M_Order();
                m_Order = System.Text.Json.JsonSerializer.Deserialize<M_Order>((string)arg[2]);
                MainManager.Instance.ProductManager.SendOrderDetailsFormToDB(m_Order, int.Parse((string)arg[0]));
                return ("OkObjectResult", "success post Request");
            }
            catch (Exception ex)
            {
                Log.LogException($@" Exception: An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return ("BadRequestObjectResult", "Error while getting role: " + ex.Message);
            }
        }
    }
}
