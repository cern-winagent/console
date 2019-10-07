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
        public event EventHandler<MessageEventArgs> MessageEvent;

        public void Execute(string jsonData, JObject set)
        {
            var settings = set.ToObject<Settings.Console>();

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
                    catch(JsonSerializationException jse)
                    {
                        throw new Exceptions.TableOutputNotSupportedException("Table output is not supported for the specified input data", jse);
                    }
                    break;

                case "json":

                default:
                    Console.WriteLine(jsonData);
                    break;
            }
        }
    }
}