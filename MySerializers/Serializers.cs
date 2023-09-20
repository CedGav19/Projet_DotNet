using System.Text.Json.Serialization;
using System.Text.Json;
using MainView;

namespace MySerializers
{
    public class Serializers
    {
        public static void SerializeJson(Data data, String filename)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            File.WriteAllText(filename, JsonSerializer.Serialize(data, options));
        }

        public static Data DeserializeJson(String fileName)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            return JsonSerializer.Deserialize<Data>(File.ReadAllText(fileName), options)!;
        }
    }
}