namespace doisOO.Exercicios;

class Episodio
{
    List<string> convidados = new List<string>();
    public Episodio(int numeroep, string tituloep, int duracaoep)
    {
        NumeroEp = numeroep;
        Titulo = tituloep;
        Duracao = duracaoep;
    }

    public int Duracao { get; }
    public int NumeroEp { get; }
    public string Titulo { get; }
    
    public void AdicionarConvidados(string convidado)
    {
        convidados.Add(convidado);
    }

    public string Resumo => $"{NumeroEp} - {Titulo}({Duracao}min) feat. {string.Join(", ", convidados)}";
}