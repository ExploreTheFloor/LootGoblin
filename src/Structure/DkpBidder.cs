using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootGoblin.Structure
{
    public class DkpBidder
    {
        public DkpBidder(Character character, int parentId, List<CharacterItem> characterItems)
        {
            Character = character;
            ParentId = parentId;
            CharacterItems = characterItems;
        }

        public Character Character { get; set; }
        public int ParentId { get; set; }
        public int CurrentDkp { get; set; }
        public List<CharacterItem> CharacterItems { get; set; }
    }
}
