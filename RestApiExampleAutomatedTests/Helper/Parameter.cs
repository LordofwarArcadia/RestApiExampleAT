using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiExampleAutomatedTests.Helper
{
    public partial class Property : IParameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("part")]
        public List<IPart> Part { get; set; }

        public static bool operator !=(Property leftProp, Property rightProp)
        {
            if (leftProp is null)
            {
                return rightProp is null;
            }
            return !leftProp.Equals(rightProp);
        }

        public static bool operator ==(Property leftProp, Property rightProp)
        {
            if (leftProp is null)
            {
                return rightProp is null;
            }
            return leftProp.Equals(rightProp);
        }
        public override bool Equals(object obj)
        {
            if (obj is null) return this is null;
            Property compared = (Property)obj;
            if (!Name.Equals(compared.Name)) return false;
            foreach (IPart part in Part)
            {
                if (part is Code)
                    if (!compared.Part.Any(i => i is Code && i.Equals(part)))
                        return false;
                if (part is Description)
                    if (!compared.Part.Any(i => i is Description && i.Equals(part)))
                        return false;
            }
            return true;
        }

        public override int GetHashCode() => new { Name, Part }.GetHashCode();
    }

    public partial class Designation : IParameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("part")]
        public List<IPart> Part { get; set; }

        public static bool operator !=(Designation leftDes, Designation rightDes)
        {
            if (leftDes is null)
            {
                return !(rightDes is null);
            }
            return !leftDes.Equals(rightDes);
        }

        public static bool operator ==(Designation leftDes, Designation rightDes)
        {
            if (leftDes is null)
            {
                return rightDes is null;
            }
            return leftDes.Equals(rightDes);
        }
        public override bool Equals(object obj)
        {
            if (obj is null || this is null) return false;
            Designation compared = (Designation)obj;
            if (!Name.Equals(compared.Name)) return false;
            foreach (IPart part in Part)
            {
                if (part is Language)
                    if (!compared.Part.Any(i => i is Language && i.Equals(part)))
                        return false;
                if (part is Value)
                    if (!compared.Part.Any(i => i is Value && i.Equals(part)))
                        return false;
            }
            return true;
        }

        public override int GetHashCode() => new { Name, Part }.GetHashCode();
    }

    public partial class BaseName : ISimpleParameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("valueString")]
        public string ValueString { get; set; }

        public static bool operator !=(BaseName leftVal, BaseName rightVal)
        {
            if (leftVal is null)
            {
                return !(rightVal is null);
            }
            return !leftVal.Equals(rightVal);
        }

        public static bool operator ==(BaseName leftVal, BaseName rightVal)
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
            BaseName compared = (BaseName)obj;
            if (!Name.Equals(compared.Name)) return false;
            if (!ValueString.Equals(compared.ValueString)) return false;
            return true;
        }
        public override int GetHashCode() => new { Name, ValueString }.GetHashCode();
    }

    public partial class Message : ISimpleParameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("valueString")]
        public string ValueString { get; set; }

        public static bool operator !=(Message leftVal, Message rightVal)
        {
            if (leftVal is null)
            {
                return !(rightVal is null);
            }
            return !leftVal.Equals(rightVal);
        }

        public static bool operator ==(Message leftVal, Message rightVal)
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
            Message compared = (Message)obj;
            if (!Name.Equals(compared.Name)) return false;
            if (!ValueString.Equals(compared.ValueString)) return false;
            return true;
        }
        public override int GetHashCode() => new { Name, ValueString }.GetHashCode();
    }

    public partial class Result : ISimpleParameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("valueBoolean")]
        public bool ValueBoolean { get; set; }

        public static bool operator !=(Result leftVal, Result rightVal)
        {
            if (leftVal is null)
            {
                return !(rightVal is null);
            }
            return !leftVal.Equals(rightVal);
        }

        public static bool operator ==(Result leftVal, Result rightVal)
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
            Result compared = (Result)obj;
            if (!Name.Equals(compared.Name)) return false;
            if (ValueBoolean!=compared.ValueBoolean) return false;
            return true;
        }
        public override int GetHashCode() => new { Name, ValueBoolean }.GetHashCode();
    }

    public partial class Outcome : ISimpleParameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("valueCode")]
        public string ValueCode { get; set; }

        public static bool operator !=(Outcome leftVal, Outcome rightVal)
        {
            if (leftVal is null)
            {
                return !(rightVal is null);
            }
            return !leftVal.Equals(rightVal);
        }

        public static bool operator ==(Outcome leftVal, Outcome rightVal)
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
            Outcome compared = (Outcome)obj;
            if (!Name.Equals(compared.Name)) return false;
            if (ValueCode != compared.ValueCode) return false;
            return true;
        }
        public override int GetHashCode() => new { Name, ValueCode }.GetHashCode();
    }

    public partial class Version : ISimpleParameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("valueString")]
        public string ValueString { get; set; }

        public static bool operator !=(Version leftVal, Version rightVal)
        {
            if (leftVal is null)
            {
                return !(rightVal is null);
            }
            return !leftVal.Equals(rightVal);
        }

        public static bool operator ==(Version leftVal, Version rightVal)
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
            Version compared = (Version)obj;
            if (!Name.Equals(compared.Name)) return false;
            if (!ValueString.Equals(compared.ValueString)) return false;
            return true;
        }
        public override int GetHashCode() => new { Name, ValueString }.GetHashCode();
    }

    public partial class Display : ISimpleParameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("valueString")]
        public string ValueString { get; set; }

        public static bool operator !=(Display leftVal, Display rightVal)
        {
            if (leftVal is null)
            {
                return !(rightVal is null);
            }
            return !leftVal.Equals(rightVal);
        }

        public static bool operator ==(Display leftVal, Display rightVal)
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
            Display compared = (Display)obj;
            if (!Name.Equals(compared.Name)) return false;
            if (!ValueString.Equals(compared.ValueString)) return false;
            return true;
        }
        public override int GetHashCode() => new { Name, ValueString }.GetHashCode();
    }
}
