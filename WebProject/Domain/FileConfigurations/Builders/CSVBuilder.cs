using AutoMapper;
using Database.Contacts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Domain.FileConfigurations.Builders
{
    public static class CSVBuilder
    {
        public static string WriteToCsv<T>(List<T> list, string path)
        {
            try
            {
                if (list == null || list.Count == 0) return "No data to export";

                Type t = list[0].GetType();
                string newLine = Environment.NewLine;

                FileCreationHelper.ExistanceCheck(path);

                using (var sw = new StreamWriter(File.Create(path)))
                {
                    object o = Activator.CreateInstance(t);
                    PropertyInfo[] props = o.GetType().GetProperties();

                    sw.Write(string.Join(",", props.Select(d => d.Name).ToArray()) + newLine);

                    list.ForEach(item =>
                    { 
                        var row = string.Join(",",
                            props.Select(d => item.GetType()
                                                  .GetProperty(d.Name)
                                                  .GetValue(item, null)
                                                  .ToString())
                                        .ToArray());

                        sw.Write(row + newLine);
                    });
                }

                return $"Exported {list.Count} as CSV to {path}";
            }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                sb.Append("Thats not cool, something went worng with the export:");
                sb.Append(Environment.NewLine);
                sb.Append(ex.InnerException.ToString());
                return sb.ToString();
            }
        }

        public static List<string> ReadFromCsvFile(string path) 
        {
            return File.ReadAllLines(path).Skip(1).ToList();
        }
    }
}
