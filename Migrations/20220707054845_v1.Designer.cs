﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Tarea6.Migrations
{
    [DbContext(typeof(CovidContext))]
    [Migration("20220707054845_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("Persona", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("cedula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Proceso", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("Personaid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Provinciaid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Vacunasid")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("Personaid");

                    b.HasIndex("Provinciaid");

                    b.HasIndex("Vacunasid");

                    b.ToTable("PacienteVacunas");
                });

            modelBuilder.Entity("Provincias", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Provincias");
                });

            modelBuilder.Entity("Vacunas", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Vacunas");
                });

            modelBuilder.Entity("Proceso", b =>
                {
                    b.HasOne("Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("Personaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Provincias", "Provincia")
                        .WithMany()
                        .HasForeignKey("Provinciaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vacunas", "Vacunas")
                        .WithMany()
                        .HasForeignKey("Vacunasid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");

                    b.Navigation("Provincia");

                    b.Navigation("Vacunas");
                });
#pragma warning restore 612, 618
        }
    }
}
