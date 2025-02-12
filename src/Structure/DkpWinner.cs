using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootGoblin.Structure
{
    public class DkpWinner
    {
        public DkpWinner(string player, int bid, string item)
        {
            Player = player;
            Bid = bid;
            Item = item;
        }

        public string Player { get; set; }
        public int Bid { get; set; }
        public string Item { get; set; }
    }
}
