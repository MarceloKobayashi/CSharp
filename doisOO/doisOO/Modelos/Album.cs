namespace doisOO.Modelos;

internal class Album : IAvaliavel
{
    private List<Musica> musicas = new List<Musica>();
    private List<Avaliacao> notas = new List<Avaliacao>();

    public static int ContadorDeObjetos = 0;

    public Album(string nomeAlbum)
    {
        NomeAlbum = nomeAlbum;
        ContadorDeObjetos++;
    }

    public string NomeAlbum { get; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);

    public double Media
    {
        get
        {
            if (notas.Count == 0) return 0;
            else return notas.Average(n => n.Nota);
        }
    }

    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void ExibirMusicas()
    {
        Console.WriteLine($"Lista de músicas do álbum: {NomeAlbum}\n");
        
        foreach (var musica in musicas)
        {
            Console.WriteLine($"Música: {musica.Nome}");
        }
        Console.WriteLine($"\nTempo para ouvir tais músicas: {DuracaoTotal}s.");
    }

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }
}