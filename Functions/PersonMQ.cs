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
using Moq;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using System.Text;
using FnPerson.Classes;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using RabbitMQ.Client.Framing;
using System.Net.Http;

namespace FnPerson.Functions
{
    public  class PersonMQ
    {
        private readonly PartyContext _context;
        private readonly ILogger _log;
        private readonly ICacheServiceClient Redisdatabase;
        GetFunctions getFunctions;
        PostFunctions postFunctions;
        DeleteFunctions deleteFunctions;
        PutFunctions putFunctions;

        public PersonMQ(PartyContext context, ICacheServiceClient _database)
        {
            _context = context;
            Redisdatabase = _database;
            getFunctions = new GetFunctions(_context, _database);
            postFunctions = new PostFunctions(_context, _database);
            deleteFunctions = new DeleteFunctions(_context, _database);
            putFunctions = new PutFunctions(_context, _database);
        }
        [FunctionName("FNPersonMQ")]
        public  async Task Run([RabbitMQTrigger("MQPerson", ConnectionStringSetting = "rabbitMQConnectionAppSetting")] BasicDeliverEventArgs MQPersonItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {MQPersonItem}");
            var MQBody = System.Text.Encoding.UTF8.GetString(MQPersonItem.Body);
              var Person =  getFunctions.RequestGetPerson(MQBody, null, null, null, null);
            var result = getFunctions.ReturnPersonCleanData(Person, null);
     
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();
            PublishQues(MQPersonItem.BasicProperties.ReplyTo, MQPersonItem, responseBody);
        }

        public void PublishQues(string replyTo, BasicDeliverEventArgs myQueueItems, string Resultmessage)
        {
            try
            {//32610
                
                var factory = new ConnectionFactory()
                {
                    HostName = "10.200.113.143",
                    UserName = "guest",
                    Password = "guest",
                    Port = 32610
                };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {

               


                    var body = Encoding.UTF8.GetBytes(Resultmessage);
                    BasicProperties basicProperties = new BasicProperties(); //needed to create our own basicproperties object
                    basicProperties.CorrelationId = myQueueItems.BasicProperties.CorrelationId;
                    channel.BasicPublish(exchange: "", replyTo, basicProperties, body);

                }
            }
            catch (Exception ex)
            {

            }


        }
    }
}
