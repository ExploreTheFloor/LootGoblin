using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootGoblin.Structure
{
    public class CharacterLinks
    {
        public List<LinkedCharacter> LinkedCharacters { get; set; }
        public List<AvailableCharacter> AvailableCharacters { get; set; }
    }
    public class AvailableCharacter
    {
        public int CharacterId { get; set; }
        public int AssociatedId { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public DateTime MainChange { get; set; }
        public int Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class LinkedCharacter
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }
        public string ParentName { get; set; }
        public string ChildName { get; set; }
        public string ParentRank { get; set; }
        public string ChildRank { get; set; }
        public string ParentClass { get; set; }
        public string ChildClass { get; set; }
        public int Id { get; set; }
        public string ClientId { get; set; }
    }


}
