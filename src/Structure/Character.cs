namespace LootGoblin.Structure
{
    public class Character
    {
        public string ClientId { get; set; }
        public int CharacterId { get; set; }
        public int AssociatedId { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public string Guild { get; set; }
        public DateTime MainChange { get; set; }
        public int Deleted { get; set; }
        public string User { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
