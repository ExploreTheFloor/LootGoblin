namespace LootGoblin.Structure
{
    public class GridViewItemDuplicate()
    {
        public GridViewItemDuplicate(string user, string itemName, string date) : this()
        {
            User = user;
            ItemName = itemName;
            Date = date;
        }
        public string User { get; set; }
        public string ItemName { get; set; }
        public string Date { get; set; }

    }
}
