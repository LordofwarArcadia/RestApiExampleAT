using System.Collections.Generic;
using Newtonsoft.Json;

namespace RestApiExampleAutomatedTests.Helper
{
    /// <summary>
    /// To parse this JSON data, use var lookup = Lookup.FromJson(jsonString);
    /// </summary>
    public partial class Lookup : IItem
    {
        [JsonProperty("resourceType")]
        public string ResourceType { get; set; }

        [JsonProperty("parameter")]
        public List<ISimpleParameter> Parameter { get; set; }
    }

    public partial class Lookup
    {
        public static Lookup FromJson(string json) => JsonConvert.DeserializeObject<Lookup>(json, Converter.Settings);
    }

    public static partial class Serialize
    {
        public static string ToJson(this Lookup self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
