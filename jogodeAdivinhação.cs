Random aleatorio = new Random();
int numeroSecreto = aleatorio.Next(1, 100);

do
{
    Console.Write("Digite um número entre 1 e 100: ");
    string chute = Console.ReadLine()!;
    int chuteInt = int.Parse(chute);

    if (chuteInt <= 0 || chuteInt > 100)
    {
        Console.WriteLine("Número inválido!");
    }else if (chuteInt == numeroSecreto)
    {
        Console.WriteLine("Você acertou!");
        break;
    } else if (chuteInt > numeroSecreto)
    {
        Console.WriteLine("O número secreto é menor que " + chuteInt + ".");
    } else
    {
        Console.WriteLine("O número secreto é maior que " + chuteInt + ".");
    }

} while (true);
