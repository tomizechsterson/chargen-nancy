using System;
using System.Collections.Generic;

namespace chargen_nancy.App
{
    public class DieRoll
    {
        private readonly int _sides;
        private readonly int _times;
        private readonly Random _random;

        public DieRoll(int sides, int times, Random random)
        {
            _sides = sides;
            _times = times;
            _random = random;
        }

        public int[] Roll()
        {
            var temp = new List<int>();
            for (int i = 0; i < _times; i++)
                temp.Add(_random.Next(1, _sides + 1));
            return temp.ToArray();
        }
    }
}