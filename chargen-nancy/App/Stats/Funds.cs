using System;
using System.Collections.Generic;
using System.Linq;

namespace chargen_nancy.App
{
    public class Funds
    {
        private readonly string _className;
        private readonly Random _random;
        private readonly Dictionary<string, DieRoll> _initialFundRolls;

        public Funds(string className, Random random)
        {
            _className = className.Replace("%2F", "/").ToLower();
            _random = random;
            _initialFundRolls = InitializeFundRolls();
        }

        public int Get()
        {
            if (_className.Contains("/"))
                return InitialFundsForMulticlass();

            if (_className == "mage")
                return (_initialFundRolls[_className].Roll().Sum() + 1) * 10;

            return _initialFundRolls[_className].Roll().Sum() * 10;
        }

        private int InitialFundsForMulticlass()
        {
            if (_className.Split("/").Contains("fighter"))
                return _initialFundRolls["fighter"].Roll().Sum() * 10;
            if (_className.Split("/").Contains("cleric"))
                return _initialFundRolls["cleric"].Roll().Sum() * 10;
            
            return _initialFundRolls["thief"].Roll().Sum() * 10;
        }

        private Dictionary<string, DieRoll> InitializeFundRolls()
        {
            return new Dictionary<string, DieRoll>
            {
                { "fighter", new DieRoll(4, 5, _random) }, 
                { "ranger", new DieRoll(4, 5, _random) },
                { "paladin", new DieRoll(4, 5, _random) },
                { "mage", new DieRoll(4, 1, _random) },
                { "thief", new DieRoll(6, 2, _random) },
                { "bard", new DieRoll(6, 2, _random) },
                { "cleric", new DieRoll(6, 3, _random) },
                { "druid", new DieRoll(6, 3, _random) }
            };
        }
    }
}