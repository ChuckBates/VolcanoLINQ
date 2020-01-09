using System;
using System.Collections.Generic;
using System.Linq;
using VolcanoLINQ.Base;

namespace VolcanoLINQ.Syntax
{
    public static class SyntaxExamples
    {
        public static void CompareSyntax(IEnumerable<Volcano> volcanoes)
        {
            var queryResults = QueryWhereExample(volcanoes);
            var methodResults = MethodWhereExample(volcanoes);

            var areEqual = queryResults.Count() == methodResults.Count() &&
                           (!queryResults.Except(methodResults).Any() || !methodResults.Except(queryResults).Any());

            var sequenceEqual = queryResults.SequenceEqual(methodResults);
            Console.WriteLine($"Results of query and method syntax are equal: {sequenceEqual}");
        }

        static List<Volcano> MethodWhereExample(IEnumerable<Volcano> volcanoes)
        {
            return volcanoes.Where(v => v.Country == "United States")
                .OrderByDescending(v => v.LastEruptionYear)
                .ToList();
        }

        static List<Volcano> QueryWhereExample(IEnumerable<Volcano> volcanoes)
        {
            var query = from volcano in volcanoes
                where volcano.Country == "United States"
                orderby volcano.LastEruptionYear descending
                select volcano;

            return query.ToList();
        }
    }
}