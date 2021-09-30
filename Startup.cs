using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using party = Party_Dll.Models;
using registration = RegistrationDAL.Models;
using agreement = Agreement_DAL.Models;
using roleRelationship = RoleAndRelationship_Dal.Models; 
using Microsoft.EntityFrameworkCore;
using System.IO;
using PartyDAL.Classes;
using ServiceExtensions;
using System.Collections.Generic;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;
using Castle.Core.Logging;

[assembly: FunctionsStartup(typeof(PartyDAL.Startup))]
namespace PartyDAL
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json",true)
                     .AddEnvironmentVariables()
                     .Build();
                List<string> secrets = new List<string>
                {
                    "KeyvaultSecretPar",
                    "KeyvaultSecretReg" ,
                    "KeyvaultSecretAgr",
                    "KeyvaultSecretRoleRel"

                };
                var connectionStrings = Keyvault.GetConnectionString(secrets);
                builder.Services.AddDbContext<party.PartyContext>(options => options.UseSqlServer(connectionStrings[0]));
                builder.Services.AddDbContext<registration.RegistrationContext>(options => options.UseSqlServer(connectionStrings[1]));
                builder.Services.AddDbContext<agreement.AgreementsContext>(options => options.UseSqlServer(connectionStrings[2]));
                builder.Services.AddDbContext<roleRelationship.RoleAndRelationshipContext>(options => options.UseSqlServer(connectionStrings[3]));
                builder.Services.ConfigureRedis(configuration);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                var err = ex.Message;
                throw;
            }
        }
    }
}
