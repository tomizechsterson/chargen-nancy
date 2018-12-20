using System;
using System.Collections.Generic;
using System.Linq;

namespace chargen_nancy.App
{
    public class HP
    {
        private readonly string _className;
        private readonly Random _random;
        private readonly Dictionary<string, DieRoll> _initialHpRolls;
        
        public HP(Random random, params string[] className)
        {
            _random = random;
            _className = string.Join('/', className).TrimEnd('/').ToLower();
            _initialHpRolls = InitializeStartingHPRolls();
        }

        public int Get()
        {
            return _className.Contains("/")
                ? AverageHPForMultiClass(_className.Split("/"))
                : _initialHpRolls[_className].Roll().Sum();
        }

        private int AverageHPForMultiClass(IReadOnlyCollection<string> classes)
        {
            int total = classes.Sum(c => _initialHpRolls[c].Roll().Sum());
            return total / classes.Count;
        }

        private Dictionary<string, DieRoll> InitializeStartingHPRolls()
        {
            return new Dictionary<string, DieRoll>
            {
                { "fighter", new DieRoll(10, 1, _random) },
                { "ranger", new DieRoll(10, 1, _random) },
                { "paladin", new DieRoll(10, 1, _random) },
                { "cleric", new DieRoll(8, 1, _random) },
                { "druid", new DieRoll(8, 1, _random) },
                { "thief", new DieRoll(6, 1, _random) },
                { "bard", new DieRoll(6, 1, _random) },
                { "mage", new DieRoll(4, 1, _random) }
            };
        }
    }
}