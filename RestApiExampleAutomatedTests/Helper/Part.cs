using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiExampleAutomatedTests.Helper
{
    public partial class Code : IPart
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("valueCode")]
        public string ValueCode { get; set; }

        public static bool operator !=(Code leftVal, Code rightVal)
        {
            if (leftVal is null)
            {
                return !(rightVal is null);
            }
            return !leftVal.Equals(rightVal);
        }

        public static bool operator ==(Code leftVal, Code rightVal)
        {
            if (leftVal is null)
            {
                return rightVal is null;
            }
            return leftVal.Equals(rightVal);
        }
        public override bool Equals(object obj)
        {
            if (obj is null) return this is null;
            Code compared = (Code)obj;
            if (!Name.Equals(compared.Name)) return false;
            if (!ValueCode.Equals(compared.ValueCode)) return false;
            return true;
        }
        public override int GetHashCode() => new { Name, ValueCode }.GetHashCode();
    }

    public partial class Description : IPart
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("valueString")]
        public string ValueString { get; set; }

        public static bool operator !=(Description leftVal, Description rightVal)
        {
            if (leftVal is null)
            {
                return !(rightVal is null);
            }
            return !leftVal.Equals(rightVal);
        }

        public static bool operator ==(Description leftVal, Description rightVal)
        {
            if (leftVal is null)
            {
                return rightVal is null;
            }
            return leftVal.Equals(rightVal);
        }
        public override bool Equals(object obj)
        {
            if (obj is null) return this is null;
            Description compared = (Description)obj;
            if (!Name.Equals(compared.Name)) return false;
            if (!ValueString.Equals(compared.ValueString)) return false;
            return true;
        }
        public override int GetHashCode() => new { Name, ValueString }.GetHashCode();
    }

    public partial class Language : IPart
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("valueString")]
        public string ValueString { get; set; }

        public static bool operator !=(Language leftVal, Language rightVal)
        {
            if (leftVal is null)
            {
                return !(rightVal is null);
            }
            return !leftVal.Equals(rightVal);
        }

        public static bool operator ==(Language leftVal, Language rightVal)
        {
            if (leftVal is null)
            {
                return rightVal is null;
            }
            return leftVal.Equals(rightVal);
        }
        public override bool Equals(object obj)
        {
            if (obj is null) return this is null;
            Language compared = (Language)obj;
            if (!Name.Equals(compared.Name)) return false;
            if (!ValueString.Equals(compared.ValueString)) return false;
            return true;
        }
        public override int GetHashCode() => new { Name, ValueString }.GetHashCode();
    }

    public partial class Value : IPart
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("valueString")]
        public string ValueString { get; set; }

        public static bool operator !=(Value leftVal, Value rightVal)
        {
            if (leftVal is null)
            {
                return !(rightVal is null);
            }
            return !leftVal.Equals(rightVal);
        }

        public static bool operator ==(Value leftVal, Value rightVal)
        {
            if (leftVal is null)
            {
                return rightVal is null;
            }
            return leftVal.Equals(rightVal);
        }
        public override bool Equals(object obj)
        {
            if (obj is null) return this is null;
            Value compared = (Value)obj;
            if (!Name.Equals(compared.Name)) return false;
            if (!ValueString.Equals(compared.ValueString)) return false;
            return true;
        }
        public override int GetHashCode() => new { Name, ValueString }.GetHashCode();
    }
}
