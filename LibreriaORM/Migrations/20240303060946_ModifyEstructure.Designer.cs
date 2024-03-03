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
    [Migration("20240303060946_ModifyEstructure")]
    partial class ModifyEstructure
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.ToTable("Usuario", (string)null);
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
