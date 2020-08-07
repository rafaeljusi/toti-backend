using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;


namespace data
{
    public class DB : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=toti;Trusted_Connection=True;");
        }

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