using System.Text.Json.Serialization;

namespace Tourism.Shared.Models;

public record Error(ReturnCode SysCode, string Message)
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ReturnCode Code => SysCode;
}; 
