using System.Text.Json;
using LootGoblin.Structure;

namespace LootGoblin.Services
{
    public class OpenDkp
    {
        private AuthenticationResult? _authenticationResult = null;

        public AuthenticationResult? AuthenticationResult
        {
            get { return _authenticationResult ??= GetBearerToken().Result; }
        }

        public async Task<AuthenticationResult?> GetBearerToken()
        {
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
            var jsonSerialized = JsonSerializer.Serialize(authentication);
            var content = new StringContent(jsonSerialized, null, "application/x-amz-json-1.1");
            request.Content = content;
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var returnedContent = await response.Content.ReadAsStringAsync();
            var authenticationResponse = JsonSerializer.Deserialize<AuthenticationResponse>(returnedContent);
            return authenticationResponse?.AuthenticationResult;
        }

        public async Task<List<Character>?> GetCharacters(bool includeInactive = false)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/characters?IncludeInactives={includeInactive}");
            request.Headers.Add("Authorization", AuthenticationResult?.AccessToken);
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<List<Character>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Character?> GetCharacterById(int id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/characters/{id}");
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<Character>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<CharacterDkp>?> GetCharacterDkp(int id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/characters/{id}/dkp");
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<List<CharacterDkp>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<DkpInformationList?> GetDkpInformationList()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/dkp");
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<DkpInformationList>(await response.Content.ReadAsStringAsync());
        }

        public async Task<CharacterLinks?> GetLinkedCharacters(int id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/characters/links/{id}");
            request.Headers.Add("Authorization", AuthenticationResult?.AccessToken);
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<CharacterLinks>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<CharacterItems>?> GetCharacterItems(int id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/characters/{id}/items");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<List<CharacterItems>>(await response.Content.ReadAsStringAsync());
        }
    }
}
