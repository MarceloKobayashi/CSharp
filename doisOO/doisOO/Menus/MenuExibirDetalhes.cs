using doisOO.Modelos;

namespace doisOO.Menus;

internal class MenuExibirDetalhes : Menu
{
    public override void Executar(Dictionary<string, Artista> artistasRegistrados)
    {    
        base.Executar(artistasRegistrados);
        ExibirTituloDaOpcao("Detalhes do artista.");

        Console.Write("Digite o nome do/a artista que deseja: ");
        string nomeDoArtista = Console.ReadLine()!;
        if (artistasRegistrados.ContainsKey(nomeDoArtista))
        {
            Artista artista = artistasRegistrados[nomeDoArtista];
            Console.WriteLine(artista.Resumo);
            Console.WriteLine($"\nA média do artista {nomeDoArtista} é {artista.Media}");

            if (artista.Albums.Count == 0)
            {
                Console.WriteLine($"O artista {artista.NomeArtista} não possui álbuns.\n");
            } else
            {
                Console.WriteLine("\nDiscografia:");

                int numero = 1;
                foreach (Album album in artista.Albums)
                {
                    Console.WriteLine($"{numero} - {album.NomeAlbum} -> {album.Media}");
                    numero++;
                }
            }

            Console.Write("Digite uma tecla para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO artista {nomeDoArtista} não foi encontrado!");
            Console.Write("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
