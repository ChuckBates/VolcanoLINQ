using System;
using System.Collections.Generic;
using System.Linq;
using VolcanoLINQ.Base;

namespace VolcanoLINQ.Group
{
    public static class GroupExamples
    {
        public static void GroupByExample(IEnumerable<Volcano> volcanoes)
        {
            var result = volcanoes
                .OrderBy(v => v.Type)
                .GroupBy(v => v.Type)
                .ToList();

            foreach (var group in result)
            {
                Console.WriteLine($"Type {group.Key} has {group.Key.Length} matches");
            }
        }

        public static void GroupByProjectionExample(IEnumerable<Volcano> volcanoes)
        {
            var result = volcanoes
                .GroupBy(
                    volcano => volcano.Type, 
                    (type, volcano) => new
                        {
                            Key = type,
                            AvgPopulation = volcano.Average(v => v.PopulationClose)
                        })
                .OrderByDescending(v => v.AvgPopulation)
                .ToList();

            foreach (var group in result)
            {
                Console.WriteLine($"Type {group.Key} has {group.AvgPopulation:N0} average population close by");
            }
        }
    }
}