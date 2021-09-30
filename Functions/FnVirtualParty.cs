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
using System.Net.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics.CodeAnalysis;
using FnPerson.Classes;
using System.Runtime.InteropServices;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using ErrorHandling.CommonClasses;
using TIH.Common.RedisCacheHandler;


namespace FnPerson.Functions
{
    [ApiExplorerSettings(GroupName = "VirtualParty")]
    public class FnVirtualParty
    {
        private readonly PartyContext _context;
        private readonly ILogger _log;
        private readonly ICacheServiceClient Redisdatabase;
        GetFunctions getFunctions;
        PostFunctions postFunctions;
        DeleteFunctions deleteFunctions;
        PutFunctions putFunctions;
        // MessageLogger MessageLogger; 
        private static string key = TelemetryConfiguration.Active.InstrumentationKey = System.Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY", EnvironmentVariableTarget.Process);
        private static TelemetryClient telemetry = new TelemetryClient() { InstrumentationKey = key };


        public FnVirtualParty(PartyContext context, ICacheServiceClient _database)
        {
            _context = context;
            //_log = log; 
            getFunctions = new GetFunctions(_context, _database);
            postFunctions = new PostFunctions(_context, _database);
            deleteFunctions = new DeleteFunctions(_context, _database);
            putFunctions = new PutFunctions(_context, _database);
            //MessageLogger = new MessageLogger(_log); 
        }


        [FunctionName("FnVirtualParty")]
        #region Main
        [ProducesResponseType(typeof(PersonArrayObject), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]

        public  async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "delete", "put", Route = "VirtualParty")] HttpRequest req, ExecutionContext context, ILogger log)
        {
            string _errLog = "Function V1.3";
            try
            {
                //DateTime start = DateTime.UtcNow;

                //telemetry.Context.Operation.Id = context.InvocationId.ToString();
                //telemetry.Context.Operation.Name = "cs-http";

                //telemetry.TrackEvent("FnPerson Function called");
                //telemetry.TrackMetric("Test Metric", DateTime.Now.Millisecond);

                //MessageLogger = new MessageLogger(log); 

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                _errLog += "get data test";
                log.LogInformation(_errLog);
                string mode = req?.Query["mode"];
                string PersonIDreq = req?.Query["PersonID"];

                if (req.Method == "GET")
                {
                }
                if (req.Method == "POST")
                {
                    VirtualParty virtualParty = JsonConvert.DeserializeObject<VirtualParty>(requestBody);

                    return new HttpResponseMessage
                    {
                        Content = new StringContent("Incorrect Operation")
                    };

                }

                if (req.Method == "DELETE")
                    return await deleteFunctions.RequestDeletePerson(PersonIDreq);

                if (req.Method == "PUT")
                {
                    VirtualParty virtualParty = JsonConvert.DeserializeObject<VirtualParty>(requestBody);
                    return new HttpResponseMessage
                    {
                        Content = new StringContent("Incorrect Operation")
                    };
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
                log.LogInformation(_errLog + ex.Message + ":" + ex.StackTrace);
                telemetry.Context.Operation.Name = "cs-http";

                telemetry.TrackEvent("VirtualParty Error");
                telemetry.TrackException(ex);
                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(_errLog + ex.Message + ":" + ex.StackTrace))
                };
            }
        }
        #endregion
    }
}
