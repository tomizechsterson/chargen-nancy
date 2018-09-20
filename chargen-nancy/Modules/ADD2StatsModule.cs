using System;
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
        }
    }
}