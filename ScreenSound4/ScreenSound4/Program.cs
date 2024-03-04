using ScreenSound4.Modelos;
using ScreenSound4.Filtros;
using System.Text.Json;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");

        //Converte o json para a linguagem(Desserialização)
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        //LinqFilter.FiltrarGeneros(musicas);
        //LinqOrder.ExibirListaArtistas(musicas);
        //LinqFilter.FiltrarArtistaPorGenero(musicas, "pop");
        //LinqFilter.FiltrarMusicasArtista(musicas, "Kendrick Lamar");
        //LinqFilter.FiltrarMusicaAno(musicas, 2012);
        LinqFilter.FiltrarMusicaTom(musicas, "C#");

        //var musicasFavoritasMarcelo = new MusicasFavoritas("Marcelo");
        //musicasFavoritasMarcelo.AdicionarMusicasFavoritas(musicas[1]);
        //musicasFavoritasMarcelo.AdicionarMusicasFavoritas(musicas[377]);
        //musicasFavoritasMarcelo.AdicionarMusicasFavoritas(musicas[4]);
        //musicasFavoritasMarcelo.AdicionarMusicasFavoritas(musicas[6]);
        //musicasFavoritasMarcelo.AdicionarMusicasFavoritas(musicas[1467]);

        //musicasFavoritasMarcelo.ExibirMusicasFavoritas();

        //musicasFavoritasMarcelo.GerarArquivoJson();
    } catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}.");
    }
}