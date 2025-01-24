using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootGoblin.Structure
{
    public class AuthenticationResult
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string IdToken { get; set; }
        public string RefreshToken { get; set; }
        public string TokenType { get; set; }
    }

    public class ChallengeParameters
    {
    }
    public class AuthenticationResponse
    {
        public AuthenticationResult AuthenticationResult { get; set; }
        public ChallengeParameters ChallengeParameters { get; set; }
    }

}
