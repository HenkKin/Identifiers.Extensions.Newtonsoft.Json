using System;
using Newtonsoft.Json;

namespace Identifiers.Extensions.Newtonsoft.Json.JsonConverters
{
    public class IdentifierJsonConverter<TInternalClrType> : JsonConverter<Identifier>
    {
        public override void WriteJson(JsonWriter writer, Identifier value, JsonSerializer serializer)
        {
            var internalValue = value.GetValue();

            if (internalValue == null)
            {
                writer.WriteValue((object) null);
            }
            else
            {
                writer.WriteValue(Convert.ChangeType(internalValue, typeof(TInternalClrType)));
            }
        }

        public override Identifier ReadJson(JsonReader reader, Type objectType, Identifier existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            Identifier target;

            if (reader.Value != null)
            {
                target = new Identifier(Convert.ChangeType(reader.Value, typeof(TInternalClrType)));
            }
            else
            {
                target = new Identifier();
            }

            return target;
        }
    }
}