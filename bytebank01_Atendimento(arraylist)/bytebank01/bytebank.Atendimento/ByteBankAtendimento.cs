using bytebank.Modelos.Conta;
using bytebank01.bytebank.Exceptions;
using Newtonsoft.Json;

namespace bytebank01.bytebank.Atendimento;

internal class ByteBankAtendimento
{
    private List<ContaCorrente> listaDeContas = new List<ContaCorrente>()
    {
    new ContaCorrente(1) {Saldo=100,Titular=new Cliente{Cpf="111",Nome="Marcelo",Profissao="Dev"}}
    };
    public void AtendimentoCliente()
    {
        try
        {
            int opcao = 0;
            while (opcao != 7)
            {
                Console.Clear();
                Console.WriteLine("Atendimento.");
                Console.WriteLine("1. Cadastrar conta.");
                Console.WriteLine("2. Listar contas.");
                Console.WriteLine("3. Remover conta.");
                Console.WriteLine("4. Ordenar contas.");
                Console.WriteLine("5. Pesquisar conta.");
                Console.WriteLine("6. Exportar contas.");
                Console.WriteLine("7. Sair.\n");

                Console.Write("Digite sua opção: ");
                try
                {
                    opcao = int.Parse(Console.ReadLine()!);
                }
                catch (Exception excecao)
                {
                    throw new ByteBankException(excecao.Message);
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarConta();
                        break;
                    case 2:
                        ListarContas();
                        break;
                    case 3:
                        ExcluirConta();
                        break;
                    case 4:
                        OrdenarContas();
                        break;
                    case 5:
                        PesquisarConta();
                        break;
                    case 6:
                        ExportarContas();
                        break;
                    case 7:
                        SairAtendimento();
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
        catch (ByteBankException excecao)
        {
            Console.WriteLine($"{excecao.Message}");
        }
    }

    private void CadastrarConta()
    {
        Console.Clear();
        Console.WriteLine("Cadastrando conta.\n");

        Console.Write("Número da agência: ");
        int numeroAgencia = int.Parse(Console.ReadLine()!);

        Console.Write("Nome do titular: ");
        string nomeTitular = Console.ReadLine()!;
        Console.Write("CPF do titular: ");
        string cpfTitular = Console.ReadLine()!;
        Console.Write("Profissão do titular: ");
        string profissaoTitular = Console.ReadLine()!;

        Cliente cliente = new Cliente()
        {
            Nome = nomeTitular,
            Cpf = cpfTitular,
            Profissao = profissaoTitular
        };

        ContaCorrente conta = new ContaCorrente(numeroAgencia);
        conta.Titular = cliente;

        Console.Write("Digite o saldo: ");
        conta.Saldo = double.Parse(Console.ReadLine()!);

        listaDeContas.Add(conta);
        Console.WriteLine($"Conta de {conta.Titular.Nome} cadastrada com sucesso!\n");
        Console.WriteLine($"Número da conta: {conta.Conta}.\n");

        Console.Write("Digite qualquer tecla para voltar ao menu: ");
        Console.ReadKey();

        AtendimentoCliente();
    }

    private void ListarContas()
    {
        Console.Clear();
        Console.WriteLine("Listando contas.\n");

        if (listaDeContas.Count == 0)
        {
            Console.WriteLine("Não há contas.");
            Console.WriteLine("Digite qualquer tecla para voltar ao menu: ");
            Console.ReadKey();
            AtendimentoCliente();
        }
        foreach (ContaCorrente conta in listaDeContas)
        {
            Console.WriteLine(conta);
        }

        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu: ");
        Console.ReadKey();
        AtendimentoCliente();
    }

    private void ExcluirConta()
    {
        Console.Clear();
        Console.WriteLine("Removendo contas.\n");

        ContaCorrente contaExcluir = null;

        Console.Write("Digite o número da conta que deseja excluir: ");
        string numeroExcluir = Console.ReadLine()!;

        foreach (var conta in listaDeContas)
        {
            if (conta.Conta.Equals(numeroExcluir))
            {
                contaExcluir = conta;
                break;
            }
        }

        if (contaExcluir != null)
        {
            listaDeContas.Remove(contaExcluir);
            Console.WriteLine("Conta removida com sucesso.");
        }
        else
        {
            Console.WriteLine("Conta inexistente na lista de contas.");
        }
        Console.Write("Digite uma tecla para voltar ao menu: ");
        Console.ReadKey();

        AtendimentoCliente();
    }

    private void OrdenarContas()
    {
        Console.Clear();
        Console.WriteLine("Ordenando lista.");

        listaDeContas.Sort();

        Thread.Sleep(2000);
        Console.WriteLine("Lista ordenada com sucesso.");
        Console.Write("Digite uma tecla para voltar ao menu principal: ");
        Console.ReadKey();

        AtendimentoCliente();
    }

    private void PesquisarConta()
    {
        Console.Clear();
        Console.WriteLine("Pesquisando contas.\n");

        Console.Write("Deseja pesquisar por (1)-Número da conta ou (2)-CPF do titular ou (3)-Número da agência: ");
        switch (int.Parse(Console.ReadLine()!))
        {
            case 1:
                Console.Write("Digite o número da conta: ");
                string numeroConta = Console.ReadLine()!;

                ContaCorrente contaNumero = listaDeContas
                    .Where(c => c.Conta.Equals(numeroConta))
                    .FirstOrDefault()!;

                if (contaNumero == null)
                {
                    Console.WriteLine("Esse número de conta não está na lista.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(contaNumero);
                }
                Console.ReadKey();
                break;

            case 2:
                Console.Write("Digite o cpf do titular: ");
                string cpf = Console.ReadLine()!;

                ContaCorrente contaCpf = listaDeContas
                    .Where(c => c.Titular.Cpf.Equals(cpf))
                    .FirstOrDefault()!;

                if (contaCpf == null)
                {
                    Console.WriteLine("Esse CPF de titular não está na lista.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(contaCpf);
                }
                Console.ReadKey();
                break;
            case 3:
                Console.Write("Digite o número da agência: ");
                int numeroAgencia = int.Parse(Console.ReadLine()!);

                List<ContaCorrente> contasAgencia = listaDeContas
                    .Where(c => c.Numero_agencia.Equals(numeroAgencia))
                    .Select(c => c)
                    .Distinct()
                    .ToList();

                if (contasAgencia.Count() == 0)
                {
                    Console.WriteLine("Não existem contas com esse número na lista.");
                }
                else
                {
                    Console.WriteLine();
                    foreach (var account in contasAgencia)
                    {
                        Console.WriteLine(account);
                    }
                }
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
        Console.Write("\nDigite uma tecla para voltar ao menu principal: ");
        Console.ReadKey();

        AtendimentoCliente();
    }

    private void ExportarContas()
    {
        Console.Clear();
        Console.WriteLine("Exportando contas.\n");

        if (listaDeContas.Count <= 0)
        {
            Console.WriteLine("Não existem dados para exportação.");
            Console.ReadKey();
        } 
        else
        {
            string json = JsonConvert.SerializeObject(listaDeContas, Formatting.Indented);      //Transforma para json

            try
            {
                var novoArquivo = "contas.json";
                FileStream fluxoDoArquivo = new FileStream(novoArquivo, FileMode.Create);
                using(StreamWriter escritor = new StreamWriter(fluxoDoArquivo))
                {
                    escritor.WriteLine(json);
                }
                Console.WriteLine($"Arquivo salvo em {novoArquivo}.");
                Thread.Sleep(3000);
            } 
            catch (Exception excecao)
            {
                throw new ByteBankException(excecao.Message);
                Console.ReadKey();
            }
        }
    }

    private void SairAtendimento()
    {
        Console.WriteLine("Tchau.");
        Environment.Exit(0);
    }
}
