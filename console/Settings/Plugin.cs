using Newtonsoft.Json;
using System.ComponentModel;

namespace console.Settings
{
    class Plugin
    {
        [DefaultValue("json")]
        [JsonProperty(PropertyName = "output_type", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string OutputType { get; set; }
    }
}
