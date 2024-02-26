using _7days;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

using (HttpClient client = new HttpClient())
{
    try
    {
        //Faz uma requisição 
        HttpResponseMessage responsePokemons = await client.GetAsync("https://pokeapi.co/api/v2/pokemon-species/");
        responsePokemons.EnsureSuccessStatusCode(); //Lança uma exceção em caso de erro da requisição
        
        string conteudo = await responsePokemons.Content.ReadAsStringAsync();
        PokemonSpeciesResult pokemonEspeciesResposta = JsonConvert.DeserializeObject<PokemonSpeciesResult>(conteudo);

        Console.WriteLine("Escolha um tamagotchi: ");
        for (int i = 0; i < pokemonEspeciesResposta.Results.Count; i++)
        {
            Console.WriteLine($"{i+1}. {pokemonEspeciesResposta.Results[i].Name}.");
        }

        int escolha;
        while (true)
        {
            Console.WriteLine("\n");
            Console.Write("Escolha um número: ");

            if (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > pokemonEspeciesResposta.Results.Count)
            {
                Console.WriteLine("Escolha inválida. Tente novamente.");
            }
            else
            {
                break;
            }
        }

        responsePokemons = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{escolha}");
        responsePokemons.EnsureSuccessStatusCode();

        conteudo = await responsePokemons.Content.ReadAsStringAsync();
        PokemonDetailsResult pokemonDetalhes = JsonConvert.DeserializeObject<PokemonDetailsResult>(conteudo);

        var pokemonEscolhido = pokemonEspeciesResposta.Results[escolha - 1];

        Console.WriteLine("\n");
        Console.WriteLine($"Você escolheu {pokemonEscolhido.Name}!");
        Console.WriteLine($"Detalhes:");
        Console.WriteLine($"- Nome: {pokemonEscolhido.Name}");
        Console.WriteLine($"- Peso: {pokemonDetalhes.Peso}");
        Console.WriteLine($"- Altura: {pokemonDetalhes.Altura}");

        Console.WriteLine("\n Habilidades do Mascote: ");

        foreach (var abilityDetail in pokemonDetalhes.Habilidades)
        {
            Console.WriteLine("Nome da Habilidade: " + abilityDetail.DetalheHabilidade.Name);
        }

        Console.WriteLine("\n");
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine($"Houve um erro: {ex.Message}.");
    }
    catch (JsonException ex)
    {
        Console.WriteLine($"Houve um erro: {ex.Message}.");
    }
}