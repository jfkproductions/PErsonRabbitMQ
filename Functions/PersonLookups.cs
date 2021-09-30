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
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using System.Collections.Generic;
using TIH.Common.RedisCacheHandler;

namespace FnPerson.Functions
{
    [ApiExplorerSettings(GroupName = "Lookups")]
    public  class PersonLookups
    {
        private readonly PartyContext _context;
        private GetFunctions getFunctions;
        private readonly ICacheServiceClient Redisdatabase;
        public PersonLookups(PartyContext context, ICacheServiceClient _database)
        {
            _context = context;
            Redisdatabase = _database;
            getFunctions = new GetFunctions(_context, _database);
        }
  
        [FunctionName("PersonLookups")]
        [ProducesResponseType(typeof(PersonLookups), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public  async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "PersonLookups")] HttpRequest req,
            ILogger log)
        {
            string _errLog = "Function V1.3";
            try
            {
           
                LookupTableData ltdata = new LookupTableData();
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                if (req.Method == "GET")
                {
                    _errLog += "get lookups";
                    log.LogInformation(_errLog);
                    //   var data =  ltdata.GetAgreementLookups(_context);
                    return getFunctions.ReturnCleanData(ltdata.GetPersonLookups(_context), "RAW");
                }
                   
                else
                {

                    return new HttpResponseMessage
                    {
                        Content = new StringContent("Method not Allowed ")

                    };
                }
            }
            catch (Exception ex)
            {
                log.LogInformation(_errLog+ ex.Message);
                return new HttpResponseMessage
                {
                    Content = new StringContent("Error:" + ex.Message)
                };
            }
        }
    }
}
