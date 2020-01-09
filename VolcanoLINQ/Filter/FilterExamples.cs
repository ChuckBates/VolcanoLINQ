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

        public static void FirstExample(IEnumerable<Volcano> volcanoes)
        {
            var result = volcanoes.First(v => v.Type == "Stratovolcano");
            Console.WriteLine($"First stratovolcano: {result.Name}");
        }

        public static void LastExample(IEnumerable<Volcano> volcanoes)
        {
            var result = volcanoes.Last(v => v.Type == "Stratovolcano");
            Console.WriteLine($"Last stratovolcano: {result.Name}");
        }

        public static void FirstOrDefaultExample(IEnumerable<Volcano> volcanoes)
        {
            var result = volcanoes.FirstOrDefault(v => v.Name == "Pompeii");
            Console.WriteLine($"Pompeii volcano result is null: {result == null}");
        }

        public static void LastOrDefaultExample(IEnumerable<Volcano> volcanoes)
        {
            var result = volcanoes.FirstOrDefault(v => v.Name == "Pompeii");
            Console.WriteLine($"Pompeii volcano result is null: {result == null}");
        }
    }
}