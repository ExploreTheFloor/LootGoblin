using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootGoblin
{
    public static class Extensions
    {
        public static string RemoveLastCharacter(this string str) => string.IsNullOrEmpty(str) ? str : str[..^1];
    }
}
