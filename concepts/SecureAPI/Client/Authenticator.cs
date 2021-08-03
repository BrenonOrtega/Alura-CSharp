using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace SecureClient
{
    public class Authenticator
    {
        public async Task<string> GetAuthenticationTokenAsync(IConfidentialClientApplication app, string[] resourceIds)
        {
            AuthenticationResult result = null;

            try 
            {
                result = await app.AcquireTokenForClient(resourceIds).ExecuteAsync();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Token Acquired");
                System.Console.WriteLine(result.AccessToken);
                Console.ResetColor();

                return result.AccessToken;

            } catch (MsalClientException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                return "error";
            }
        }

        public async Task SendAuthenticatedRequest(string baseAddress, string token)
        {
            if (! string.IsNullOrEmpty(token))
            {
                var client = new HttpClient();
                var headers = client.DefaultRequestHeaders;

                if(headers.Accept is null || !headers.Accept.Any(m => m.MediaType == "application/json"))
                {
                    var acceptHeader = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(acceptHeader);
                }

                headers.Authorization = new AuthenticationHeaderValue("bearer", token);

                HttpResponseMessage response = await client.GetAsync(baseAddress);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Token Acquired");
                    System.Console.WriteLine(content);
                    Console.ResetColor();
                } else 
                {
                    System.Console.WriteLine($"Failed to call api: { response.StatusCode }");
                    System.Console.WriteLine($"fail message: { response.ReasonPhrase }");
                    Console.ResetColor();

                }

            }
        }
    }
}