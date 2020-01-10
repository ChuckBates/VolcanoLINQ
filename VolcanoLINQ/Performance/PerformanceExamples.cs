using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using VolcanoLINQ.Base;

namespace VolcanoLINQ.Performance
{
    public static class PerformanceExamples
    {
        public static void CompareToLoopsExample(IList<Volcano> volcanoes)
        {
            var stopwatch = Stopwatch.StartNew();
            var linqResults = volcanoes.Where(v => v.PopulationClose > 1000 && v.LastEruptionYear > DateTime.UtcNow.Year - 5)
                .OrderByDescending(v => v.PopulationClose)
                .ThenByDescending(v => v.LastEruptionYear)
                .Select(v => (v.Name, v.PopulationClose, v.Country, v.LastEruptionYear)).ToList();
            var linqTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Restart();

            var loopResults = new List<(string Name, int PopulationClose, string Country, int LastEruptionYear)>();
            foreach (var volcano in volcanoes)
            {
                if (volcano.PopulationClose > 1000 && volcano.LastEruptionYear > DateTime.UtcNow.Year - 5)
                {
                    loopResults.Add((volcano.Name, volcano.PopulationClose, volcano.Country, volcano.LastEruptionYear));
                }
            }

            loopResults.Sort(
                delegate(
                    (string Name, int PopulationClose, string Country, int LastEruptionYear) x, 
                    (string Name, int PopulationClose, string Country, int LastEruptionYear) y)
                    {
                        if (x.PopulationClose > y.PopulationClose)
                        {
                            return -1;
                        }
                        return 1;
                    });
            var loopTime = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"Results of linq and loop syntax are equal: {linqResults.SequenceEqual(loopResults)}");
            Console.WriteLine($"LINQ execution time: {linqTime} ms");
            Console.WriteLine($"Loop execution time: {loopTime} ms");
        }
    }
}