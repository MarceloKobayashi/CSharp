﻿namespace bytebank_Modelos.bytebank.Modelos.ADM.Funcionarios;

public abstract class Funcionario
{
    public static int TotalDeFuncionarios { get; private set; }

    public string Nome { get; set; }
    public string CPF { get; private set; }
    public double Salario { get; protected set; }

    public Funcionario(double salario, string cpf)
    {
        Console.WriteLine("Criando FUNCIONARIO");

        this.CPF = cpf;
        this.Salario = salario;

        TotalDeFuncionarios++;
    }

    public abstract void AumentarSalario();
    protected internal abstract double getBonificacao();   //possivel implementar um método internal em um projeto(protected internal) 
}
