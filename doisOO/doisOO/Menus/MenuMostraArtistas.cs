using doisOO.Modelos;

namespace doisOO.Menus;

internal class MenuMostraArtistas : Menu
{
    public override void Executar(Dictionary<string, Artista> artistasRegistrados)
    {
        base.Executar(artistasRegistrados);
        ExibirTituloDaOpcao("Exibindo todos os artistas registrados.");

        foreach (string artista in artistasRegistrados.Keys)
        {
            Console.WriteLine($"Artista: {artista}.");
        }

        Console.Write("\nDigite uma tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
    }
}
