using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.Settings
{
    class Plugin
    {
        [JsonProperty(PropertyName = "output_type")]
        public string OutputType { get; set; }
    }
}
