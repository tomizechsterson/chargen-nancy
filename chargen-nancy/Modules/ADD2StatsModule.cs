using System;
using System.Collections.Generic;
using chargen_nancy.App;
using Nancy;

namespace chargen_nancy.Modules
{
    public sealed class ADD2StatsModule : NancyModule
    {
        public ADD2StatsModule()
        {
            var random = new Random(Environment.TickCount);

            Get("/rollstats/{rollRule}", args => new StatRoll(args.rollRule, random).RollStats());
            Get("/final/{race}/{className}/{classTwo?}/{classThree?}", args =>
            {
                var result = new List<int> {new MovementRate(args.race).Get()};
                result.AddRange(new SavingThrows(args.className, args.classTwo, args.classThree).Get());
                return result.ToArray();
            });
        }
    }
}