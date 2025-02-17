namespace LootGoblin.Structure
{
    public class CharacterDkp
    {
        public int Order { get; set; }
        public DateTime Date { get; set; }
        public string SourceType { get; set; }
        public string Source { get; set; }
        public int SourceId { get; set; }
        public string CharacterName { get; set; }
        public int CharacterId { get; set; }
        public double Value { get; set; }
        public double Cumulative { get; set; }
        public int TickId { get; set; }
    }
}