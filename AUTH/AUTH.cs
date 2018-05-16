using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.Azure.Authentication;

namespace AUTH
{

    public class AUTHClass
    {
        /*
         * The information of AD Application
         */
        private static string clientId = "0675a148-8425-4cc4-8747-18683cc70476";
        private static string domain = "b388b808-0ec9-4a09-a414-a7cbbd8b7e9b";
        private static string clientSecret = "Sw7oBD4I7+KEJtxbssa02UWEqcFMiq9tjPn4TbL0D28=";
        private static string subscriptionId = "e0fbea86-6cf2-4b2d-81e2-9c59f4f11bcb";


        public ServiceClientCredentials serviceClientCredentials;
        public AzureCredentials azureCredentials;
        public IAzure azure;

        public AUTHClass()
        {
            ServiceClientCredentials credentials = ApplicationTokenProvider.LoginSilentAsync(domain, new ClientCredential(clientId, clientSecret), ActiveDirectoryServiceSettings.AzureChina).Result;
            serviceClientCredentials = credentials;

            AzureCredentials creds = new AzureCredentialsFactory().FromServicePrincipal(clientId, clientSecret, domain, AzureEnvironment.AzureChinaCloud);
            azureCredentials = creds;

            IAzure Iazure = Microsoft.Azure.Management.Fluent.Azure.Authenticate(azureCredentials).WithSubscription(subscriptionId);
            azure = Iazure;
        }
    }
}
