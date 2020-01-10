using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VolcanoLINQ.Base;
using VolcanoLINQ.Filter;
using VolcanoLINQ.Flatten;
using VolcanoLINQ.Group;
using VolcanoLINQ.Order;
using VolcanoLINQ.Performance;
using VolcanoLINQ.Projection;
using VolcanoLINQ.Quantification;
using VolcanoLINQ.Syntax;

namespace VolcanoLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var volcanoes = Load();
            // FilterExamples.LastOrDefaultExample(volcanoes);
            
            // SyntaxExamples.MeasureSyntaxPerformanceComplexExample(volcanoes);
            
            // OrderExamples.OrderByAscendingExample(volcanoes);
        
            // QuantificationExamples.AnyExample(volcanoes);
        
            // ProjectionExamples.SelectWithIndexExample(volcanoes);
        
            // FlattenExamples.SelectManyResultSelectorExample(volcanoes);

            // GroupExamples.GroupByProjectionExample(volcanoes);

            // PerformanceExamples.CompareToLoopsExample(volcanoes);

            Console.ReadKey();
        }

        static List<Volcano> Load()
        {
            return File.ReadAllLines(@"C:\dev\VolcanoLINQ\VolcanoLINQ\Base\Volcanoes.csv")
                .Skip(1)
                .ToVolcano()
                .ToList();
        }
    }
}
