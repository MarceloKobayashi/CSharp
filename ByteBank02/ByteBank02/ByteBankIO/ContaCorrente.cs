namespace ByteBank02.ByteBankIO;

internal class ContaCorrente
{
    public int Numero { get; set; }
    public int Agencia { get; set; }
    public double Saldo { get; set; }
    public Cliente Titular { get; set; }

    public ContaCorrente(int agencia, int numero)
    {
        Agencia = agencia;
        Numero = numero;
    }

    public void Depositar(double valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("Valor de depósito deve ser maior que zero.", nameof(valor));
        }
        Saldo += valor;
    }

    public void Sacar(double valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("Valor de saque deve ser maior que zero.", nameof(valor));
        }
        if (valor > Saldo)
        {
           // throw InvalidOperationException("Saldo insuficiente.");
        }
        Saldo -= valor;
    }

    public override string ToString()
    {
        return $"{Titular.Nome} - Número da conta: {Numero}, Ag: {Agencia}, Saldo: {Saldo}.";
    }
}
