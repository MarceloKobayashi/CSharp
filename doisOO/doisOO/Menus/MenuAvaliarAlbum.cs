using doisOO.Modelos;

namespace doisOO.Menus;

internal class MenuAvaliarAlbum : Menu
{
    public override void Executar(Dictionary<string, Artista> artistasRegistrados)
    {
        base.Executar(artistasRegistrados);

        ExibirTituloDaOpcao("Avaliar álbum.");

        Console.Write("Digite o artista que deseja avaliar: ");
        string artista = Console.ReadLine()!;

        if (artistasRegistrados.ContainsKey(artista))
        {
            Artista artistaDesejado = artistasRegistrados[artista];
            Console.Write("Digite o nome do álbum: ");
            string tituloAlbum = Console.ReadLine()!;

            if (artistaDesejado.Albums.Any(a => a.NomeAlbum.Equals(tituloAlbum)))
            {
                Album album = artistaDesejado.Albums.First(a => a.NomeAlbum.Equals(tituloAlbum));

                Console.Write($"Digite a nota que o/a {tituloAlbum} merece: ");
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);

                album.AdicionarNota(nota);

                Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para o/a {tituloAlbum}.");
                Thread.Sleep(2000);
                Console.Clear();
            } else
            {
                Console.WriteLine($"O álbum {tituloAlbum} não foi encontrado!");
                Console.Write("Digite uma tecla para voltar ao menu principal.");
                Console.ReadKey();

                Console.Clear();
            }
        }
        else
        {
            Console.WriteLine($"O artista {artista} não foi encontrado!");
            Console.Write("Digite uma tecla para voltar ao menu principal.");
            Console.ReadKey();

            Console.Clear();
        }
    }
}
