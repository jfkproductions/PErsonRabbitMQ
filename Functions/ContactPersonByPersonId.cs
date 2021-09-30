using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Party_Dll.Models;
using FnPerson.Classes;
using TIH.Common.RedisCacheHandler;
using System.Net.Http;

namespace FnPerson
{
    public class ContactPersonByPersonId
    {
        private readonly PartyContext _context;
        GetFunctions getFunctions;

        public ContactPersonByPersonId(PartyContext context, ICacheServiceClient _database)
        {
            _context = context;
            getFunctions = new GetFunctions(_context, _database);
        }

        [FunctionName("ContactPersonByPersonId")]
        public async Task<HttpResponseMessage> Run(
             [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ContactPersonByPersonId/{Id}")] HttpRequest req,
            ILogger log, string Id)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);

                if (req.Method == "GET")
                {
                    //return await getFunctions.RequestGetContactPerson(Id);
                    return new HttpResponseMessage
                    {
                        Content = new StringContent("Service no longer in use"),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };

                }
                else
                {
                    return new HttpResponseMessage
                    {
                        Content = new StringContent("Incorrect Operation"),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex.Message))
                };
            }
        }
    }
}
