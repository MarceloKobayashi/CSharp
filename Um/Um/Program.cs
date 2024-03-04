//Screen Sound

//List<string> artistas = new List<string> {"Central Cee", "Kendrick Lamar"};

Dictionary<string, List<int>> artistasNotas = new Dictionary<string, List<int>>();
artistasNotas.Add("Central Cee", new List<int> {10, 8, 7, 3, 0});
artistasNotas.Add("Kendrick Lamar", new List<int>());

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
    Console.WriteLine("Digite 2 para mostrar todas os artistas.");
    Console.WriteLine("Digite 3 para avaliar um artista.");
    Console.WriteLine("Digite 4 para exibir a média de um artista.");
    Console.WriteLine("Digite -1 para sair.");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaInt = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaInt)
    {
        case 1:
            RegistrarArtista();
            break;
        case 2:
            MostrarArtistasRegistrados();
            break;
        case 3:
            AvaliarArtista();
            break;
        case 4:
            MostrarMediaArtista();
            break;
        case -1:
            Console.WriteLine("Flw.");
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}

void RegistrarArtista()
{
    Console.Clear();
    Console.WriteLine("Registro de artistas.");
    Console.Write("Digite o nome do artista que deseja registrar: ");
    string nomeDoArtista = Console.ReadLine()!;

    artistasNotas.Add(nomeDoArtista, new List<int>());

    Console.WriteLine($"O artista {nomeDoArtista} foi registrado(a) com sucesso!");
    Thread.Sleep(2000);

    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarArtistasRegistrados()
{
    Console.Clear();
    Console.WriteLine("Exibindo todos os artistas registrados.\n");

    foreach(string artista in artistasNotas.Keys)
    {
        Console.WriteLine($"Artista: {artista}.");
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();

    ExibirOpcoesDoMenu();
}

void AvaliarArtista()
{
    Console.Clear();
    Console.WriteLine("Avaliar artista.");

    Console.Write("Digite o artista que deseja avaliar: ");
    string artista = Console.ReadLine()!;

    if (artistasNotas.ContainsKey(artista)) {
        Console.Write($"Digite a nota que o/a {artista} merece: ");
        int nota = int.Parse(Console.ReadLine()!);

        artistasNotas[artista].Add(nota);

        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para o/a {artista}.");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"O artista {artista} não foi encontrado!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal.");
        Console.ReadKey();

        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void MostrarMediaArtista()
{
    Console.Clear();
    Console.WriteLine("Exibindo média do artista.\n");
    Console.Write("Digite o/a artista que deseja ver a média: ");
    string artista = Console.ReadLine()!;

    if (artistasNotas.ContainsKey(artista))
    {
        double media = artistasNotas[artista].Average();

        Console.WriteLine($"A média das notas do/a {artista} é {media}");

        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine("Artista não está registrado!");
        Console.Write("Digite qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();

        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

ExibirOpcoesDoMenu();
