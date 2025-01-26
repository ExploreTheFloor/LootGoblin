using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LootGoblin.Structure
{

    public class DKPSummary
    {
        public List<Model> Models { get; set; }
        
        public DateTime AsOfDate { get; set; }
    }

    public class Model
    {
        public double CurrentDKP { get; set; }
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string CharacterClass { get; set; }
        public string CharacterRank { get; set; }
        public int CharacterLevel { get; set; }
        public string CharacterStatus { get; set; }
        public double AttendedTicks_30 { get; set; }
        public double TotalTicks_30 { get; set; }
        public double Calculated_30 { get; set; }
        public double AttendedTicks_60 { get; set; }
        public double TotalTicks_60 { get; set; }
        public double Calculated_60 { get; set; }
        public double AttendedTicks_90 { get; set; }
        public double TotalTicks_90 { get; set; }
        public double Calculated_90 { get; set; }
        public double AttendedTicks_Life { get; set; }
        public double TotalTicks_Life { get; set; }
        public double Calculated_Life { get; set; }
    }
}
