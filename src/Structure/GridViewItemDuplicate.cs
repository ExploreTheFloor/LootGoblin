using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
