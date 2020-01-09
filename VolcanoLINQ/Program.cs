using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VolcanoLINQ.Base;
using VolcanoLINQ.Filter;
using VolcanoLINQ.Flatten;
using VolcanoLINQ.Order;
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

//            SyntaxExamples.CompareSyntax(volcanoes);

//            OrderExamples.OrderByDescendingExample(volcanoes);

//            QuantificationExamples.AnyExample(volcanoes);
//            QuantificationExamples.AllExample(volcanoes);
//            QuantificationExamples.CountExample(volcanoes);

//            ProjectionExamples.SelectExample(volcanoes);
            
            FlattenExamples.SelectManyExample(volcanoes);
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
