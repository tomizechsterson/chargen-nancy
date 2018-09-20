using System;
using chargen_nancy.App.RaceStuff;
using Nancy;

namespace chargen_nancy.Modules
{
    public sealed class ADD2RaceModule :  NancyModule
    {
        public ADD2RaceModule()
        {
            var random = new Random(Environment.TickCount);
            
            Get("/races/{str:int}/{dex:int}/{con:int}/{int:int}/{wis:int}/{chr:int}", args => new AvailableRaces(args.str, args.dex, args.con, args.@int, args.wis, args.chr).Select());
            Get("statadjust/{race:alpha}", args => new RacialStatAdjust(args.race).Adjustments());
            Get("hwa/{race:alpha}/{gender:alpha}", args =>
            {
                var hwa = new HeightWeightAge(args.race, args.gender, random);
                return new[]
                {
                    hwa.Height(),
                    hwa.Weight(),
                    hwa.Age()
                };
            });
        }
    }
}