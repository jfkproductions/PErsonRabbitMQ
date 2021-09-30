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
using FnPerson.Classes;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TIH.Common.RedisCacheHandler;

namespace FnPerson.Functions
{
    public  class GetPersonByPartyID
    {
        private readonly PartyContext _context;
        private readonly ICacheServiceClient Redisdatabase;
        public GetPersonByPartyID(PartyContext context, ICacheServiceClient _database)
        {
            _context = context;
            Redisdatabase = _database;
        }



        [FunctionName("GetPersonByPartyID")]
        [ProducesResponseType(typeof(PersonArrayObject), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [Route("PersonByPartyID/{Id}")]
        public async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "PersonByPartyID/{Id}")] HttpRequest req,
            ILogger log, ExecutionContext context, string Id)
        {
            string _errLog = "Function V1.3";
            GetFunctions getFunctions = new GetFunctions(_context,Redisdatabase);
           
            try
            {

                _errLog += "get data by id";
                log.LogInformation(_errLog);
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);

                if (req.Method == "GET")
                {
                    var person = await _context.TblPersonDetail.Where(cl => cl.PartyId == int.Parse(Id)).ToListAsync();
                    if (person.Count() > 0)
                    {
                        var Person = getFunctions.RequestGetPerson(requestBody, null, person.First().PersonId.ToString());
                        return getFunctions.ReturnPersonCleanData(Person);
                    }
                    else
                        return new HttpResponseMessage
                        {
                            Content = new StringContent("No Value Found")
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
                log.LogInformation(_errLog + ex.Message);
             
                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex.Message + ":" + ex.StackTrace))
                };
            }
            finally
            {
                if (getFunctions != null)
                    getFunctions = null;
               
            }
        }
    }
}
