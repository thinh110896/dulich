using System.Text.Json;

namespace Tourism.Domain.Helpers;

public static class JsonHelper
{
    public static string SerializeObject(this object obj)
    {
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });
    }

    public static string SerializeObject<T>(this T obj)
    {
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });
    }

    public static T? DeserializeObject<T>(this Stream json)
    {
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });
    }

    public static T? DeserializeObject<T>(this string json)
    {
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });
    }
}
