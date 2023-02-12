using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SocialProject.Entities;
using SocialProject.Model;

namespace SocialProject.MicroServer
{
    public static class MS_NPO
    {
        [FunctionName("MS_NPO")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "NPO/{action}/{value?}/{value2?}")] HttpRequest req,
        string action, string value, string value2, ILogger log)
        {
            string requestBody;
            string responseMessage;

            switch (action)
            {
                //****************************************All Get Request*****************************

                case "get-AllNPORows":

                    try
                    {
                        MainManager.Instance.UsersManager.ShowNPOListFromDB();
                        responseMessage = JsonConvert.SerializeObject(MainManager.Instance.UsersManager.getNPOList);
                        return new OkObjectResult(responseMessage);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
  

            }
            return null;
        }
    }
}
