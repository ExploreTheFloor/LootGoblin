using LootGoblin.Structure;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Serilog;

namespace LootGoblin.Services.OpenDkp
{
    public partial class OpenDkp
    {
        public async Task SubmitRaid(CurrentRaid currentRaid)
        {
            try
            {
                Log.Debug($"[{nameof(SubmitRaid)}]");
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Put, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/raids");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationResult?.IdToken);
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

        public async Task<List<CharacterItem>?> GetAllRaids(int count)
        {
            Log.Debug($"[{nameof(GetCharacterItems)}]");
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{LootGoblin.Default.Host}/clients/{LootGoblin.Default.Client}/raids?count={count}");
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<CharacterItem>>(await response.Content.ReadAsStringAsync());
        }
    }
}
