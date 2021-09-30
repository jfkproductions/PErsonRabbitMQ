using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyDAL.Classes
{
    public static class Keyvault
    {

        public static List<string> GetConnectionString(List<string> vaultKeys)
        {

            List<string> connectionStrings = new List<string>();
            foreach (var key in vaultKeys)
            {

                SecretClientOptions options = new SecretClientOptions()
                {
                    Retry =
                    {
                        Delay= TimeSpan.FromSeconds(2),
                        MaxDelay = TimeSpan.FromSeconds(16),
                        MaxRetries = 5,
                        Mode = RetryMode.Exponential
                     }
                };

                try
                {
                    var KeyvaultSecret = Environment.GetEnvironmentVariable(key ?? "KeyvaultSecret");
                    var KeyvaultUri = Environment.GetEnvironmentVariable("KeyvaultUri");
                    var TenantID = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
                    var ClientID = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
                    var ClientPWD = Environment.GetEnvironmentVariable("AZURE_CLIENT_PWD");

                    var credential = new ClientSecretCredential(TenantID, ClientID, ClientPWD);
                    var client = new SecretClient(new Uri(KeyvaultUri), credential, options);
                    KeyVaultSecret secret = client.GetSecret(KeyvaultSecret);
                    if (!string.IsNullOrWhiteSpace(secret.Value))
                    {
                        connectionStrings.Add(secret.Value);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Keyvault ->GetConnectionString: Error in getting Key Vault values:" + ex.Message);
                }
                finally
                {

                }

            }
            return connectionStrings;
        }
        public static bool GetRedisConnectionString(ref string ConnectionString)
        {
            var _ret = false;
            try
            {
                ConnectionString = Environment.GetEnvironmentVariable("KeyVaultRedisDBConnection");
            }
            catch (Exception ex )
            {

                throw new Exception("Keyvault ->GetRedisConnectionString: Error in getting Key Vault values:" + ex.Message);
            }

            return _ret; 
        }

    }
}
