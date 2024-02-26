﻿namespace bytebank.Modelos.Conta;

public class Cliente
{

    public string Cpf { get; set; }

    public string Nome { get; set; }
    public Cliente(string nome) => Nome = nome;
    public string Profissao { get; set; }
    public static int TotalClientesCadastrados { get; set; }

    public Cliente()
    {
        TotalClientesCadastrados = TotalClientesCadastrados + 1;
    }
}