using doisOO.Modelos;

namespace doisOO.Menus;

internal class MenuRegistraAlbum : Menu
{
    public override void Executar (Dictionary<string, Artista> artistasRegistrados)
    {
        base.Executar(artistasRegistrados);
        ExibirTituloDaOpcao("Registro de álbuns.");

        Console.Write("Digite o nome do artista cujo álbum deseja registrar: ");
        string nomeArtista = Console.ReadLine()!;

        if (artistasRegistrados.ContainsKey(nomeArtista))
        {
            Console.Write("Digite o título do álbum: ");
            string tituloAlbum = Console.ReadLine()!;

            Artista artista = artistasRegistrados[nomeArtista];
            artista.AdicionarAlbum(new Album(tituloAlbum));

            Console.WriteLine($"O álbum {tituloAlbum} do/a {nomeArtista} foi registrado.");
            Thread.Sleep(2000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO artista {nomeArtista} não foi encontrado.");
            Console.Write("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
