using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School.API.models;

namespace School.API.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options){ }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuarios");

            entity.HasKey(u => u.Id);

            entity.Property(u => u.Nome).IsRequired().HasMaxLength(50);
            entity.Property(u => u.Sobrenome).IsRequired().HasMaxLength(50);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(200);
            entity.Property(u => u.DataNascimento).IsRequired();
            entity.Property(u => u.Escolaridade).IsRequired();
        });

        modelBuilder.Entity<Usuario>().HasData(
            new Usuario(1, "Hytalo", "Pinheiro", "is.oscar@example.com", DateTime.ParseExact("23/01/1997", "dd/MM/yyyy", CultureInfo.InvariantCulture), 1),
            new Usuario(2, "Maria", "Francisca", "maria.francisca@example.com", DateTime.ParseExact("15/05/1962", "dd/MM/yyyy", CultureInfo.InvariantCulture), 1)
            );

    }
    }
}