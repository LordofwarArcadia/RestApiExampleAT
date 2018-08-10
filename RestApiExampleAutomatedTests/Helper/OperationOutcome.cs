using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiExampleAutomatedTests.Helper
{
    public class OperationOutcome
    {
        [JsonProperty("resourceType", NullValueHandling = NullValueHandling.Ignore)]
        public string ResourceType { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public Text Text { get; set; }

        [JsonProperty("issue", NullValueHandling = NullValueHandling.Ignore)]
        public List<Issue> Issue { get; set; }

        public static OperationOutcome FromJson(string json) => JsonConvert.DeserializeObject<OperationOutcome>(json);
    }
    public class Issue
    {
        [JsonProperty("severity", NullValueHandling = NullValueHandling.Ignore)]
        public string Severity { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("diagnostics", NullValueHandling = NullValueHandling.Ignore)]
        public string Diagnostics { get; set; }
    }

    public class Text
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("div", NullValueHandling = NullValueHandling.Ignore)]
        public string Div { get; set; }
    }
}
