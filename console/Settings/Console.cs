using Newtonsoft.Json;
using System.ComponentModel;

namespace console.Settings
{
    class Console
    {
        [DefaultValue("json")]
        [JsonProperty(PropertyName = "outputType", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string OutputType { get; set; }
    }
}
