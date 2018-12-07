using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenApiSample.DTO
{
    public class Image
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
