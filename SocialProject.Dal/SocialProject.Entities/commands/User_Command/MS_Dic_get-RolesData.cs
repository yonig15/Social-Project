using MyUtilities_CS_yoni;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities.commands.User_Command
{
    public class MS_Dic_get_RolesData : BaseCommand ,ICommand
    {
        public MS_Dic_get_RolesData (LogManager log) : base(log) { }
        public (string, object) Run(params object[] arg)
        {
            try
            {
                Log.LogEvent(@"Entities \ commands \ MS_Dic_get_RolesData \ Run, ran Successfully - ");
                string Auth0BearerCode = $"Bearer {MainManager.Instance.M_Configuration.Auth0BearerCode}";

                var rolesURL = $"https://dev-yvfkvt7guh4kvmut.us.auth0.com/api/v2/users/{arg[0]}/roles";
                var client = new RestClient(rolesURL);
                var request = new RestRequest("", Method.Get);
                request.AddHeader("authorization", Auth0BearerCode);
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    var json = JArray.Parse(response.Content);
                    return ("OkObjectResult", json);
                }
                else
                {
                    return ("NotFoundResult", null);          
                }
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                return ("BadRequestObjectResult", "Error while getting role: " + ex.Message);
            }
        }
    }
}
