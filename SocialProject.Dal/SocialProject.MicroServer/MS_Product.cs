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
    public static class MS_Product
    {
        [FunctionName("MS_Product")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "Product/{action}/{value?}/{value2?}")] HttpRequest req,
        string action, string value, string value2, ILogger log)
        {
            string requestBody;
            string responseMessage;

            switch (action)
            {
                //****************************************All Get Request*****************************


                case "get-AllMyProduct":

                    try
                    {
                        MainManager.Instance.UsersManager.ShowAllMyProductForActivistFromDB(value);
                        responseMessage = JsonConvert.SerializeObject(MainManager.Instance.UsersManager.getAllMyProductForActivist);
                        return new OkObjectResult(responseMessage);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                case "get-ProductPerCompany":

                    try
                    {
                        MainManager.Instance.UsersManager.ShowProductListFromDB(value);
                        responseMessage = JsonConvert.SerializeObject(MainManager.Instance.UsersManager.getProductList);
                        return new OkObjectResult(responseMessage);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                case "get-ProductListForActivist":

                    try
                    {
                        MainManager.Instance.UsersManager.ShowProductListForActivistFromDB(value);
                        responseMessage = JsonConvert.SerializeObject(MainManager.Instance.UsersManager.getProductListForActivist);
                        return new OkObjectResult(responseMessage);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                case "get-OrderDetail":

                    try
                    {
                        MainManager.Instance.UsersManager.ShowOrderDetailForCompanyFromDB(value);
                        responseMessage = JsonConvert.SerializeObject(MainManager.Instance.UsersManager.getOrderDetail);
                        return new OkObjectResult(responseMessage);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                // *********************************************All Post Request******************************

                case "post-sendToOrderDetails":

                    try
                    {
                        M_Order m_Order = new M_Order();
                        m_Order = System.Text.Json.JsonSerializer.Deserialize<M_Order>(req.Body);
                        MainManager.Instance.AllFormsManager.SendOrderDetailsFormToDB(m_Order, int.Parse(value));
                        break;
                    }
                    catch (Exception)
                    {

                        throw;
                    }


                // *********************************************All Delete Request******************************

                case "delete-CompanyProduct":

                    try
                    {
                        MainManager.Instance.UsersManager.Delete_Product(value);

                        break;
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
