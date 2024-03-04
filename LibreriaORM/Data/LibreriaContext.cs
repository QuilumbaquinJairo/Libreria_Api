using LibreriaORM.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
        public DbSet<Prestamo> Prestamos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().Property(p => p.Rol)
                .HasConversion<string>();
            modelBuilder.Entity<MaterialBibliografico>().Property(p => p.tipoMaterial)
                .HasConversion<string>();

            modelBuilder.Entity<Libro>().
                HasOne(e => e.MaterialBibliografico)
                .WithOne(e => e.Libro)
                .HasForeignKey<Libro>(l => l.IdMaterialBibliografico)
                .IsRequired();
            modelBuilder.Entity<Tesis>().
                HasOne(e => e.MaterialBibliografico)
                .WithOne(e => e.Tesis)
                .HasForeignKey<Tesis>(e => e.IdMaterialBibliografico)
                .IsRequired();
            modelBuilder.Entity<Revista>().
                HasOne(e => e.MaterialBibliografico)
                .WithOne(e => e.Revista)
                .HasForeignKey<Revista>(e => e.IdMaterialBibliografico)
                .IsRequired();



            //configuracion tabla prestamo
            modelBuilder.Entity<MaterialBibliografico>()
             .HasMany(e => e.Prestamo)
             .WithOne(e => e.MaterialBibliografico)
             .HasForeignKey(e => e.IdMaterialBibliografico)
             .IsRequired();

            modelBuilder.Entity<Persona>()
             .HasMany(e => e.Prestamo)
             .WithOne(e => e.Persona)
             .HasForeignKey(e => e.IdPersona)
             .IsRequired();
            //configuracion clave foranea usuario
            modelBuilder.Entity<Usuario>()
            .HasOne(e => e.Persona)
            .WithOne(e => e.Usuario)
            .HasForeignKey<Usuario>(e => e.IdPersona)
            .IsRequired(true);
            //configuracion clave foranea Administradir
            modelBuilder.Entity<Administrador>()
            .HasOne(e => e.Persona)
            .WithOne(e => e.Administrador)
            .HasForeignKey<Administrador>(e => e.IdPersona)
            .IsRequired(true);

            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Administrador>().ToTable("Administrador");
            modelBuilder.Entity<Libro>().ToTable("Libro");
            modelBuilder.Entity<Tesis>().ToTable("Tesis");
            modelBuilder.Entity<Revista>().ToTable("Revista");
            modelBuilder.Entity<MaterialBibliografico>().ToTable("MaterialBibliografico");
            modelBuilder.Entity<Prestamo>().ToTable("Prestamo");
            base.OnModelCreating(modelBuilder);

        }

    }
}
