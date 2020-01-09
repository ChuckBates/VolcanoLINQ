using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using VolcanoLINQ.Base;

namespace VolcanoLINQ.Performance
{
    public static class PerformanceExamples
    {
        public static void CompareToLoopsExample(IEnumerable<Volcano> volcanoes)
        {
            var stopwatch = Stopwatch.StartNew();
            var linqResults = volcanoes.Where(v => v.PopulationClose > 1000 && v.LastEruptionYear > DateTime.UtcNow.Year - 5)
                .OrderByDescending(v => v.PopulationClose)
                .ThenByDescending(v => v.LastEruptionYear)
                .Select(v => (v.Name, v.PopulationClose, v.Country, v.LastEruptionYear)).ToList();
            var linqTime = stopwatch.ElapsedTicks;
            stopwatch.Restart();

            var loopResults = new List<(string Name, int PopulationClose, string Country, int LastEruptionYear)>();
            foreach (var v1 in volcanoes.Where(v => v.PopulationClose > 1000 && v.LastEruptionYear > DateTime.UtcNow.Year - 5)
                .OrderByDescending(v => v.PopulationClose)
                .ThenByDescending(v => v.LastEruptionYear))
                loopResults.Add((v1.Name, v1.PopulationClose, v1.Country, v1.LastEruptionYear));
            var loopTime = stopwatch.ElapsedTicks;

            Console.WriteLine($"Results of linq and loop syntax are equal: {linqResults.SequenceEqual(loopResults)}");
            Console.WriteLine($"LINQ execution time: {linqTime}");
            Console.WriteLine($"Loop execution time: {loopTime}");
        }
    }
}