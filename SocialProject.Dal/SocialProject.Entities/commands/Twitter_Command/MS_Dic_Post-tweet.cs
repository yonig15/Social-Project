using MyUtilities_CS_yoni;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SocialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities.commands.Twitter_Command
{
    public class MS_Dic_Post_tweet : BaseCommand, ICommand
    {
        public MS_Dic_Post_tweet(LogManager log) : base(log) { }

        public (string, object) Run(params object[] arg)
        {
            try
            {
                Log.LogEvent(@"Event: Entities \ commands \ MS_Dic_Post_tweet \ Run, ran Successfully - ");

                M_Campaign m_Campaign1 = new M_Campaign();
                m_Campaign1 = System.Text.Json.JsonSerializer.Deserialize<M_Campaign>((string)arg[2]);
                MainManager.Instance.twitterManager.SendTweetToDB(m_Campaign1, (string)arg[0]);
                return ("OkObjectResult", "success post tweet");

            }
            catch (Exception ex)
            {
                Log.LogException($@"Exception: An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return ("BadRequestObjectResult", "Error while getting role: " + ex.Message);
            }
        }
    }
}
