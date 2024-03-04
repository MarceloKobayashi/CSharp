//Screen Sound

using doisOO.Modelos;
using doisOO.Menus;

Artista cc = new Artista("Central Cee");
cc.AdicionarNota(new Avaliacao(10));
cc.AdicionarNota(new Avaliacao(8));
cc.AdicionarNota(new Avaliacao(6));

Artista kl = new Artista("Kendrick Lamar");

Dictionary<string, Artista> artistasRegistrados = new();
artistasRegistrados.Add(cc.NomeArtista, cc);
artistasRegistrados.Add(kl.NomeArtista, kl);

Dictionary<int, Menu> opcoes = new Dictionary<int, Menu>();
opcoes.Add(1, new MenuRegistrarArtista());
opcoes.Add(2, new MenuRegistraAlbum());
opcoes.Add(3, new MenuMostraArtistas());
opcoes.Add(4, new MenuAvaliarArtista());
opcoes.Add(5, new MenuAvaliarAlbum());
opcoes.Add(6, new MenuExibirDetalhes());
opcoes.Add(-1, new MenuSair());

void ExibirLogo()
{
    Console.WriteLine(@"

    █▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄
    ▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀
    ");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar um artista.");
    Console.WriteLine("Digite 2 para registrar um álbum de um artista.");
    Console.WriteLine("Digite 3 para mostrar todos os artistas.");
    Console.WriteLine("Digite 4 para avaliar um artista.");
    Console.WriteLine("Digite 5 para avaliar um álbum.");
    Console.WriteLine("Digite 6 para exibir os detalhes de um artista.");
    Console.WriteLine("Digite -1 para sair.");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaInt = int.Parse(opcaoEscolhida);

    if (opcoes.ContainsKey(opcaoEscolhidaInt))
    {
        Menu menuASerExibido = opcoes[opcaoEscolhidaInt];
        menuASerExibido.Executar(artistasRegistrados);

        if (opcaoEscolhidaInt > 0)
        {
            ExibirOpcoesDoMenu();
        }
    }
    else
    {
        Console.WriteLine("Opção inválida!");
    }
}

ExibirOpcoesDoMenu();
