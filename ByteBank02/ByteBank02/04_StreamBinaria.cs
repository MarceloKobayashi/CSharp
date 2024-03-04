using ByteBank02.ByteBankIO;
using System.Text;

partial class Program
{
    static void EscritaBinaria()
    {
        using(var fluxoArquivo = new FileStream("contaCorrente.txt", FileMode.Create))
        using(var escritor = new BinaryWriter(fluxoArquivo))
        {
            escritor.Write(456);    //Número da agência
            escritor.Write(546544); //Número da conta
            escritor.Write(4000.50);    //Saldo
            escritor.Write("Gustavo Braga");
        }
    }

    static void LeituraBinaria()
    {
        using(var fluxoArquivo = new FileStream("contaCorrente.txt", FileMode.Open))
        using(var leitor = new BinaryReader(fluxoArquivo))
        {
            var agencia = leitor.ReadInt32();
            var numeroConta = leitor.ReadInt32();
            var saldo = leitor.ReadDouble();
            var titular = leitor.ReadString();

            Console.WriteLine($"{agencia}/{numeroConta} {titular} {saldo}.");
        }
    }
}