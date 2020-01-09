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
                .Take(5)
                .ToList();

            Console.WriteLine("Top 5 rocks found in Stratovolcanoes");
            Console.WriteLine("------------------------------------");
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}