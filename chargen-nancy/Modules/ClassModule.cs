using System;
using chargen_nancy.App;
using chargen_nancy.App.ClassStuff;
using Nancy;

namespace chargen_nancy.Modules
{
    public sealed class ClassModule : NancyModule
    {
        public ClassModule()
        {
            var random = new Random(Environment.TickCount);

            Get("/classes/{race}/{str}/{dex}/{con}/{int}/{wis}/{chr}",
                args => new AvailableClasses(args.race, args.str, args.dex, args.con, args.@int, args.wis, args.chr)
                    .Select());
            Get("/hpgp/{className}",
                args => new[] {new HP(args.className, random).Get(), new Funds(args.className, random).Get()});
            Get("/alignment/{className}", args => new AllowedAlignments(args.className).Get());
        }
    }
}