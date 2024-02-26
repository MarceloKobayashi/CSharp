using System.Text.Json.Serialization;

namespace _7days;

public class PokemonSpeciesResult
{
    [JsonPropertyName("results")]
    public List<PokemonResult> Results { get; set; }
}

