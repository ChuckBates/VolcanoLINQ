using System;
using System.Collections.Generic;
using System.Linq;
using VolcanoLINQ.Base;

namespace VolcanoLINQ.Filter
{
    public static class FilterExamples
    {
        public static void WhereExample(IEnumerable<Volcano> volcanoes)
        {
            var results = volcanoes.Where(v => v.LastEruptionYear > DateTime.UtcNow.Year - 50).ToList();
            foreach (var result in results)
            {
                Console.WriteLine($"volcano {result.Name} erupted in {result.LastEruptionYear}");
            }
        }

        public static void FirstOrDefaultExample(IEnumerable<Volcano> volcanoes)
        {
            var result = volcanoes.FirstOrDefault(v => v.Name == "Pompeii");
            Console.WriteLine($"Pompeii volcano result is null: {result == null}");
        }
    }
}