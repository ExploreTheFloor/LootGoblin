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
