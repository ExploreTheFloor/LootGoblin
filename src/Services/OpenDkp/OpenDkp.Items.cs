using LootGoblin.Structure.OpenDkp.Items;
using Newtonsoft.Json;
using Serilog;

namespace LootGoblin.Services.OpenDkp
{
    public partial class OpenDkp
    {
        public async Task<List<ItemSearch>> ItemSearchGet(string itemName)
        {
            Log.Debug($"[{nameof(ItemSearchGet)}]");
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://api.opendkp.com/items/autocomplete?item={itemName}");
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<ItemSearch>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<ItemSearch>> ItemSearchPost(string[] itemNames)
        {
            Log.Debug($"[{nameof(ItemSearchPost)}]");
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post,
                $"https://api.opendkp.com/items");
            var jsonSerialized = JsonConvert.SerializeObject(itemNames);
            var content = new StringContent(jsonSerialized, null, "application/x-amz-json-1.1");
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<ItemSearch>>(await response.Content.ReadAsStringAsync());
        }
    }
}
