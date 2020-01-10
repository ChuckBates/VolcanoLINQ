using System;
using System.Collections.Generic;
using System.Linq;
using VolcanoLINQ.Base;

namespace VolcanoLINQ.Flatten
{
    public static class FlattenExamples
    {
        public static void SelectManyExample(IEnumerable<Volcano> volcanoes)
        {
            var results = volcanoes
                .Where(v => v.Type == "Stratovolcano")
                .SelectMany(v => v.MajorRocks)
                .Distinct()
                .ToList();

            Console.WriteLine("Rocks found in Stratovolcanoes");
            Console.WriteLine("------------------------------------");
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        public static void SelectManyResultSelectorExample(IEnumerable<Volcano> volcanoes)
        {
            var results = volcanoes
                .SelectMany(v => v.MajorRocks,
                    (v, rockName) => new
                    {
                        v.Type,
                        rockName
                    })
                .Distinct()
                .GroupBy(v => v.Type)
                .ToList();

            Console.WriteLine("Rocks found in each type of volcano");
            Console.WriteLine("------------------------------------");
            foreach (var result in results)
            {
                Console.WriteLine(result.Key + ": " + string.Join(", ", result.Select(x => x.rockName).ToArray()));
                Console.WriteLine();
            }
        }
    }
}