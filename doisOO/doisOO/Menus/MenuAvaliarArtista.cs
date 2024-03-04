﻿using doisOO.Modelos;

namespace doisOO.Menus;

internal class MenuAvaliarArtista : Menu
{
    public override void Executar (Dictionary<string, Artista> artistasRegistrados)
    {
        base.Executar(artistasRegistrados);
        ExibirTituloDaOpcao("Avaliar artista");

        Console.Write("Digite o artista que deseja avaliar: ");
        string artista = Console.ReadLine()!;

        if (artistasRegistrados.ContainsKey(artista))
        {
            Artista artistaDesejado = artistasRegistrados[artista];

            Console.Write($"Digite a nota que o/a {artista} merece: ");
            Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);

            artistaDesejado.AdicionarNota(nota);

            Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para o/a {artista}.");
            Thread.Sleep(2000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"O artista {artista} não foi encontrado!");
            Console.Write("Digite uma tecla para voltar ao menu principal.");
            Console.ReadKey();

            Console.Clear();
        }
    }
}
