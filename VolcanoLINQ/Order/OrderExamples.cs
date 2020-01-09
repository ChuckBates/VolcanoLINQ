using System;
using System.Collections.Generic;
using System.Linq;
using VolcanoLINQ.Base;

namespace VolcanoLINQ.Order
{
    public static class OrderExamples
    {
        public static void OrderByDescendingExample(IEnumerable<Volcano> volcanoes)
        {
            var resultsUnOrdered = volcanoes.Take(10).ToList();
            var resultsOrdered = volcanoes.Take(10).OrderByDescending(v => v.Country).ToList();

            Console.WriteLine("{0,-20} : {1,1}", "Unordered", "Ordered");
            Console.WriteLine("----------------------------------------");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0,-20} : {1,1}", resultsUnOrdered[i].Country, resultsOrdered[i].Country);
            }
        }
    }
}