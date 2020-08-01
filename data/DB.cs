using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace data
{
    public class DB : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        
        public DbSet<TipoEvento> TipoEventos {get ; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=toti;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Evento>()
                .Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsRequired();


            builder.Entity<Evento>()
            .HasOne(e => e.TipoEvento)
            .WithMany()
            .HasForeignKey(e => e.TipoEventoId);

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