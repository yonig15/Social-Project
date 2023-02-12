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

namespace SocialProject.MicroServer
{
    public static class MS_SocialActivist
    {
        [FunctionName("MS_SocialActivist")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "SocialActivist/{action}/{value?}/{value2?}")] HttpRequest req,
        string action, string value, string value2, ILogger log)
        {
            string requestBody;
            string responseMessage;

            switch (action)
            {
                //****************************************All Get Request*****************************
                case "get-AllSARows":

                    try
                    {
                        MainManager.Instance.UsersManager.ShowSocialActivistListFromDB();
                        responseMessage = JsonConvert.SerializeObject(MainManager.Instance.UsersManager.getSocialActivistList);
                        return new OkObjectResult(responseMessage);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                case "update-AddMoneyStatus":

                    try
                    {
                        MainManager.Instance.UsersManager.UpdateMoneyStatusInDB(value);
                        responseMessage = JsonConvert.SerializeObject(MainManager.Instance.UsersManager.getOrderDetail);
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
