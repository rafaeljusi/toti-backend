using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace data
{
    public class DB : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<TipoEvento> TipoEventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //ConnectionString - Rafa
            options.UseSqlServer(@"Server=localhost;Database=toti;User Id=sa;Password=SQLServer2019");

            //ConnectionString - Alunos
            //options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=toti;Trusted_Connection=True;");
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
    }
}