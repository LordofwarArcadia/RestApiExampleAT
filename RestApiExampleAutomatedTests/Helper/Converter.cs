using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;


namespace RestApiExampleAutomatedTests.Helper
{
    internal class Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => true;

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            dynamic item = new object();

            if (t.Name.Contains("List"))
            {
                Type genericClass = typeof(List<>);
                Type type = t.GetGenericArguments()[0];
                Type constructedClass = genericClass.MakeGenericType(type);
                dynamic list = Activator.CreateInstance(constructedClass);

                JArray array = JArray.Load(reader);
                foreach(var i in array)
                {
                    ((IList)list).Add(JsonConvert.DeserializeObject(i.ToString(), type, Settings));
                }
                return list;
            }
            JObject obj = JObject.Load(reader);
            string discriminator = (string)obj["name"];
            string baseToken = (string)obj["resourceType"];
            JArray parameters = (JArray)obj["parameter"];

            switch (discriminator)
            {
                case "name":
                    item = new BaseName();
                    break;
                case "result":
                    item = new Result();
                    break;
                case "outcome":
                    item = new Outcome();
                    break;
                case "message":
                    item = new Message();
                    break;
                case "version":
                    item = new Version();
                    break;
                case "display":
                    item = new Display();
                    break;
                case "designation":
                    item = new Designation();
                    break;
                case "property":
                    item = new Property();
                    break;
                case "code":
                    item = new Code();
                    break;
                case "description":
                    item = new Description();
                    break;
                case "language":
                    item = new Language();
                    break;
                case "value":
                    item = new Value();
                    break;
                case null:
                    if (baseToken.Equals("Parameters") && t.Name.Equals(nameof(Lookup))) item = new Lookup();
                    if (baseToken.Equals("Parameters") && t.Name.Equals(nameof(Subsumes))) item = new Subsumes();
                    if (baseToken.Equals("Parameters") && t.Name.Equals(nameof(ValidateCode))) item = new ValidateCode();
                    break;
                default:
                    throw new NotImplementedException();
            }
            if (item is Lookup)
            {
                return GetBaseItem<Lookup>(item, baseToken, parameters);
            }
            if (item is ValidateCode)
            {
                return GetBaseItem<ValidateCode>(item, baseToken, parameters);
            }
            if (item is Subsumes)
            {
                return GetBaseItem<Subsumes>(item, baseToken, parameters);
            }
            if (item is Designation | item is Property)
            {
                item.Name = (string)obj["name"];
                item.Part = new List<IPart>();
                JArray parts = (JArray)obj["part"];
                foreach (var part in parts)
                {
                    item.Part.Add(JsonConvert.DeserializeObject<IPart>(part.ToString(), Settings));
                }

            }

            else item = JsonConvert.DeserializeObject(obj.ToString(), item.GetType());

            return item;
        }
        public T GetBaseItem<T> (dynamic item, string baseToken, JArray parameters) where T: IItem, new()
        {
            ((T)item).ResourceType = baseToken;
            ((T)item).Parameter = new List<ISimpleParameter>();
            foreach (var param in parameters)
            {
                ((T)item).Parameter.Add(JsonConvert.DeserializeObject<ISimpleParameter>(param.ToString(), Settings));
            }

            return item;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }

        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new Converter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
