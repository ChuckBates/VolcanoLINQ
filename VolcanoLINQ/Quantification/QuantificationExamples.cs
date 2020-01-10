using System;
using System.Collections.Generic;
using System.Linq;
using VolcanoLINQ.Base;

namespace VolcanoLINQ.Quantification
{
    public static class QuantificationExamples
    {
        public static void AnyExample(IList<Volcano> volcanoes)
        {
            var result = volcanoes.Any(v => v.Type == "Stratovolcano");
            Console.WriteLine($"Are there any of type Stratovolcano: {result}");

            result = volcanoes.Any(v => v.Type == "Supervolcano");
            Console.WriteLine($"Are there any of type Supervolcano: {result}");
        }

        public static void AllExample(IList<Volcano> volcanoes)
        {
            var result = volcanoes.All(v => v.PopulationClose > 0);
            Console.WriteLine($"Are all volcanoes close to populations: {result}");

            result = volcanoes.All(v => v.Type.Length > 0);
            Console.WriteLine($"Are all volcanoes typed: {result}");
        }

        public static void CountExample(IList<Volcano> volcanoes)
        {
            var result = volcanoes.Count(v => v.Type == "Stratovolcano");
            Console.WriteLine($"There are {result} known stratovolcanoes");

            result = volcanoes.Count(v => v.Name == "Chuck");
            Console.WriteLine($"There are {result} volcanoes with the name \"Chuck\"");
        }
    }
}