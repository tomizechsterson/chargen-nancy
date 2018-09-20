using System;
using chargen_nancy.App;
using chargen_nancy.App.ClassStuff;
using Nancy;

namespace chargen_nancy.Modules
{
    public sealed class ADD2ClassModule : NancyModule
    {
        public ADD2ClassModule()
        {
            var random = new Random(Environment.TickCount);

            Get("/classes/{race}/{str:int}/{dex:int}/{con:int}/{int:int}/{wis:int}/{chr:int}",
                args => new AvailableClasses(args.race, args.str, args.dex, args.con, args.@int, args.wis, args.chr)
                    .Select());
            Get("/hpgp/{className}/{classTwo?}/{classThree?}",
                args => new[]
                {
                    new HP(random, args.className, args.classTwo, args.classThree).Get(),
                    new Funds(random, args.className, args.classTwo, args.classThree).Get()
                });
            Get("/alignment/{className}/{classTwo?}/{classThree?}",
                args => new AllowedAlignments(args.className, args.classTwo, args.classThree).Get());
        }
    }
}