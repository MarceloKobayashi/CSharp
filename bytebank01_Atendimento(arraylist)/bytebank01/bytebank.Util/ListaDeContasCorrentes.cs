using bytebank.Modelos.Conta;

namespace bytebank01.bytebank.Util;

public class ListaDeContasCorrentes
{
    private ContaCorrente[] contas = null;
    public int proximaPosicao = 0;

    public ListaDeContasCorrentes(int tamanhoInicial=5) //se não passar parâmetro o valor é 5
    {
        contas = new ContaCorrente[tamanhoInicial];
    }

    public void AdicionarConta(ContaCorrente conta)
    {
        VerificarTamanho(proximaPosicao + 1);

        contas[proximaPosicao] = conta;
        Console.WriteLine($"A conta {conta.Conta} foi adicionada na lista.");
        proximaPosicao++;
    }

    private void VerificarTamanho(int tamanhoNecessario)
    {
        if (contas.Length >= tamanhoNecessario)
        {
            return;
        }

        Console.WriteLine("Aumentando tamanho da lista.");
        ContaCorrente[] novaLista = new ContaCorrente[tamanhoNecessario];

        for (int i = 0; i < contas.Length; i++)
        {
            novaLista[i] = contas[i];
        }
        contas = novaLista;
    }

    //public ContaCorrente ContaMaiorSaldo()
    //{
    //    ContaCorrente contaMaiorSaldo = contas[0];
    //    foreach (var conta in contas)
    //    {
    //        if (conta.Saldo > contaMaiorSaldo.Saldo)
    //        {
    //            contaMaiorSaldo = conta;
    //        }
    //    }
    //    return contaMaiorSaldo;
    //}

    public void Remover(ContaCorrente conta)
    {
        int indiceItem = -1;
        for (int i = 0; i < proximaPosicao; i++)
        {
            if (contas[i].Equals(conta))
            {
                indiceItem = i;
                break;
            }
        }
        for (int i = indiceItem; i < proximaPosicao - 1; i++)
        {
            contas[i] = contas[i + 1];
        }
        proximaPosicao--;
        contas[proximaPosicao] = null;
    }

    public void ExibeLista()
    {
        for (int i = 0; i < contas.Length; i++)
        {
            if (contas[i] != null)
            {
                var conta = contas[i];
                Console.WriteLine($" Indice[{i}] = Conta:{conta.Conta} - N° da Agência: {conta.Numero_agencia}");
            }
        }
    }

    public ContaCorrente RecuperarContaPeloIndice(int indice)
    {
        if ((indice < 0) || (indice >= proximaPosicao))
        {
            throw new ArgumentOutOfRangeException(nameof(indice));
        }
        return contas[indice];
    }

    //Torna o Array indexavel: listaContas[i] se torna possível
    public ContaCorrente this[int indice]
    {
        get
        {
            return RecuperarContaPeloIndice(indice);
        }
    }
}
