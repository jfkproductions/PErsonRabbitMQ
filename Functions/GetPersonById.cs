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
//using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
//using Microsoft.ApplicationInsights;
//using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Localization;
using Microsoft.OpenApi.Validations.Rules;
using TIH.Common.RedisCacheHandler;

namespace FnPerson
{
    [ApiExplorerSettings(GroupName = "Person")]

    public class GetPersonById
    {
        private readonly PartyContext _context;
        private readonly ICacheServiceClient Redisdatabase;
        public GetPersonById(PartyContext context, ICacheServiceClient _database)
        {
            _context = context;
            Redisdatabase = _database;
        }

        //private static string key = TelemetryConfiguration.Active.InstrumentationKey = System.Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY", EnvironmentVariableTarget.Process);
        //private static TelemetryClient telemetry = new TelemetryClient() { InstrumentationKey = key };

        [FunctionName("PersonById")]
        [ProducesResponseType(typeof(PersonArrayObject), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [Route("Person/{Id}")]
        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="Id"></param>        
        public async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get","delete","put", Route = "Person/{Id}")] HttpRequest req,
            ILogger log, ExecutionContext context,string Id)
        {
            string _errLog = "Function V1.3";
            GetFunctions getFunctions = new GetFunctions(_context,Redisdatabase);
            DeleteFunctions deleteFunctions = new DeleteFunctions(_context, Redisdatabase);
            PutFunctions putFunctions = new PutFunctions(_context, Redisdatabase);


            try
            {
                
                _errLog += "get data by id";
                log.LogInformation(_errLog);
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);

                if (req.Method == "GET")
                {
                    var Person = getFunctions.RequestGetPerson(requestBody, null, Id);
                    return getFunctions.ReturnPersonCleanData(Person);
                }
                if (req.Method == "DELETE")
                    return await deleteFunctions.RequestDeletePerson(Id);
                if (req.Method == "PUT")
                {
                    List<PersonArrayObject> persons = null;
                    try
                    {
                        persons = JsonConvert.DeserializeObject<List<PersonArrayObject>>(requestBody);
                    }
                    catch
                    {
                        var person = JsonConvert.DeserializeObject<PersonArrayObject>(requestBody);
                        persons = new List<PersonArrayObject>();
                        persons.Add(person);
                    }

                    var personRecord = putFunctions.RequestPutPerson(persons, Id);
                    return getFunctions.ReturnPersonCleanData(personRecord);
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
                log.LogInformation(_errLog + ex.Message);
                //telemetry.Context.Operation.Name = "cs-http";

                //telemetry.TrackEvent("PersonById Error");
                //telemetry.TrackException(ex);

                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(  ex.Message + ":" + ex.StackTrace))
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
