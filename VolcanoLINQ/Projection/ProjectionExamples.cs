using System;
using System.Collections.Generic;
using System.Linq;
using VolcanoLINQ.Base;

namespace VolcanoLINQ.Projection
{
    public static class ProjectionExamples
    {
        public static void SelectExample(IEnumerable<Volcano> volcanoes)
        {
            var results = volcanoes.Where(v => v.Country == "United States" && v.LastEruptionYear > DateTime.UtcNow.Year - 50)
                .OrderByDescending(v => v.LastEruptionYear)
                .Select(v => new {v.Region})
                .ToList();

            Console.WriteLine("Recent eruption areas in the United States, ordered by most recent");
            foreach (var name in results)
            {
                Console.WriteLine(name.Region);
            }
        }

        public static void SelectWithIndexExample(IEnumerable<Volcano> volcanoes)
        {
            var results = volcanoes.Where(v => v.Country == "United States" && v.LastEruptionYear > DateTime.UtcNow.Year - 50)
                .OrderByDescending(v => v.LastEruptionYear)
                .Select((v,i) => new {i, v.Region})
                .ToList();

            Console.WriteLine("Recent eruption areas in the United States, ordered by most recent");
            foreach (var name in results)
            {
                Console.WriteLine($"index: {name.i + 1}, region: {name.Region}");
            }
        }
    }
}