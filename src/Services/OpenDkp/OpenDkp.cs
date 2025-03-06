using System.Diagnostics;
using System.Net.Http.Headers;
using LootGoblin.Structure;
using Newtonsoft.Json;
using Serilog;

namespace LootGoblin.Services.OpenDkp
{
    public partial class OpenDkp
    {
        private AuthenticationResult? _authenticationResult = null;

        public AuthenticationResult? AuthenticationResult
        {
            get { return _authenticationResult ??= GetBearerToken().Result; }
        }
        public async Task<AuthenticationResult?> GetBearerToken()
        {
            Log.Debug($"[{nameof(GetBearerToken)}]");
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://cognito-idp.us-east-2.amazonaws.com/");
            request.Headers.Add("X-Amz-Target", "AWSCognitoIdentityProviderService.InitiateAuth");
            var authentication = new Authentication
            {
                AuthParameters = new AuthParameters
                {
                    USERNAME = LootGoblin.Default.Username,
                    PASSWORD = LootGoblin.Default.Password
                },
                AuthFlow = "USER_PASSWORD_AUTH",
                ClientId = "2sq61k8dj39e309tnh5tm70dd4"
            };
            var jsonSerialized = JsonConvert.SerializeObject(authentication);
            var content = new StringContent(jsonSerialized, null, "application/x-amz-json-1.1");
            request.Content = content;
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var returnedContent = await response.Content.ReadAsStringAsync();
            var authenticationResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(returnedContent);
            return authenticationResponse?.AuthenticationResult;
        }

        public async Task<DKPSummary> GetDKPSummary()
        {
            Log.Debug($"[{nameof(GetDKPSummary)}]");
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/dkp");
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<DKPSummary>(await response.Content.ReadAsStringAsync()) ?? new DKPSummary();
        }
    }
}
