using plugin;
using System;
using ConsoleTableExt;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace console
{
    [PluginAttribute(PluginName = "Console")]
    public class OConsole : IOutputPlugin
    {
        public void Execute(string jsonData, JObject set)
        {
            var settings = set.ToObject<Settings.Plugin>();

            switch (settings.OutputType)
            {
                case "table":
                    JObject jsonUpdatesInfo = JObject.Parse(jsonData);
                    try
                    {
                        foreach (var property in jsonUpdatesInfo)
                        {
                            Console.WriteLine();
                            Console.Write(property.Key + ": ");
                            if (property.Value.HasValues)
                            {
                                Console.WriteLine();
                                DataTable datatable = JsonConvert.DeserializeObject<DataTable>(property.Value.ToString());
                                ConsoleTableBuilder.From(datatable).WithFormat(ConsoleTableBuilderFormat.Minimal).ExportAndWriteLine();
                            }
                            else
                            {
                                Console.WriteLine(property.Value);
                            }
                        }
                    }
                    catch(JsonSerializationException)
                    {
                        throw new Exceptions.TableOutputNotSupported("Table output is not supported for the specified input data");
                    }
                    break;

                case "json":

                default:
                    Console.Write(jsonData);
                    break;
            }
        }
    }
}