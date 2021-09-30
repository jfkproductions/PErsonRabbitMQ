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
using System.Net.Http.Headers;

namespace FnPerson
{
    [ApiExplorerSettings(GroupName = "PrincipleMember")]
    public class PrincipleMember
    {
        private readonly PartyContext _context;
        private readonly ILogger _log;
        PutFunctions putFunctions;
        PostFunctions postFunctions;
        GetFunctions getFunctions; 

        public PrincipleMember(PartyContext context, ICacheServiceClient _database)
        {
            _context = context;
            putFunctions = new PutFunctions(_context, _database);
            postFunctions = new PostFunctions(_context, _database);
            getFunctions = new GetFunctions(_context, _database); 
        }

        [FunctionName("PrincipleMember")]

        [ProducesResponseType(typeof(PersonArrayObject), 200)]
        //[ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "put", "post", Route = "PrincipleMember")] HttpRequest req, ExecutionContext context, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //string name = req.Query["name"];

            try
            {
                string PersonID = req?.Query["PersonID"];
                string AgreementID = req?.Query["AgreementID"];

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
      
                if (req.Method == "PUT")
                {
                    PrincipleMemberDetails putPrincipleMember = JsonConvert.DeserializeObject<PrincipleMemberDetails>(requestBody);
                    return await putFunctions.RequestPutPrincipleMember(putPrincipleMember);
                  
                }
                if (req.Method == "POST")
                {
                    PrincipleMemberDetails postPrincipleMember = JsonConvert.DeserializeObject<PrincipleMemberDetails>(requestBody);
                    var res =  await postFunctions.RequestPostPrincipleMember(postPrincipleMember);
                    return res; 
                   
                }
                if(req.Method == "GET")
                {
                    if(PersonID != null && AgreementID != null)
                    {
                        return await getFunctions.RequestGetPrincipleMember(PersonID, AgreementID); 
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
                        Content = new StringContent("Incorrect Operation")
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
