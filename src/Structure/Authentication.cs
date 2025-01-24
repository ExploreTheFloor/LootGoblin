using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootGoblin.Structure
{
    internal class Authentication
    {
        public AuthParameters AuthParameters { get; set; } = new AuthParameters();
        public string AuthFlow { get; set; }
        public string ClientId { get; set; }
    }
    public class AuthParameters
    {
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
    }
}
