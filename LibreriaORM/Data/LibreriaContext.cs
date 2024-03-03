using LibreriaORM.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibreriaORM.Data
{
    public class LibreriaContext : DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options) { }

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Tesis> Tesis { get; set; }
        public DbSet<Revista> Revista { get; set; }
        public DbSet<MaterialBibliografico> MaterialBibliograficos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().Property(p => p.Rol)
                .HasConversion<string>();
            modelBuilder.Entity<MaterialBibliografico>().Property(p => p.tipoMaterial)
                .HasConversion<string>();

            modelBuilder.Entity<Libro>().HasOne(l => l.MaterialBibliografico).WithOne()
           .HasForeignKey<Libro>(l => l.IdMaterialBibliografico);
            modelBuilder.Entity<Revista>().HasOne(l => l.MaterialBibliografico).WithOne()
           .HasForeignKey<Revista>(l => l.IdMaterialBibliografico);
            modelBuilder.Entity<Tesis>().HasOne(l => l.MaterialBibliografico).WithOne()
           .HasForeignKey<Tesis>(l => l.IdMaterialBibliografico);

            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Administrador>().ToTable("Administrador");
            modelBuilder.Entity<Libro>().ToTable("Libro");
            modelBuilder.Entity<Tesis>().ToTable("Tesis");
            modelBuilder.Entity<Revista>().ToTable("Revista");
            modelBuilder.Entity<MaterialBibliografico>().ToTable("MaterialBibliografico");
            base.OnModelCreating(modelBuilder);

        }

    }
}
