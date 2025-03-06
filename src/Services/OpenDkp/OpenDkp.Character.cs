using System.Net.Http.Headers;
using LootGoblin.Structure;
using Newtonsoft.Json;
using Serilog;

namespace LootGoblin.Services.OpenDkp
{
    public partial class OpenDkp
    {
        public async Task<List<Character>> GetCharacters(bool includeInactive = false)
        {
            Log.Debug($"[{nameof(GetCharacters)}]");
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/characters?IncludeInactives={includeInactive}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationResult?.IdToken);
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

        public async Task<CharacterLinks?> GetLinkedCharacters(int id)
        {
            Log.Debug($"[{nameof(GetLinkedCharacters)}]");
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/characters/links/{id}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationResult?.IdToken);
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
    }
}
