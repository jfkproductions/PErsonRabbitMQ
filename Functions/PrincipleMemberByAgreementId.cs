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

namespace FnPerson.Functions
{
    public class PrincipleMemberByAgreementId
    {
        private readonly PartyContext _context;
        GetFunctions getFunctions;

        public PrincipleMemberByAgreementId(PartyContext context, ICacheServiceClient _database)
        {
            _context = context;
            getFunctions = new GetFunctions(_context, _database);
        }

        [FunctionName("PrincipleMemberByAgreementId")]
        public async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "PrincipleMemberByAgreementId/{Id}")] HttpRequest req,
            ILogger log, string Id)
        {
            try
            {

                if (req.Method == "GET")
                {
                    return await getFunctions.RequestGetPrinciplememberByAgreementId(Id);
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
