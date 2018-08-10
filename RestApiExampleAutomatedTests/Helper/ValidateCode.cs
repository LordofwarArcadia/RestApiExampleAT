using Newtonsoft.Json;
using System.Collections.Generic;


namespace RestApiExampleAutomatedTests.Helper
{
    /// <summary>
    /// To parse this JSON data, use var validate = ValidateCode.FromJson(jsonString);
    /// </summary>
    public partial class ValidateCode : IItem
    {
        [JsonProperty("resourceType")]
        public string ResourceType { get; set; }

        [JsonProperty("parameter")]
        public List<ISimpleParameter> Parameter { get; set; }
    }

    public partial class ValidateCode
    {
        public static ValidateCode FromJson(string json) => JsonConvert.DeserializeObject<ValidateCode>(json, Converter.Settings);
        public static List<ValidateCode> MultipleFromJson(string json)
        {

            return JsonConvert.DeserializeObject<List<ValidateCode>>(json, Converter.Settings);
        }
    }

    public static partial class Serialize
    {
        public static string ToJson(this ValidateCode self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
