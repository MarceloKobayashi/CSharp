namespace bytebank_GeradorChavePix03;

/// <summary>
/// Classe que gera chaves pix aleatórias usando o formato Guid.
/// </summary>
public static class GeradorPix
{
    /// <summary>
    /// Método que retorna uma chave pix aleatória.
    /// </summary>
    /// <returns>Retorna uma chave PIX no formato String.</returns>
    public static string GetChavePix()
    {
        return Guid.NewGuid().ToString();
    }

    /// <summary>
    ///Método que retorna uma lista de chaves pix aleatórias. 
    /// </summary>
    /// <param name="numeroChaves">Quantidade de chaves a serem geradas e incluídas na lista.</param>
    /// <returns>Lista de strings de chaves pix aleatórias.</returns>
    public static List<string> GetChavesPix(int numeroChaves)
    {
        if (numeroChaves <= 0)
        {
            return null;
        }
        else
        {
            var chaves = new List<string>();
            for (int i = 0; i < numeroChaves; i++)
            {
                chaves.Add(Guid.NewGuid().ToString());
            }
            return chaves;
        }
    }
}
