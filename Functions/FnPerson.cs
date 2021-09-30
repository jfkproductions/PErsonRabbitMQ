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
using System.Collections.Generic;
using FnPerson.Classes;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using TIH.Common.RedisCacheHandler;
using RabbitMQ.Client.Events;
using System.Web.Http.Hosting;
using System.Web.Http;
using System.Linq;
using Moq;

namespace FnPerson
{


    [ApiExplorerSettings(GroupName = "Person")]
    public class FnPerson
    {

        private readonly PartyContext _context;
        private readonly ILogger _log;
        private readonly ICacheServiceClient Redisdatabase;
        GetFunctions getFunctions;
        PostFunctions postFunctions; 
        DeleteFunctions deleteFunctions;
        PutFunctions putFunctions;

        // MessageLogger MessageLogger; 
        [Obsolete]
        private static readonly string key = TelemetryConfiguration.Active.InstrumentationKey = System.Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY", EnvironmentVariableTarget.Process);
        [Obsolete]
        private static readonly TelemetryClient telemetry = new TelemetryClient() { InstrumentationKey = key };


        public FnPerson(PartyContext context, ICacheServiceClient _database)
        {
            _context = context;
            //_log = log; 
            getFunctions = new GetFunctions(_context, _database);
            postFunctions = new PostFunctions(_context, _database); 
            deleteFunctions = new DeleteFunctions(_context,_database);
            putFunctions = new PutFunctions(_context, _database);
            //MessageLogger = new MessageLogger(_log); 
        }



        /// <summary>
        /// this is a crud api for person
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        /// 
    

        [FunctionName("FnPerson")]
        #region Main
        [ProducesResponseType(typeof(PersonArrayObject), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<HttpResponseMessage> Run(
         //   [RabbitMQTrigger("TIHTest", ConnectionStringSetting = "rabbitMQConnectionAppSetting")] string myQueueItem,
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "delete", "put", Route = "Person")] HttpRequest req,
           
         //   ExecutionContext context,
            ILogger log)
        {
            
            string _errLog = "Function V1.3";
            try
            {
                // check rabbitMQ Value 2021-08-17
               // var MQBody = System.Text.Encoding.UTF8.GetString(MQPersonItem.Body);
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
               // var requestBody = string.IsNullOrWhiteSpace(MQBody) ? HttprequestBody : MQBody;
                // This seriasly needs to be cleaned up 
                // Look at the new enum functions and get classes written , to many if statements 
                if (!string.IsNullOrEmpty (requestBody))
                {
                    dynamic data = JsonConvert.DeserializeObject(requestBody);
                    _errLog += "get data test";
                    log.LogInformation(_errLog);
                    string mode = req?.Query["mode"];
                    string count = string.IsNullOrWhiteSpace(req?.Query["count"]) ? string.Empty : req?.Query["COUNT"].ToString().ToUpper();
                    string where = string.IsNullOrWhiteSpace(req?.Query["where"]) ? string.Empty : req?.Query["WHERE"].ToString().ToUpper();
                    string PersonIDreq = req?.Query["PersonID"];
                    string IdNumber = req?.Query["IdNumber"];
                    string agreementIdQuery = req?.Query["agreementKindId"];
                    int agreementKindId = int.Parse(agreementIdQuery ?? "0");


                    if (req.Method == "GET")
                    {
                        if (IdNumber != null)
                        {
                            return await getFunctions.RequestGetPersonByIdNumberAsync(agreementKindId, IdNumber);
                        }
                        else
                        {
                            var Person = getFunctions.RequestGetPerson(requestBody, mode, PersonIDreq, count, where);
                            return getFunctions.ReturnPersonCleanData(Person, mode);
                        }
                    }
                    if (req.Method == "POST")
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

                        var Person = postFunctions.RequestPostPerson(persons, mode);

                        return getFunctions.ReturnPersonCleanData(Person, mode);

                    }

                    if (req.Method == "DELETE")
                        return await deleteFunctions.RequestDeletePerson(PersonIDreq);

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
                        var Person = putFunctions.RequestPutPerson(persons, PersonIDreq);
                        return getFunctions.ReturnPersonCleanData(Person, mode);
                    }
                    else
                    {
                        return new HttpResponseMessage
                        {
                            Content = new StringContent("Incorrect Operation")
                        };
                    }
                }
                else
                {
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject("Invalid  Body Send "))
                    };
                }
               
            }

            catch (Exception ex)
            {
                log.LogInformation(_errLog + ex.Message + ":" + ex.StackTrace);
                telemetry.Context.Operation.Name = "cs-http";

                telemetry.TrackEvent("FnPerson Error");
                telemetry.TrackException(ex);
                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(_errLog + ex.Message + ":" + ex.StackTrace))
                };
            }
        }
        #endregion
        [FunctionName("FnPersonNameandEmail")]
        #region Main
        [ProducesResponseType(typeof(PersonArrayObject), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<HttpResponseMessage> RunFnPersonNameandEmail(
          [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "PersonNameandEmail")] HttpRequest req, ExecutionContext context, ILogger log)
        {
            string _errLog = "Function V1.3";
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                _errLog += "get data test";
                log.LogInformation(_errLog);
                string mode = req?.Query["mode"];
                PersonIDList PersonIds = JsonConvert.DeserializeObject<PersonIDList>(requestBody);

                if (req.Method == "POST")
                {
                    return await getFunctions.RequestGetByPersonNameEmail(PersonIds.PersonIds, mode);
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
                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(_errLog + ex.Message + ":" + ex.StackTrace))
                };
            }
        }
        #endregion

    }
}
