namespace ScreenSound4.Modelos;
using System.Text.Json;

internal class MusicasFavoritas
{
    public string? Nome { get; set; }
    public List<Musica> ListaFavoritas { get; }

    public MusicasFavoritas(string nome)
    {
        Nome = nome;
        ListaFavoritas = new List<Musica>();
    }

    public void AdicionarMusicasFavoritas(Musica musica)
    {
        ListaFavoritas.Add(musica);
    }

    public void ExibirMusicasFavoritas()
    {
        Console.WriteLine($"Essas são as músicas favoritas do {Nome}.\n");
        foreach(var musica in ListaFavoritas)
        {
            Console.WriteLine($"- {musica.Nome} de {musica.Artista}.");
        }
        Console.WriteLine();
    }

    public void GerarArquivoJson()
    {
        string json = JsonSerializer.Serialize(new
        {
            nome = Nome,
            musicas = ListaFavoritas
        });
        string nomeArquivo = $"Músicas-favoritas-{Nome}.json";

        File.WriteAllText(nomeArquivo, json);
        Console.WriteLine($"O arquivo json foi criado com sucesso. {Path.GetFullPath(nomeArquivo)}");
    }
}
