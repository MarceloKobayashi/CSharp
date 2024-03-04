using ByteBank02.ByteBankIO;
using System.Text;
using System.Xml;

partial class Program
{
    static void Main(string[] args)
    {
        var linhas = File.ReadAllLines("contas.txt");
        Console.WriteLine(linhas.Length);

        /*
        foreach(var linha in linhas)
        {
            Console.WriteLine(linha);
        }
        */

        var bytesArquivo = File.ReadAllBytes("contas.txt");     //Lê todos os bytes do File.
        Console.WriteLine($"Arquivo contas.txt possui {bytesArquivo.Length} bytes.");

        //Cria um arquivo com uma informação predefinida.
        File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText");

        Console.ReadLine();
    }
}
