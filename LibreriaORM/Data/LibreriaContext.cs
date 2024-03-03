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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().Property(p => p.Rol)
                .HasConversion<string>();

            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Administrador>().ToTable("Administrador");

        }

    }
}
