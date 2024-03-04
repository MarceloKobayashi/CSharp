using ScreenSound4.Modelos;
using System.Runtime.CompilerServices;

namespace ScreenSound4.Filtros;

internal class LinqFilter
{
    private string[] tonalidades = { "C", "C#", "D", "Eb", "E", "F", "F#", "G", "Ab", "A", "Bb", "B" };
    public static void FiltrarGeneros(List<Musica> musicas)
    {
        var todosOsGenerosMusicais = musicas.Select(generos => generos.Genero).Distinct().ToList();

        foreach(var genero in todosOsGenerosMusicais)
        {
            Console.WriteLine($"- {genero}");
        }
    }

    public static void FiltrarArtistaPorGenero(List<Musica> musicas, string genero)
    {
        var artistaPorGenero = musicas
            .Where(musica => musica.Genero!.Contains(genero))
            .Select(musica => musica.Artista)
            .Distinct()
            .ToList();

        Console.WriteLine($"Exibindo os artistas de {genero}:");
        foreach(var artista in artistaPorGenero)
        {
            Console.WriteLine($"- {artista}");
        }
    }

    public static void FiltrarMusicasArtista(List<Musica> musicas, string nomeArtista)
    {
        var musicasFiltradas = musicas
            .Where(musica => musica.Artista!.Equals(nomeArtista))
            .ToList();

        Console.WriteLine(nomeArtista);
        foreach(var musica in musicasFiltradas)
        {
            Console.WriteLine($"- {musica.Nome}");
        }
    }

    public static void FiltrarMusicaAno(List<Musica> musicas, int ano)
    {
        string year = ano.ToString();
        var musicasAno = musicas
            .Where(musica => musica.Ano == year)
            .Select(musica => musica.Nome)
            .Distinct()
            .ToList();

        Console.WriteLine($"Músicas do ano {ano}: ");
        foreach(var musica in musicasAno)
        {
            Console.WriteLine($"- {musica}");
        }
    }

    public static void FiltrarMusicaTom(List<Musica> musicas, string tonalidade)
    {
        var musicaTom = musicas
            .Where(musica => musica.Tonalidade == tonalidade)
            .Select(musica => musica.Nome)
            .ToList();

        Console.WriteLine($"Músicas do tom {tonalidade}: ");
        foreach (var musica in musicaTom)
        {
            Console.WriteLine($"- {musica}");
        } 
    }
}
