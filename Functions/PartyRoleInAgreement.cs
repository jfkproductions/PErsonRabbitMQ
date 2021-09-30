using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

using FnPerson.Classes;
using Party_Dll.Models;
using TIH.Common.RedisCacheHandler;

namespace FnPerson.Functions
{
    public class PartyRoleInAgreement
    {
        private readonly PartyContext _context;
        PostFunctions postFunctions;
        private readonly ICacheServiceClient Redisdatabase;
        public PartyRoleInAgreement(PartyContext context, ICacheServiceClient _database)
        {
            _context = context;
            Redisdatabase = _database;
            postFunctions = new PostFunctions(_context, _database);
        }

        [FunctionName("PartyRoleInAgreement")]
        public async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "PartyRoleInAgreement")] HttpRequest req,
            ILogger log, ExecutionContext context)

        {
            string _errLog = "Function V1.3";
            try
            {
                //DateTime start = DateTime.UtcNow;

                //telemetry.Context.Operation.Id = context.InvocationId.ToString();
                //telemetry.Context.Operation.Name = "cs-http";

                //telemetry.TrackEvent("FnPerson Function called");
                //telemetry.TrackMetric("Test Metric", DateTime.Now.Millisecond);

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                _errLog += "get data ";
                log.LogInformation(_errLog);
                string mode = req?.Query["mode"];
                string PartyRoleInAgreementIDreq = req?.Query["PartyRoleInAgreementID"];
            
                if (req.Method == "POST")
                    //return await RequestPost(requestBody, mode);
                    return await postFunctions.RequestPostPartyRoleInAgreement(requestBody, mode);

                //if (req.Method == "DELETE")
                //    return await deleteFunctions.RequestDelete(PersonIDreq);
                //if (req.Method == "PUT")
                //    return await putFunctions.Requestput(requestBody, PersonIDreq);
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
                log.LogInformation(_errLog + ex.Message + ":" + ex.StackTrace);
                //telemetry.Context.Operation.Name = "cs-http";

                //telemetry.TrackEvent("FnPerson Error");
                //telemetry.TrackException(ex);
                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(_errLog + ex.Message + ":" + ex.StackTrace))
                };
            }
        }
    }
}
