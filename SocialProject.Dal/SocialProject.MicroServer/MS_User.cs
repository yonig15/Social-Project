using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SocialProject.Entities;
using SocialProject.Model;

namespace SocialProject.MicroServer
{
    public static class MS_User
    {
        [FunctionName("MS_User")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "Users/{action}/{value?}/{value2?}")] HttpRequest req,
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




//string requestBody;
//string responseMessage;
//string Auth0BearerCode = $"Bearer {MainManager.Instance.M_Configuration.Auth0BearerCode}";

//switch (action)
//{

//    case "get-RolesData":

//        try
//        {
//            var rolesURL = $"https://dev-yvfkvt7guh4kvmut.us.auth0.com/api/v2/users/{value}/roles";
//            var client = new RestClient(rolesURL);
//            var request = new RestRequest("", Method.Get);
//            request.AddHeader("authorization", Auth0BearerCode);
//            var response = client.Execute(request);
//            if (response.IsSuccessful)
//            {
//                var json = JArray.Parse(response.Content);
//                return new OkObjectResult(json);
//            }
//            else
//            {
//                return new NotFoundResult();
//            }
//        }
//        catch (Exception)
//        {

//            throw;
//        }

//    case "get-UserInfoData":

//        try
//        {
//            MainManager.Instance.UsersManager.get_UserInfo_FromDB(value, value2);
//            responseMessage = JsonConvert.SerializeObject(MainManager.Instance.UsersManager.getUserInfo);
//            return new OkObjectResult(responseMessage);
//        }
//        catch (Exception)
//        {
//            throw;
//        }

//    case "get-Pending":

//        try
//        {
//            responseMessage = System.Text.Json.JsonSerializer.Serialize(MainManager.Instance.UsersManager.get_Pending_FromDB(value));
//            return new OkObjectResult(responseMessage);
//        }
//        catch (Exception)
//        {

//            throw;
//        }

//    case "get-PendingList":

//        try
//        {
//            MainManager.Instance.UsersManager.ShowAllPendingListFromDB();
//            responseMessage = JsonConvert.SerializeObject(MainManager.Instance.UsersManager.getPendingList);
//            return new OkObjectResult(responseMessage);
//        }
//        catch (Exception)
//        {

//            throw;
//        }



//    case "post-ContactUs":

//        try
//        {
//            M_ContactUs ContacUSForm = new M_ContactUs();
//            ContacUSForm = System.Text.Json.JsonSerializer.Deserialize<M_ContactUs>(req.Body);
//            MainManager.Instance.UsersManager.SendContactUsFormToDB(ContacUSForm);
//            break;
//        }
//        catch (Exception)
//        {

//            throw;
//        }

//    case "post-SocialActivist":

//        try
//        {
//            M_SocialActivist SocialActivistForm = new M_SocialActivist();
//            SocialActivistForm = System.Text.Json.JsonSerializer.Deserialize<M_SocialActivist>(req.Body);
//            MainManager.Instance.UsersManager.SendSocialActivistFormToDB(SocialActivistForm);
//            break;
//        }
//        catch (Exception)
//        {

//            throw;
//        }

//    case "post-NPO":

//        try
//        {
//            M_NonProfitOrganization NPOForm = new M_NonProfitOrganization();
//            NPOForm = System.Text.Json.JsonSerializer.Deserialize<M_NonProfitOrganization>(req.Body);
//            MainManager.Instance.UsersManager.SendNPOFormToDB(NPOForm);
//            break;
//        }
//        catch (Exception)
//        {

//            throw;
//        }

//    case "post-Company":

//        try
//        {
//            M_BusinessCompany CompanyForm = new M_BusinessCompany();
//            CompanyForm = System.Text.Json.JsonSerializer.Deserialize<M_BusinessCompany>(req.Body);
//            MainManager.Instance.UsersManager.SendCompanyFormToDB(CompanyForm);
//            break;
//        }
//        catch (Exception)
//        {

//            throw;
//        }

//    case "update-Is_Approved":

//        try
//        {
//            requestBody = await new StreamReader(req.Body).ReadToEndAsync();
//            M_Register_Applications Is_ApprovedUpdate = System.Text.Json.JsonSerializer.Deserialize<M_Register_Applications>(requestBody);
//            MainManager.Instance.UsersManager.UpdateApproveUserInDB(Is_ApprovedUpdate);
//            break;
//        }
//        catch (Exception)
//        {

//            throw;
//        }

//    case "update-Is_Active":

//        try
//        {
//            requestBody = await new StreamReader(req.Body).ReadToEndAsync();
//            M_Campaign Is_ActiveUpdate = System.Text.Json.JsonSerializer.Deserialize<M_Campaign>(requestBody);
//            MainManager.Instance.UsersManager.UpdateIs_ActiveInDB(Is_ActiveUpdate);
//            break;
//        }
//        catch (Exception)
//        {

//            throw;
//        }

//    case "post-AddOrEditCampaigns":

//        try
//        {
//            if (value == "Add")
//            {
//                M_Campaign m_Campaign = new M_Campaign();
//                m_Campaign = System.Text.Json.JsonSerializer.Deserialize<M_Campaign>(req.Body);
//                MainManager.Instance.UsersManager.SendCampaignForm_ToDB(m_Campaign);
//                break;
//            }
//            else if (value == "Edit")
//            {
//                M_Campaign m_Campaign = new M_Campaign();
//                m_Campaign = System.Text.Json.JsonSerializer.Deserialize<M_Campaign>(req.Body);
//                MainManager.Instance.UsersManager.SendEditCampaignForm_ToDB(m_Campaign);
//                break;
//            }
//        }
//        catch (Exception)
//        {

//            throw;
//        }

//        break;

//    case "update-Is_send":

//        try
//        {
//            requestBody = await new StreamReader(req.Body).ReadToEndAsync();
//            M_Order Is_sendUpdate = System.Text.Json.JsonSerializer.Deserialize<M_Order>(requestBody);
//            MainManager.Instance.UsersManager.UpdateIs_sendInDB(Is_sendUpdate);
//            break;
//        }
//        catch (Exception)
//        {

//            throw;
//        }

//    case "post-AddOrEditProduct":

//        try
//        {
//            if (value == "Add")
//            {
//                M_Product m_Product = new M_Product();
//                m_Product = System.Text.Json.JsonSerializer.Deserialize<M_Product>(req.Body);
//                MainManager.Instance.UsersManager.SendProductForm_ToDB(m_Product);
//                break;
//            }
//            else if (value == "Edit")
//            {
//                M_Product m_Product = new M_Product();
//                m_Product = System.Text.Json.JsonSerializer.Deserialize<M_Product>(req.Body);
//                MainManager.Instance.UsersManager.SendEditProductForm_ToDB(m_Product);
//                break;
//            }
//        }
//        catch (Exception)
//        {

//            throw;
//        }

//        break;


//    default:
//        break;
//}