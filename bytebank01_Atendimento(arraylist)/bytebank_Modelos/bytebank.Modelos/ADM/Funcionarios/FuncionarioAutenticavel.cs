﻿using bytebank.Modelos.ADM.SistemaInterno;
using bytebank_Modelos.bytebank.Modelos.ADM.Utilitario;

namespace bytebank_Modelos.bytebank.Modelos.ADM.Funcionarios;

public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel
{
    public string Senha { get; set; }

    public FuncionarioAutenticavel(double salario, string cpf)
        : base(salario, cpf)
    {

    }
    internal AutenticacaoUtil Autenticador { get; set; }
    public bool Autenticar(string senha)
    {
        return this.Autenticador.ValidarSenha(this.Senha, senha);
    }
}
