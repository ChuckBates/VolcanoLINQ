using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VolcanoLINQ.Base;
using VolcanoLINQ.Execution;
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

//            FilterExamples.WhereExample(volcanoes);
//            FilterExamples.FirstOrDefaultExample(volcanoes);

//            OrderExamples.OrderByDescendingExample(volcanoes);

//            QuantificationExamples.AnyExample(volcanoes);
//            QuantificationExamples.CountExample(volcanoes);
            
//            GroupExamples.GroupByExample(volcanoes);

//            ProjectionExamples.SelectExample(volcanoes);
        
//            FlattenExamples.SelectManyExample(volcanoes);

//            SyntaxExamples.CompareSyntaxEqualityExample(volcanoes);
//            SyntaxExamples.MeasureSyntaxPerformanceSimpleExample(volcanoes);
//            SyntaxExamples.MeasureSyntaxPerformanceComplexExample(volcanoes);

//            PerformanceExamples.CompareToLoopsExample(volcanoes);

//            DeferredExecutionExamples.DeferredExecutionExample(volcanoes);
//            DeferredExecutionExamples.DeferredExecutionThrowExample(volcanoes);

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
