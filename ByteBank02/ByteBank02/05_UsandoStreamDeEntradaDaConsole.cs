using ByteBank02.ByteBankIO;
using System.Text;

partial class Program
{
    //Grava informações passadas no console em um arquivo.
    static void UsarStreamDeEntrada()
    {
        using(var fluxoEntrada = Console.OpenStandardInput())
        using(var fluxoArquivo = new FileStream("entradaConsole.txt", FileMode.Create))
        {
            var buffer = new byte[1024];

            while(true)
            {
                var bytesLidos = fluxoEntrada.Read(buffer, 0, 1024);

                fluxoArquivo.Write(buffer, 0, bytesLidos);
                fluxoArquivo.Flush();

                Console.WriteLine($"Bytes lidos na console: {bytesLidos}");
            }
        }
    }
}