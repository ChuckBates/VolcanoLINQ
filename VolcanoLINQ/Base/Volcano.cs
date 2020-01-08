using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VolcanoLINQ.Base
{
    public class Volcano
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int LastEruptionYear { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string EvidenceCategory { get; set; }
        public string[] MajorRocks { get; set; }
        public string[] MinorRocks { get; set; }
        public int PopulationClose { get; set; }
    }

    public static class VolcanoExtensions
    {
        public static IEnumerable<Volcano> ToVolcano(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                yield return new Volcano
                {
                    Number = int.Parse(columns[0]),
                    Name = columns[1],
                    Type = columns[2],
                    LastEruptionYear = int.TryParse(columns[3], out var year) ? year : -9999,
                    Country = columns[4],
                    Region = columns[5],
                    EvidenceCategory = columns[6],
                    MajorRocks = columns[7].Split('\t'),
                    MinorRocks = columns[8].Split('\t'),
                    PopulationClose = int.Parse(columns[9])
                };
            }
        }
    }
}