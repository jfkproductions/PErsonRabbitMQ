using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Party_Dll.Models;
using TIH.Common.RedisCacheHandler;
using System.Net.Http;
using FnPerson.Classes;
using System.Net.Http.Headers;
using Agreement_DAL.Models;

namespace FnPerson.Functions
{
    class PrincipleMemberDuplicateCheck
    {
        private readonly PartyContext _partycontext;
        private readonly AgreementsContext _agreementcontext;
        GetFunctions getFunctions;
        DeleteFunctions deleteFunctions;
        public PrincipleMemberDuplicateCheck(PartyContext partycontext, AgreementsContext agreementcontext, ICacheServiceClient _database)
        {
            _partycontext = partycontext;
            _agreementcontext = agreementcontext;
            getFunctions = new GetFunctions(_partycontext, _agreementcontext, _database);
            deleteFunctions = new DeleteFunctions(_partycontext, _database);
        }
        [FunctionName("PrincipleMemberDuplicateCheck")]
        public async Task<HttpResponseMessage> Run(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
           ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                string IdNumber = req?.Query["IdNumber"];
                string agreementKindId = req?.Query["agreementKindId"];

                if (req.Method == "GET")
                {
                    var doesMemberExist = getFunctions.DoesPrincipleMemberExist( IdNumber, agreementKindId);
                    var obj = new { status = doesMemberExist };
                    var resp = new HttpResponseMessage()
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(obj, Formatting.Indented))
                    };
                    resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    return resp;
                }
                else
                {
                    return new HttpResponseMessage
                    {
                        Content = new StringContent("Incorrect Operation")
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
