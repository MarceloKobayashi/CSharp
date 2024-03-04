namespace doisOO.Modelos;

internal class Artista : IAvaliavel
{
    private List<Album> albums = new List<Album>();

    private List<Avaliacao> notas = new List<Avaliacao>();

    public Artista(string nome)
    {
        NomeArtista = nome;
    }
    public string NomeArtista { get; }

    public double Media {
        get
        {
            if(notas.Count == 0) return 0;
            else return notas.Average(a => a.Nota);
        }
    }

    public string? Resumo { get; set; }

    public List<Album> Albums => albums;

    public void AdicionarAlbum(Album album)
    {
        albums.Add(album);
    }

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia do artista {NomeArtista}\n");

        foreach(Album album in albums)
        {
            Console.WriteLine($"Álbum:{album.NomeAlbum} ({album.DuracaoTotal}s)");
        }
    }
}