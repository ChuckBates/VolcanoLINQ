using System;
using System.Collections.Generic;
using System.Linq;
using VolcanoLINQ.Base;

namespace VolcanoLINQ.Execution
{
    public class DeferredExecutionExamples
    {
        public static void DeferredExecutionExample(IList<Volcano> volcanoes)
        {
            var newVolcanoes = volcanoes.Convert().ToList();
            var query = 0;

            try
            {
                query = newVolcanoes.Count(v => v.Type == "Stratovolcano");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            query.CompareTo(42);
        }

        public static void DeferredExecutionThrowExample(IList<Volcano> volcanoes)
        {
            var newVolcanoes = volcanoes.Convert().ToList();
            var query = Enumerable.Empty<NewVolcano>();

            try
            {
                query = newVolcanoes.Where(v => v.Type == "Stratovolcano");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            query.ToList();
        }
    }
}