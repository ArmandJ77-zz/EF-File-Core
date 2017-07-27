using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Domain.FileConfigurations.Builders
{
    public class JsonBuilder
    {
        internal static string WriteToJson<T>(List<T> list, string outputPath)
        {
            var jsonString = JsonConvert.SerializeObject(list);

            FileCreationHelper.ExistanceCheckCreate(outputPath);

            using (var sw = new StreamWriter(File.Create(outputPath)))
            {
                sw.Write(jsonString);
            }

            return $"Exported {list.Count} as JSON to {outputPath}";
        }

        internal static List<string> ReadFromJsonFile(string inputPath)
        {
            if (FileCreationHelper.ExistanceCheck(inputPath))
                return (File.ReadAllLines(inputPath)).Skip(1).ToList();

            return null;
        }
    }
}
