using System;
using System.IO;
using System.Text;
using Identifiers.Extensions.Newtonsoft.Json.JsonConverters;
using Newtonsoft.Json;
using Xunit;

namespace Identifiers.Extensions.Newtonsoft.Json.Tests.JsonConverters
{
    public class IdentifierJsonConverterTests
    {
        [Theory]
        [InlineData(null, "null", typeof(object))]
        [InlineData("test", "\"test\"", typeof(string))]
        [InlineData(int.MaxValue, "2147483647", typeof(int))]
        [InlineData(long.MaxValue, "9223372036854775807", typeof(long))]
        [InlineData(short.MaxValue, "32767", typeof(short))]
        public void WriteJson_WhenCalled_ItShouldWriteInnerValueOfIdentifier(object value, string expectedResult, Type valueType)
        {
            // Arrange
            var identifierJsonConverterType = typeof(IdentifierJsonConverter<>).MakeGenericType(valueType);

            var converter = (JsonConverter<Identifier>)Activator.CreateInstance(identifierJsonConverterType);
            var json = new StringBuilder();
            using StringWriter sw = new StringWriter(json);
            using JsonWriter writer = new JsonTextWriter(sw);

            Identifier identifier = new Identifier(value);

            // Act
            converter.WriteJson(writer, identifier, null);

            // Assert
            Assert.Equal(expectedResult, json.ToString());
        }

        [Theory]
        [InlineData(null, "null", typeof(object))]
        [InlineData("test", "\"test\"", typeof(string))]
        [InlineData(int.MaxValue, "2147483647", typeof(int))]
        [InlineData(long.MaxValue, "9223372036854775807", typeof(long))]
        [InlineData(short.MaxValue, "32767", typeof(short))]
        public void ReadJson_WhenCalled_ItShouldWriteInnerValueOfIdentifier(object expectedResult, string value, Type valueType)
        {
            // Arrange
            var identifierJsonConverterType = typeof(IdentifierJsonConverter<>).MakeGenericType(valueType);

            var converter = (JsonConverter<Identifier>)Activator.CreateInstance(identifierJsonConverterType);
            using TextReader jsonTextReader = new StringReader(value);
            using JsonReader jsonReader = new JsonTextReader(jsonTextReader);
            jsonReader.Read();

            // Act
            var result = converter.ReadJson(jsonReader, valueType, Identifier.Empty, true, null);

            // Assert
            Assert.Equal(Convert.ChangeType(expectedResult, valueType), Convert.ChangeType(result.GetValue(), valueType));
        }
    }
}