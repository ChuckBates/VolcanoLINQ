using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using VolcanoLINQ.Base;

namespace VolcanoLINQ.Syntax
{
    public static class SyntaxExamples
    {
        public static void MeasureSyntaxPerformanceSimpleExample(IEnumerable<Volcano> volcanoes)
        {
            var stopwatch = Stopwatch.StartNew();
            var queryResults = QueryWhereExample(volcanoes);
            var queryTime = stopwatch.ElapsedTicks;
            stopwatch.Restart();
            var methodResults = MethodWhereExample(volcanoes);
            var methodTime = stopwatch.ElapsedTicks;

            Console.WriteLine($"Results of query and method syntax are equal: {queryResults.SequenceEqual(methodResults)}");
            Console.WriteLine($"Query execution time: {queryTime}");
            Console.WriteLine($"Method execution time: {methodTime}");
        }

        public static void MeasureSyntaxPerformanceComplexExample(IEnumerable<Volcano> volcanoes)
        {
            var stopwatch = Stopwatch.StartNew();
            var queryResults = QueryComplexExample(volcanoes);
            var queryTime = stopwatch.ElapsedTicks;
            stopwatch.Restart();
            var methodResults = MethodComplexExample(volcanoes);
            var methodTime = stopwatch.ElapsedTicks;

            Console.WriteLine($"Results of query and method syntax are equal: {queryResults.SequenceEqual(methodResults)}");
            Console.WriteLine($"Query execution time: {queryTime}");
            Console.WriteLine($"Method execution time: {methodTime}");
        }

        public static void CompareSyntaxEqualityExample(IEnumerable<Volcano> volcanoes)
        {
            var queryResults = QueryWhereExample(volcanoes);
            var methodResults = MethodWhereExample(volcanoes);
            
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

        static List<(string Name, int PopulationClose, string Country, int LastEruptionYear)> MethodComplexExample(IEnumerable<Volcano> volcanoes)
        {
            return volcanoes.Where(v => v.PopulationClose > 1000 && v.LastEruptionYear > DateTime.UtcNow.Year - 5)
                .OrderByDescending(v => v.PopulationClose)
                .ThenByDescending(v => v.LastEruptionYear)
                .Select(v => (v.Name, v.PopulationClose, v.Country, v.LastEruptionYear)).ToList();
        }

        static List<(string Name, int PopulationClose, string Country, int LastEruptionYear)> QueryComplexExample(IEnumerable<Volcano> volcanoes)
        {
            var query = from volcano in volcanoes
                where volcano.PopulationClose > 1000 && volcano.LastEruptionYear > DateTime.UtcNow.Year - 5
                orderby volcano.PopulationClose descending, volcano.LastEruptionYear descending 
                select (volcano.Name, volcano.PopulationClose, volcano.Country, volcano.LastEruptionYear);

            return query.ToList();
        }
    }
}