using System.Text.Json.Serialization;

namespace KingGen.Models;

[Serializable]
public class Profile
{
    [JsonPropertyName("username")]
    public string? Username { get; set; }
    [JsonPropertyName("generated")]
    public int Generated { get; set; }
    [JsonPropertyName("generatedToday")]
    public int GeneratedToday { get; set; }
    [JsonPropertyName("stock")]
    public int Stock { get; set; }
}