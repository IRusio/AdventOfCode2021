using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace AoC_main.LoadInput
{
    public class CsvLoader
    {
        public static IEnumerable<IRawData> LoadFile<T>(ClassMap<T> mapper, bool isTest = false) where T: IRawData
        {
            var basePath = "C:/private/repos/AdentOfCode2021/AoC-main";
            var fileStream = File.OpenRead($"{basePath}/raw/{typeof(T).Name}{(isTest?"Test":"")}.csv");
            using var sr = new StreamReader(fileStream);
            var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = true
            };
            
            csvConfiguration.RegisterClassMap(mapper);

            using var csvReader = new CsvReader(sr, csvConfiguration);
            return (IEnumerable<IRawData>)csvReader.GetRecords<T>().ToList();
        }
        
    }
}