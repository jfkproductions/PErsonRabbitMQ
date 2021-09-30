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
using System.Collections.Generic;
using System.Net.Http;
using FnPerson.Classes;
using TIH.Common.RedisCacheHandler;

namespace FnPerson.Functions
{
    public class GetPartyRoleInAgreementById 
    {
        //[ApiExplorerSettings(GroupName = "PartyRoleInAgreement")]

        private readonly PartyContext _context;
        private readonly ICacheServiceClient Redisdatabase;
        public GetPartyRoleInAgreementById(PartyContext context, ICacheServiceClient _database)
        {
            _context = context;
            Redisdatabase = _database;
        }

        //private static string key = TelemetryConfiguration.Active.InstrumentationKey = System.Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY", EnvironmentVariableTarget.Process);
        //private static TelemetryClient telemetry = new TelemetryClient() { InstrumentationKey = key };

        [FunctionName("GetPartyRoleInAgreementById")]
        [ProducesResponseType(typeof(PartyRoleInAgreementArrayObject), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [Route("PartyRoleInAgreement/{Id}")]
 
        //[OpenApiParameter("Id", In = ParameterLocation.Path, Required = true, Type = typeof(int))]

        public async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", "put", Route = "PartyRoleInAgreement/{Id}")] HttpRequest req,
            ILogger log, ExecutionContext context, string Id)
        {
            string _errLog = "Function V1.3";
            GetFunctions getFunctions = new GetFunctions(_context,Redisdatabase);
            DeleteFunctions deleteFunctions = new DeleteFunctions(_context, Redisdatabase);
            PutFunctions putFunctions = new PutFunctions(_context, Redisdatabase);


            try
            {
                //DateTime start = DateTime.UtcNow;

                //telemetry.Context.Operation.Id = context.InvocationId.ToString();
                //telemetry.Context.Operation.Name = "cs-http";

                //telemetry.TrackEvent("PersonById Function called");
                //telemetry.TrackMetric("Test Metric", DateTime.Now.Millisecond);

                _errLog += "get PartyRoleInAgreement data by id";
                log.LogInformation(_errLog);
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);

                if (req.Method == "GET")
                    return await getFunctions.RequestGetPartyRoleInAgreement(requestBody, null, Id);

                if (req.Method == "DELETE")
                    return await deleteFunctions.RequestDeletePartyRoleInAgreement(Id);
                if (req.Method == "PUT")
                    return await putFunctions.RequestputPartyRoleInAgreement(requestBody, Id);
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
                log.LogInformation(_errLog + ex.Message);
                //telemetry.Context.Operation.Name = "cs-http";

                //telemetry.TrackEvent("PersonById Error");
                //telemetry.TrackException(ex);

                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex.Message + ":" + ex.StackTrace))
                };
            }
            finally
            {
                if (getFunctions != null)
                    getFunctions = null;
                if (deleteFunctions != null)
                    deleteFunctions = null;
                if (putFunctions != null)
                    putFunctions = null;
            }
        }
    }
}
