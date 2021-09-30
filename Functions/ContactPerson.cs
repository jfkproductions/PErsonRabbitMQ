using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using Party_Dll.Models;
using FnPerson.Classes;
using TIH.Common.RedisCacheHandler;

namespace FnPerson
{
    [ApiExplorerSettings(GroupName = "ContactPerson")]

    public class ContactPerson
    {
        private readonly PartyContext _context;
        private readonly ILogger _log;
        PutFunctions putFunctions;
        PostFunctions postFunctions;
        GetFunctions getFunctions; 

        public ContactPerson(PartyContext context, ICacheServiceClient _database)
        {
            _context = context;
            putFunctions = new PutFunctions(_context, _database);
            postFunctions = new PostFunctions(_context, _database);
            getFunctions = new GetFunctions(_context, _database); 
        }

        [FunctionName("ContactPerson")]
        [ProducesResponseType(typeof(PersonArrayObject), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<HttpResponseMessage> Run(
              [HttpTrigger(AuthorizationLevel.Anonymous, "get", "put", "post", Route = "ContactPerson")] HttpRequest req, ExecutionContext context, ILogger log)
        {
            try
            {
                string PersonID = req?.Query["PersonID"];
                string AgreementID = req?.Query["AgreementID"];

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                if (req.Method == "PUT")
                {
                    ContactPersonDetails putContactPerson = JsonConvert.DeserializeObject<ContactPersonDetails>(requestBody);
                    return await putFunctions.RequestPutContactPerson(putContactPerson);

                }
                if (req.Method == "POST")
                {
                    ContactPersonDetails postContactPerson = JsonConvert.DeserializeObject<ContactPersonDetails>(requestBody);
                    var res = await postFunctions.RequestPostContactPerson(postContactPerson);
                    return res;

                }
                if (req.Method == "GET")
                {
                    if(PersonID != null && AgreementID != null)
                    {
                        return await getFunctions.RequestGetContactPerson(PersonID, AgreementID); 
                    }
                    else
                    {
                        return new HttpResponseMessage
                        {
                            Content = new StringContent("Please provide PersonID and AgreementID"),
                            StatusCode = System.Net.HttpStatusCode.InternalServerError

                        };
                    }
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
            catch(Exception ex)
            {
                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex.Message))
                };

            }
        }
    }
}
