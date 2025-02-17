using Newtonsoft.Json;

namespace LootGoblin.Structure
{
    public class CurrentRaid// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    {
        public CurrentRaid()
        {
            Items = new List<Item>();
            Ticks = new List<Tick>();
            Pool = new Pool();
        }
        [JsonProperty("Items")]
        public List<Item> Items { get; set; }

        [JsonProperty("Ticks")]
        public List<Tick> Ticks { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("Pool")]
        public Pool Pool { get; set; }

        [JsonProperty("Attendance")]
        public int Attendance { get; set; }
    }
    public class CharacterNames
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
    }

    public class Item
    {
        [JsonProperty("ItemId")]
        public int ItemId { get; set; }

        [JsonProperty("ItemName")]
        public string ItemName { get; set; }

        [JsonProperty("CharacterName")]
        public string CharacterName { get; set; }

        [JsonProperty("Dkp")]
        public int Dkp { get; set; }

        [JsonProperty("Notes")]
        public string Notes { get; set; }

        [JsonProperty("GameItemId")]
        public int GameItemId { get; set; }
    }

    public class Pool
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Order")]
        public int Order { get; set; }
    }

    public class Tick
    {
        [JsonProperty("Characters")]
        public List<string> Characters { get; set; } = new List<string>();

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }


}
