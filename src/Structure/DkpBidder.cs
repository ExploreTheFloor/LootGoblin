using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootGoblin.Structure
{
    public class DkpBidder
    {
        public DkpBidder(Character character, int parentId, List<CharacterItems> characterItems)
        {
            Character = character;
            ParentId = parentId;
            CharacterItems = characterItems;
        }

        public Character Character { get; set; }
        public int ParentId { get; set; }
        public List<CharacterItems> CharacterItems { get; set; }
    }
}
