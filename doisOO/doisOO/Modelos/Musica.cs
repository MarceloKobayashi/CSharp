namespace doisOO.Modelos;

internal class Musica
{
    public Musica(Artista artista, string nome)
    {
        Artista = artista;
        Nome = nome;
    }
    public string Nome {  get; }
    public Artista Artista {  get; }
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }
    public string DescricaoMusica => $"A música {Nome} pertence ao artista {Artista.NomeArtista}.\n";   //lambda

    public void ExibirFichaMusica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista.NomeArtista}");
        Console.WriteLine($"Duração: {Duracao}");
        if (Disponivel) {
            Console.WriteLine("Disponível no plano.\n");
        } else {
            Console.WriteLine("Adquira no plano plus.\n");
        }
        Console.WriteLine(DescricaoMusica);
    }
}