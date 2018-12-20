using System.Collections.Generic;

namespace chargen_nancy.App
{
    public class MovementRate
    {
        private readonly string _race;
        private readonly Dictionary<string, int> _movementRates;

        public MovementRate(string race)
        {
            _race = race.ToLower();
            _movementRates = InitializeMovementRates();
        }

        public int Get()
        {
            return _movementRates[_race];
        }

        private Dictionary<string, int> InitializeMovementRates()
        {
            return new Dictionary<string, int>
            {
                { "dwarf", 6 }, 
                { "elf", 12 }, 
                { "gnome", 6 },
                { "half-elf", 12 },
                { "halfling", 6 },
                { "human", 12 }
            };
        }
    }
}