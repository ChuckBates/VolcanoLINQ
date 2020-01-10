using System;
using System.Collections.Generic;
using VolcanoLINQ.Base;

namespace VolcanoLINQ.Execution
{
    public class NewVolcano
    {
        private string _type;
        public int Number { get; set; }
        public string Name { get; set; }

        public string Type
        {
            get => throw new Exception();
            set => _type = value;
        }

        public int LastEruptionYear { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string EvidenceCategory { get; set; }
        public string[] MajorRocks { get; set; }
        public string[] MinorRocks { get; set; }
        public int PopulationClose { get; set; }
    }

    public static class NewVolcanoExtensions
    {
        public static IEnumerable<NewVolcano> Convert(this IEnumerable<Volcano> source)
        {
            foreach (var volcano in source)
            {
                yield return new NewVolcano
                {
                    Number = volcano.Number,
                    Name = volcano.Name,
                    Type = volcano.Type,
                    LastEruptionYear = volcano.LastEruptionYear,
                    Country = volcano.Country,
                    Region = volcano.Region,
                    EvidenceCategory = volcano.EvidenceCategory,
                    MajorRocks = volcano.MajorRocks,
                    MinorRocks = volcano.MinorRocks,
                    PopulationClose = volcano.PopulationClose
                };
            }
        }
    }
}