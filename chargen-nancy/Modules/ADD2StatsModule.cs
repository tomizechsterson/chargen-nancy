using System;
using System.Collections.Generic;
using chargen_nancy.App;
using Nancy;

namespace chargen_nancy.Modules
{
    public class ADD2StatsModule : NancyModule
    {
        private readonly Random _random;

        public ADD2StatsModule()
        {
            _random = new Random(Environment.TickCount);

            Get("/rollstats/{rollRule}", args => new StatRoll(args.rollRule, _random).RollStats());
            Get("/final/{race}/{className}", args =>
            {
                var result = new List<int> {new MovementRate(args.race).Get()};
                result.AddRange(new SavingThrows(args.className).Get());
                return result.ToArray();
            });
        }
    }
}