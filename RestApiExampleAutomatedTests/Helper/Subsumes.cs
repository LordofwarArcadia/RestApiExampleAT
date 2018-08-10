using Newtonsoft.Json;
using System.Collections.Generic;


namespace RestApiExampleAutomatedTests.Helper
{
    /// <summary>
    /// To parse this JSON data, use var subsumes = Subsumes.FromJson(jsonString);
    /// </summary>
    public partial class Subsumes : IItem
    {
        [JsonProperty("resourceType")]
        public string ResourceType { get; set; }

        [JsonProperty("parameter")]
        public List<ISimpleParameter> Parameter { get; set; }
    }

    public partial class Subsumes
    {
        public static Subsumes FromJson(string json) => JsonConvert.DeserializeObject<Subsumes>(json, Converter.Settings);
    }

    public static partial class Serialize
    {
        public static string ToJson(this Subsumes self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
