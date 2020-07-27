using System.Collections.Generic;
using System.Text.Json;

namespace data
{
    public class DB
    {
           const string nomeDoArquivo = "data.json";

        public static IEnumerable<Evento> LerEventosDoArquivo()
        {
            var conteudoArquivo = System.IO.File.ReadAllText(nomeDoArquivo);

            var lista = JsonSerializer.Deserialize<IEnumerable<Evento>>(conteudoArquivo);

            return lista;
        }

        public static void SalvarEventosNoArquivo(IEnumerable<Evento> novaLista)
        {
            var json = JsonSerializer.Serialize(novaLista);

            System.IO.File.WriteAllText(nomeDoArquivo, json);
        }

    }
}