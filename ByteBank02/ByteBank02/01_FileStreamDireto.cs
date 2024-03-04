using ByteBank02.ByteBankIO;
using System.Text;

partial class Program   //A classe está sendo trabalhada de forma única em vários arquivos. => partial
{
    static void FileStreamDireto()
    {
        var enderecoDoArquivo = "contas.txt";

        //Cria um try/catch para ver se o fluxo é nulo e se não for executa um método dispose().
        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var numerodDeBytesLidos = -1;


            //Estrutura do read => public override int Read(byte[] array, int offset, int count);
            //-Armazena os bytes lidos(buffer), índice que o método começa a preencher o array, quantas posições deseja preencher.

            var buffer = new byte[1024];    //1KB

            while (numerodDeBytesLidos != 0)
            {
                numerodDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);

                Console.WriteLine($"\n\nBytes lidos: {numerodDeBytesLidos}.\n");

                EscreverBuffer(buffer, numerodDeBytesLidos); //Pega 1024, ou mais caso esteja sobrando menos de 1024 bytes no arquivo, depois imprime 0.
            }

            fluxoDoArquivo.Close(); //Libera o arquivo para ser alterado.

            Console.ReadLine();
        }
    }

    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        var utf8 = new UTF8Encoding();      //Conversor em texto

        //public virtual string GetString(byte[] bytes, int index, int count); == Read();
        var texto = utf8.GetString(buffer, 0, bytesLidos); //Usa o conversor para transformar os bytes do buffer em texto

        Console.Write(texto);
    }
}