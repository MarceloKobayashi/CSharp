using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace _7days;

public class PokemonResult
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}
