using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Split.Entities;
using Newtonsoft.Json;

namespace Split.Services
{
    class AuthenticationService
    {

        private readonly Uri Uri;
        private readonly string ClientId;
        private readonly string ClientSecret;
        public string Response { get; set; }
        public Token Token { get; private set; }

        public AuthenticationService(string clientId, string clientSecret, bool sandbox)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            if (sandbox)
            {
                Uri = new Uri("https://authsandbox.braspag.com.br");
            }
            else
            {
                Uri = new Uri(" https://auth.braspag.com.br");
            }
        }

        public async Task Authenticate()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = Uri;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", CredentialsToBase64());

            HttpResponseMessage response = await client.PostAsync("/oauth2/token", Content());
            
            Response = await response.Content.ReadAsStringAsync();
            Token = JsonConvert.DeserializeObject<Token>(Response);
        }

        private string CredentialsToBase64()
        {
            byte[] credentialToByte = Encoding.ASCII.GetBytes($"{ClientId}:{ClientSecret}");
            string credentialToBase64 = Convert.ToBase64String(credentialToByte);
            return credentialToBase64;
        }

        private HttpContent Content()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("grant_type", "client_credentials");

            return new FormUrlEncodedContent(dictionary);
        }
    }
}
