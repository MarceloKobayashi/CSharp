using ByteBank02.ByteBankIO;
using System.Text;

partial class Program
{
    //Sobrescreve o arquivo.
    static void CriarArquivo()
    {
        var caminhoNovoArquivo = "contasExportadas.csv";

        using(var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            var contaString = "456, 7895, 4785.40, Gustavo Santos";
            var encoding = Encoding.UTF8;
            var bytes = encoding.GetBytes(contaString);

            //Buffer, posição inicial e tamanho do buffer
            fluxoDeArquivo.Write(bytes, 0, bytes.Length);
        }
    }

    //Forma mais simples para criar um arquivo com o StreamWriter.
    static void CriarArquivoComWriter()
    {
        var caminhoNovoArquivo = "contasExportadas.csv";

        using(var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using(var escritor = new StreamWriter(fluxoArquivo))
        {
            escritor.Write("456,65465,456.0,Pedro");
        }
    }

    static void TestaEscrita()
    {
        var caminhoArquivo = "teste.txt";

        using(var fluxoArquivo = new FileStream(caminhoArquivo, FileMode.Create))
        using(var escritor = new StreamWriter(fluxoArquivo))
        {
            for (int i=0; i<1000000; i++)
            {
                escritor.WriteLine($"Linha {i}");

                //Despeja o buffer para o Stream a cada linha escrita. Para que a escrita no arquivo seja quase que instantânea.
                escritor.Flush();   
                Console.Write($"Linha {i} foi escrita no arquivo. Tecle enter: ");
                Console.ReadLine();
            }
        }
    }
}