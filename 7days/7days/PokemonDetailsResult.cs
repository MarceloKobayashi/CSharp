using System.Text.Json.Serialization;

namespace _7days;


public class PokemonDetailsResult
{
    [JsonPropertyName("abilities")]     //Corresponde ao campo "abilities"
    public List<Habilidade> Habilidades{ get; set; }    //Lista de habilidades

    [JsonPropertyName("name")]
    public string Nome { get; set; }

    [JsonPropertyName("weight")]
    public int Peso { get; set; }

    [JsonPropertyName("height")]
    public int Altura {  get; set; }
}

public class Habilidade()
{
    [JsonPropertyName("ability")]   //Propriedade "DetalheHabilidade" corresponde ao campo "ability"
    public DetalheHabilidade DetalheHabilidade { get; set; }

    [JsonIgnore]    //Ignora o que vem depois do ability, menos o name, citado abaixo
    public string Name => DetalheHabilidade.Name;   //Retorna o nome da habilidade (linha 32)
}
public class DetalheHabilidade()
{
    [JsonPropertyName("name")]      //Campo "name" corresponde ao nome da habilidade
    public string Name { get; set; }    //Nome da habilidade
}