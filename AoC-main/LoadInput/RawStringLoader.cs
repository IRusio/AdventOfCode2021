using System.Collections.Generic;
using System.IO;
using AoC_main.LoadInput.RawData;
using CsvHelper.Configuration;

namespace AoC_main.LoadInput
{
    public class RawStringLoader
    {
        public static IEnumerable<IRawData> LoadFile<T>(IRawMapper<T> mapper, bool isTest = false) where T : IRawData
        {
            var basePath = "C:/repos/AdventOfCode2021/AoC-main";
            var path = $"{basePath}/raw/{typeof(T).Name}{(isTest ? "Test" : "")}.csv";
            
            var content = File.ReadAllLines(path);
            
            var result = mapper.MapObject(content);

            return new List<IRawData>() { result };

        }
    }
}