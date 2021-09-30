using System;
using System.Reflection;
using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Settings;
using FnPerson;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi;



[assembly: FunctionsStartup(typeof(FnPerson.SwashBuckleStartup))]
namespace FnPerson
{
    internal class SwashBuckleStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            //Register the extension
            builder.AddSwashBuckle(Assembly.GetExecutingAssembly(), opts =>
            {
                var AditionalText = @"Get Functions : use single object " + System.Environment.NewLine +
                                 "Post Functions: uses the Array object []. The Personid must be null or -1,as well as the primary key values for new subsequent data." + System.Environment.NewLine +
                                 "Put Functions: uses the Array object []. The Personid must not be null or -1,as well as the primary key values for new subsequent data." + System.Environment.NewLine +
                                 "Delete Functions No Object required. ";

                opts.SpecVersion = OpenApiSpecVersion.OpenApi2_0;
                opts.AddCodeParameter = true;
                opts.PrependOperationWithRoutePrefix = true;
                opts.Documents = new[]
                {
                    new SwaggerDocument
                    {
                        Name = "v1",
                        Title = "Person",
                        Description = AditionalText,
                        Version = "v2",
                    }
                };
                opts.Title = "Person";
                //opts.OverridenPathToSwaggerJson = new Uri("http://localhost:7071/api/Swagger/json");
                opts.ConfigureSwaggerGen = (x =>
                {
                    x.CustomOperationIds(apiDesc =>
                    {  

                        return apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)
                            ? methodInfo.Name
                            : new Guid().ToString();

                    });
                });
            });

        }
    }

}
