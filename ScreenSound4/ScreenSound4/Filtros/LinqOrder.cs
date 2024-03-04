using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenSound4.Modelos;

namespace ScreenSound4.Filtros;

internal class LinqOrder
{
    public static void ExibirListaArtistas(List<Musica> musicas)
    {
        //Ordena pelo nome do artista, seleciona os nomes dos artistas, tira o que repete e transforma em uma lista. 
        var artistasOrdenados = musicas.OrderBy(musica => musica.Artista).Select(musica => musica.Artista).Distinct().ToList();

        Console.WriteLine("Lista de artistas ordenados: ");
        foreach(var artista in artistasOrdenados)
        {
            Console.WriteLine($"- {artista}");
        }
    }
}
