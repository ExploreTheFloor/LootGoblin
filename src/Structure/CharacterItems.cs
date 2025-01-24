using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootGoblin.Structure
{
    public class CharacterItems
    {
        public string ItemName { get; set; }
        public int ItemID { get; set; }
        public int GameItemId { get; set; }
        public int RaidID { get; set; }
        public string Raid { get; set; }
        public DateTime Date { get; set; }
        public double DkpValue { get; set; }
        public string Notes { get; set; }
    }

}
