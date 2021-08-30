using System;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using FireOnWheels.Shared.Messaging;

namespace FireOnWheels.Shared.Messaging.Converters
{
    public class IOrderConverter : JsonConverter<IOrder>
    {
        public override IOrder Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if(CanConvert(typeToConvert))
                return JsonSerializer.Deserialize<ConverterOrder>(ref reader, options) as IOrder;

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, IOrder value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString(nameof(value.Id), value.Id.ToString());

            var sender = JsonSerializer.Serialize<Person>(value.Sender, options);
            writer.WriteString(nameof(value.Sender), sender);

            var receiver = JsonSerializer.Serialize<Person>(value.Receiver, options);
            writer.WriteString(nameof(value.Receiver), receiver);

            writer.WriteNumber(nameof(value.Weight), value.Weight);

            writer.WriteBoolean(nameof(value.IsOversized), value.IsOversized);
            writer.WriteBoolean(nameof(value.IsFragile), value.IsFragile);
        }

        private class ConverterOrder : IOrder
        {
            public Guid Id { get; set; }
            public Person Sender { get; set; }
            public Person Receiver { get; set; }
            public int Weight { get; set; }
            public bool IsFragile { get; set; }
            public bool IsOversized { get; set; }
        }
    }
}