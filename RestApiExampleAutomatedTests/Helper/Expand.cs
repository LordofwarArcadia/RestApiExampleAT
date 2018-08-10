using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiExampleAutomatedTests.Helper
{
    public partial class ExpandResponse
    {
        [JsonProperty("resourceType")]
        public string ResourceType { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("identifier")]
        public Identifier Identifier { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("expansion")]
        public Expansion Expansion { get; set; }
    }

    public partial class Expansion
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("timestamp")]
        public System.DateTimeOffset Timestamp { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("contains")]
        public List<Contain> Contains { get; set; }
    }

    public partial class Contain
    {
        [JsonProperty("system")]
        public string System { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("display")]
        public string Display { get; set; }
    }

    public partial class Identifier
    {
        [JsonProperty("system")]
        public string System { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class ExpandResponse
    {
        public static ExpandResponse FromJson(string json) => JsonConvert.DeserializeObject<ExpandResponse>(json, ExpandConverter.Settings);
    }

    public static partial class Serialize
    {
        public static string ToJson(this ExpandResponse self) => JsonConvert.SerializeObject(self, ExpandConverter.Settings);
    }

    internal class ExpandConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
