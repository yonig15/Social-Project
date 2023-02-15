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
    public static class MS_BCompany
    {
        [FunctionName("MS_BCompany")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "BCompany/{action}/{value?}/{value2?}")] HttpRequest req,
        string action, string value, string value2, ILogger log)
        {
            string requestBody1 = await req.ReadAsStringAsync();

            try
            {
                (string response, object result) = MainManager.Instance.CommandsManager.CommandList[action].Run(value, value2, requestBody1);
                switch (response)
                {
                    case "OkObjectResult":
                        return new OkObjectResult(result);
                    case "NotFoundResult":
                        return new NotFoundResult();
                    case "BadRequestObjectResult":
                        return new BadRequestObjectResult(result);
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MainManager.Instance.LogManager.LogException($"exception while execute {action} command: ", ex);
            }
         
            return null;
        }
    }
}





//string responseMessage;

//switch (action)
//{
//    //****************************************All Get Request*****************************

//    case "get-AllCompanyRows":

//        try
//        {
//            MainManager.Instance.BCompanyManager.ShowCompanyListFromDB();
//            responseMessage = JsonConvert.SerializeObject(MainManager.Instance.BCompanyManager.getCompanyList);
//            return new OkObjectResult(responseMessage);
//        }
//        catch (Exception)
//        {

//            throw;
//        }

//}