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
using TIH.Common.RedisCacheHandler;
using System.Net.Http;
using FnPerson.Classes;
using System.Net.Http.Headers;
using RoleAndRelationship_Dal.Models;
using RegistrationDAL.Models;
using ContactAndPlaceDAL.Models;
using Agreement_DAL.Models;

namespace FnPerson
{
    public class PrincipleMemberByPersonId
    {
        private readonly PartyContext _partyContext;
        private readonly RoleAndRelationshipContext _roleAndRelationshipContext;
        private readonly AgreementsContext _agreementsContext;
        private readonly ContactAndPlaceContext _contactAndPlaceContext;
        private readonly RegistrationContext _registrationContext;
        GetFunctions getFunctions;
        DeleteFunctions deleteFunctions; 
        public PrincipleMemberByPersonId(PartyContext _context, ICacheServiceClient _database)
        {
            _partyContext = _context;
            getFunctions = new GetFunctions(_context, _database);
            deleteFunctions = new DeleteFunctions(_context, _database);

            _roleAndRelationshipContext = new RoleAndRelationshipContext();
            _agreementsContext = new AgreementsContext();
            _contactAndPlaceContext = new ContactAndPlaceContext();
            _registrationContext = new RegistrationContext(); 


        }

        [FunctionName("PrincipleMemberByPersonId")]
        public async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", Route = "PrincipleMemberByPersonId/{Id}")] HttpRequest req,
            ILogger log, string Id)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);

                if (req.Method == "GET")
                {
                    //return await getFunctions.RequestGetPrincipleMember(Id);
                    return new HttpResponseMessage
                    {
                        Content = new StringContent("Service no longer in use"),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };

                }
                if (req.Method == "DELETE")
                {
                    return await deleteFunctions.RequestDeletePrincipleMember(Id);
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
