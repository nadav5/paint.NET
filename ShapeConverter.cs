using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace FirstApp
{
    public class ShapeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Shape).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            string typeString = obj["Name"]?.ToString();

            if (!Enum.TryParse(typeString, out ShapeType shapeType))
            {
                throw new JsonSerializationException($"Invalid shape type: {typeString}");
            }

            Shape shape = ShapeFactory.CreateShape(shapeType);

            serializer.Populate(obj.CreateReader(), shape);
            return shape;
        }


        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject obj = JObject.FromObject(value, serializer);
            obj.WriteTo(writer);
        }
    }
}
