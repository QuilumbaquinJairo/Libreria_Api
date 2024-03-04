﻿// <auto-generated />
using System;
using LibreriaORM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibreriaORM.Migrations
{
    [DbContext(typeof(LibreriaContext))]
    [Migration("20240304012710_FixingLibro")]
    partial class FixingLibro
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibreriaORM.Modelo.MaterialBibliografico", b =>
                {
                    b.Property<int>("IdMaterialBibliografico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMaterialBibliografico"));

                    b.Property<int>("anio")
                        .HasColumnType("int");

                    b.Property<string>("autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<string>("tipoMaterial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMaterialBibliografico");

                    b.ToTable("MaterialBibliografico", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("LibreriaORM.Modelo.Persona", b =>
                {
                    b.Property<int>("IdPersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersona"));

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("sancion")
                        .HasColumnType("bit");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPersona");

                    b.ToTable("Persona", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("LibreriaORM.Modelo.Prestamo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("IdMaterialBibliografico")
                        .HasColumnType("int");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<string>("fechaRegreso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fechaSalida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("IdMaterialBibliografico")
                        .IsUnique();

                    b.HasIndex("IdPersona")
                        .IsUnique();

                    b.ToTable("Prestamo", (string)null);
                });

            modelBuilder.Entity("LibreriaORM.Modelo.Libro", b =>
                {
                    b.HasBaseType("LibreriaORM.Modelo.MaterialBibliografico");

                    b.Property<string>("editorialLibro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Libro", (string)null);
                });

            modelBuilder.Entity("LibreriaORM.Modelo.Revista", b =>
                {
                    b.HasBaseType("LibreriaORM.Modelo.MaterialBibliografico");

                    b.Property<string>("EditorialRevista")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Revista", (string)null);
                });

            modelBuilder.Entity("LibreriaORM.Modelo.Tesis", b =>
                {
                    b.HasBaseType("LibreriaORM.Modelo.MaterialBibliografico");

                    b.ToTable("Tesis", (string)null);
                });

            modelBuilder.Entity("LibreriaORM.Modelo.Administrador", b =>
                {
                    b.HasBaseType("LibreriaORM.Modelo.Persona");

                    b.Property<int>("IdAdministrador")
                        .HasColumnType("int");

                    b.Property<int?>("PersonaTempId")
                        .HasColumnType("int");

                    b.Property<string>("privilegios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Administrador", (string)null);
                });

            modelBuilder.Entity("LibreriaORM.Modelo.Usuario", b =>
                {
                    b.HasBaseType("LibreriaORM.Modelo.Persona");

                    b.Property<string>("Facultad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("LibreriaORM.Modelo.Prestamo", b =>
                {
                    b.HasOne("LibreriaORM.Modelo.MaterialBibliografico", "MaterialBibliografico")
                        .WithOne()
                        .HasForeignKey("LibreriaORM.Modelo.Prestamo", "IdMaterialBibliografico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibreriaORM.Modelo.Persona", "Persona")
                        .WithOne()
                        .HasForeignKey("LibreriaORM.Modelo.Prestamo", "IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaterialBibliografico");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("LibreriaORM.Modelo.Libro", b =>
                {
                    b.HasOne("LibreriaORM.Modelo.MaterialBibliografico", "MaterialBibliografico")
                        .WithOne()
                        .HasForeignKey("LibreriaORM.Modelo.Libro", "IdMaterialBibliografico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaterialBibliografico");
                });

            modelBuilder.Entity("LibreriaORM.Modelo.Revista", b =>
                {
                    b.HasOne("LibreriaORM.Modelo.MaterialBibliografico", "MaterialBibliografico")
                        .WithOne()
                        .HasForeignKey("LibreriaORM.Modelo.Revista", "IdMaterialBibliografico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaterialBibliografico");
                });

            modelBuilder.Entity("LibreriaORM.Modelo.Tesis", b =>
                {
                    b.HasOne("LibreriaORM.Modelo.MaterialBibliografico", "MaterialBibliografico")
                        .WithOne()
                        .HasForeignKey("LibreriaORM.Modelo.Tesis", "IdMaterialBibliografico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaterialBibliografico");
                });

            modelBuilder.Entity("LibreriaORM.Modelo.Administrador", b =>
                {
                    b.HasOne("LibreriaORM.Modelo.Persona", "Persona")
                        .WithOne("Administrador")
                        .HasForeignKey("LibreriaORM.Modelo.Administrador", "IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("LibreriaORM.Modelo.Usuario", b =>
                {
                    b.HasOne("LibreriaORM.Modelo.Persona", "Persona")
                        .WithOne("Usuario")
                        .HasForeignKey("LibreriaORM.Modelo.Usuario", "IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("LibreriaORM.Modelo.Persona", b =>
                {
                    b.Navigation("Administrador")
                        .IsRequired();

                    b.Navigation("Usuario")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
