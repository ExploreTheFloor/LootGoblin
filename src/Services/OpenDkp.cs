﻿using System.Diagnostics;
using LootGoblin.Structure;
using Newtonsoft.Json;
using Serilog;

namespace LootGoblin.Services
{
    public class OpenDkp
    {
        private AuthenticationResult? _authenticationResult = null;

        public AuthenticationResult? AuthenticationResult
        {
            get { return _authenticationResult ??= GetBearerToken().Result; }
        }

        public class Raids
        {
            public async Task RaidInsert(CurrentRaid currentRaid)
            {
                Log.Debug($"[{nameof(RaidInsert)}]");
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Put, "https://{{host}}/clients/{{client}}/raids");

                var jsonSerialized = JsonConvert.SerializeObject(currentRaid);
                var content = new StringContent(jsonSerialized, null, "application/x-amz-json-1.1");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
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

        public async Task<List<Character>> GetCharacters(bool includeInactive = false)
        {
            Log.Debug($"[{nameof(GetCharacters)}]");
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/characters?IncludeInactives={includeInactive}");
            request.Headers.Add("Authorization", AuthenticationResult?.AccessToken);
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<Character>>(await response.Content.ReadAsStringAsync()) ?? new List<Character>();
        }

        public async Task<Character> GetCharacterById(int id)
        {
            Log.Debug($"[{nameof(GetCharacterById)}]");
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/characters/{id}");
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<Character>(await response.Content.ReadAsStringAsync()) ?? new Character();
        }

        public async Task<List<CharacterDkp>?> GetCharacterDkp(int id)
        {
            Log.Debug($"[{nameof(GetCharacterDkp)}]");
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/characters/{id}/dkp");
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<CharacterDkp>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<DKPSummary> GetDKPSummary()
        {
            Log.Debug($"[{nameof(GetDKPSummary)}]");
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/dkp");
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<DKPSummary>(await response.Content.ReadAsStringAsync());
        }

        public async Task<CharacterLinks?> GetLinkedCharacters(int id)
        {
            Log.Debug($"[{nameof(GetLinkedCharacters)}]");
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/characters/links/{id}");
            request.Headers.Add("Authorization", AuthenticationResult?.AccessToken);
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<CharacterLinks>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<CharacterItem>?> GetCharacterItems(int id)
        {
            Log.Debug($"[{nameof(GetCharacterItems)}]");
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/characters/{id}/items");
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<CharacterItem>>(await response.Content.ReadAsStringAsync());
        }

        public async Task SubmitRaid(CurrentRaid currentRaid)
        {
            try
            {
                Log.Debug($"[{nameof(SubmitRaid)}]");
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Put, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/raids");
                request.Headers.Add("Authorization", AuthenticationResult?.AccessToken);
                var jsonSerialized = JsonConvert.SerializeObject(currentRaid);
                var content = new StringContent(jsonSerialized, null, "application/x-amz-json-1.1");
                request.Content = content;
                var response = await client.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Log.Error($"[{nameof(GetCharacterItems)}] {e.InnerException}");
            }
        }
    }
}
