using bytebank_GeradorChavePix03;
using bytebank_Modelos.bytebank.Modelos.ADM.Funcionarios;
using bytebank_Modelos.bytebank.Modelos.ADM.Utilitario;
using bytebank01.bytebank.Atendimento;


Console.WriteLine("Boas Vindas ao ByteBank!\n");

//new ByteBankAtendimento().AtendimentoCliente();

//public class Estagiario : Funcionario
//{
//    public Estagiario(double salario, string cpf) : base(salario, cpf)
//    {

//    }

//    public override void AumentarSalario()
//    {
//        throw new NotImplementedException();
//    }

//    protected override double getBonificacao()
//    {
//        throw new NotImplementedException();
//    }
//}

var listaChaves = GeradorPix.GetChavesPix(10);
foreach (var chave in listaChaves)
{
    Console.WriteLine(chave);
}