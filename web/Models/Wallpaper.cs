using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace web.Models
{
    public abstract class Wallpaper
    {
        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("url")]
        public virtual string Url
        {
            get; set;
        }

        [JsonProperty("resolution")]
        public virtual ResolutionValue Resolution
        {
            get; set;
        }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }

        public struct ResolutionValue
        {
            public int Width { get; set; }

            public int Height { get; set; }
        }

        [JsonProperty("provider")]
        public virtual string Provider { get; set; }
    }
}
