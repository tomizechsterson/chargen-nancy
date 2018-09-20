using System.Collections.Generic;
using System.Linq;

namespace chargen_nancy.App
{
    public class SavingThrows
    {
        private readonly string _className;
        private readonly Dictionary<string, int[]> _savingThrows;

        public SavingThrows(string className)
        {
            _className = className.Replace("%2F", "/");
            _savingThrows = InitializeSavingThrows();
        }

        public int[] Get()
        {
            return _className.Contains("/")
                ? SavingThrowsForMulticlass()
                : _savingThrows[_className.ToLower()];
        }

        private int[] SavingThrowsForMulticlass()
        {
            if (_className.Split("/").Contains("mage"))
                return _savingThrows["mage"];
            if (_className.Split("/").Contains("cleric"))
                return _savingThrows["cleric"];

            return _className.Split("/").Contains("thief")
                ? _savingThrows["thief"]
                : _savingThrows["fighter"];
        }

        private static Dictionary<string, int[]> InitializeSavingThrows()
        {
            var results = new Dictionary<string, int[]>
            {
                { "fighter", new[] { 14, 16, 15, 17, 17 } },
                { "ranger", new[] { 14, 16, 15, 17, 17 } },
                { "paladin", new[] { 14, 16, 15, 17, 17 } },
                { "cleric", new[] { 10, 14, 13, 16, 15 } },
                { "druid", new[] { 10, 14, 13, 16, 15 } },
                { "thief", new[] { 13, 14, 12, 16, 15 } },
                { "bard", new[] { 13, 14, 12, 16, 15 } },
                { "mage", new[] { 14, 11, 13, 15, 12 } }
            };
            return results;
        }
    }
}