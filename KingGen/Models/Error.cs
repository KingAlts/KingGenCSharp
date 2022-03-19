using System.Text.Json.Serialization;

namespace KingGen.Models;

[Serializable]
public class Error
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}