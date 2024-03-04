namespace doisOO.Exercicios;

class Podcast
{
    public Podcast(string host, string nome) 
    {
        Host = host;
        Nome = nome;
    }
    public string Host { get; }
    public string Nome { get; }

    List<Episodio> episodios = new List<Episodio>();
    public int TotalEpisodios => episodios.Count;

    public void AdicionarEpisodio(Episodio ep)
    {
        episodios.Add(ep);

        Console.WriteLine($"Epísódio {ep.Titulo} adicionado com sucesso!\n");
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Podcast: {Nome} - Host: {Host} - Total de ep: {TotalEpisodios}");

        foreach (Episodio ep in episodios)
        {
            Console.WriteLine(ep.Resumo);
        }
    }
}