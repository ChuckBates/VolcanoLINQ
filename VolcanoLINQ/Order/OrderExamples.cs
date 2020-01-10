using System;
using System.Collections.Generic;
using System.Linq;
using VolcanoLINQ.Base;

namespace VolcanoLINQ.Order
{
    public static class OrderExamples
    {
        public static void OrderByDescendingExample(IList<Volcano> volcanoes)
        {
            var resultsUnOrdered = volcanoes
                .Take(10)
                .ToList();

            var resultsOrdered = volcanoes
                .OrderByDescending(v => v.LastEruptionYear)
                .Take(10)
                .ToList();

            Console.WriteLine("{0,-20} : {1,1}", "Unordered", "Ordered");
            Console.WriteLine("----------------------------------------");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0,-20} : {1,1}", resultsUnOrdered[i].LastEruptionYear, resultsOrdered[i].LastEruptionYear);
            }
        }

        public static void OrderByAscendingExample(IList<Volcano> volcanoes)
        {
            var resultsUnOrdered = volcanoes
                .Take(10)
                .ToList();

            var resultsOrdered = volcanoes
                .OrderBy(v => v.PopulationClose)
                .Take(10)
                .ToList();

            Console.WriteLine("{0,-20} : {1,1}", "Unordered", "Ordered");
            Console.WriteLine("----------------------------------------");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0,-20} : {1,1}", resultsUnOrdered[i].PopulationClose, resultsOrdered[i].PopulationClose);
            }
        }
    }
}