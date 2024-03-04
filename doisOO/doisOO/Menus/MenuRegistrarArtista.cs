using doisOO.Modelos;
using OpenAI_API;

namespace doisOO.Menus;

internal class MenuRegistrarArtista : Menu
{
    public override void Executar(Dictionary<string, Artista> artistasRegistrados)
    {
        base.Executar(artistasRegistrados);
        ExibirTituloDaOpcao("Registro de artistas.");

        Console.Write("Digite o nome do artista que deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;

        Artista artista = new Artista(nomeDoArtista);
        artistasRegistrados.Add(artista.NomeArtista, artista);

        var client = new OpenAIAPI("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");
        var chat = client.Chat.CreateConversation();
        chat.AppendSystemMessage($"Resuma o/a artista {nomeDoArtista} em 1 parágrafo com estilo informal");
        string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
        artista.Resumo = resposta;

        Console.WriteLine($"O artista {nomeDoArtista} foi registrado(a) com sucesso!");
        Console.Write("Digite uma tecla para voltar ao menu.");
        Console.ReadKey();
        Console.Clear();
    }
}
