namespace LootGoblin.Services
{
    public static class Extensions
    {
        public static string RemoveLastCharacter(this string str) => string.IsNullOrEmpty(str) ? str : str[..^1];
    }
}
