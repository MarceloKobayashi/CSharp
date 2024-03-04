using ByteBank02.ByteBankIO;

partial class Program
{
    static void LendoArquivo()
    {
        using (var fluxoDeArquivo = new FileStream("contas.txt", FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDeArquivo);
            //Console.WriteLine(leitor.ReadLine()); => Mostra uma linha.
            //Console.WriteLine(leitor.ReadToEnd()); => Mostra todo o arquivo, mas arquivos muito grandes não.
            //Console.WriteLine(leitor.Read()); => Traz o primeiro byte do arquivo.

            while (!leitor.EndOfStream)   //Enquanto não chegar ao fim do fluxo.
            {
                var contaCorrente = ConverterStringParaContaCorrente(leitor.ReadLine());
                Console.WriteLine(contaCorrente);

                //Console.WriteLine(leitor.ReadLine());   //Loop parecido com ReadToEnd(), mas codifica linha por linha.
            }
        }
        Console.ReadLine();
    }

    //Criar contas corrente a partir dos dados do arquivo.
    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        var campos = linha.Split(',');

        var agencia = int.Parse(campos[0]);
        var numero = int.Parse(campos[1]);
        var saldo = campos[2].Replace('.', ',');    //Troca . por , para reconhecer como centavos.
        var nomeTitular = campos[3];

        var saldoDouble = double.Parse(saldo);

        Cliente titular = new Cliente()
        {
            Nome = nomeTitular,
        };

        var resultado = new ContaCorrente(agencia, numero);
        resultado.Depositar(saldoDouble);
        resultado.Titular = titular;

        return resultado;
    }
}