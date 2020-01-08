using System;
using System.Collections.Generic;
using System.Linq;
using VolcanoLINQ.Base;

namespace VolcanoLINQ.Where
{
    public static class WhereExample
    {
        public static IEnumerable<Volcano> WhereRecentEruption(IEnumerable<Volcano> volcanoes)
        {
            return volcanoes.Where(v => v.LastEruptionYear > DateTime.UtcNow.Year - 50).ToList();
        }
    }
}