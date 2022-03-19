using System.Text.Json.Serialization;

namespace KingGen.Models;

[Serializable]
public class Alt
{
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    [JsonPropertyName("password")]
    public string? Password { get; set; }
    [JsonPropertyName("stock")]
    public int Stock { get; set; }
}