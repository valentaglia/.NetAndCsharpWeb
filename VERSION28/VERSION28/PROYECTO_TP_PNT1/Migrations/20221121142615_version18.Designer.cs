﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PROYECTO_TP_PNT1.Context;

namespace PROYECTO_TP_PNT1.Migrations
{
    [DbContext(typeof(ReservaDatabaseContext))]
    [Migration("20221121142615_version18")]
    partial class version18
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PROYECTO_TP_PNT1.Models.Alojamiento", b =>
                {
                    b.Property<int>("idAlojamiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cantHabitacionesDisponibles")
                        .HasColumnType("int");

                    b.Property<int>("capacidadHabitaciones")
                        .HasColumnType("int");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("precio")
                        .HasColumnType("float");

                    b.Property<double>("precioDesayuno")
                        .HasColumnType("float");

                    b.Property<int>("tipo")
                        .HasColumnType("int");

                    b.HasKey("idAlojamiento");

                    b.ToTable("Alojamientos");
                });

            modelBuilder.Entity("PROYECTO_TP_PNT1.Models.Cliente", b =>
                {
                    b.Property<int>("idCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PROYECTO_TP_PNT1.Models.Reserva", b =>
                {
                    b.Property<int>("idReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantHabitaciones")
                        .HasColumnType("int");

                    b.Property<int?>("alojamientoidAlojamiento")
                        .HasColumnType("int");

                    b.Property<int>("cantPersonas")
                        .HasColumnType("int");

                    b.Property<int?>("clienteidCliente")
                        .HasColumnType("int");

                    b.Property<bool>("confirmado")
                        .HasColumnType("bit");

                    b.Property<bool>("desayuno")
                        .HasColumnType("bit");

                    b.Property<DateTime>("entrada")
                        .HasColumnType("datetime2");

                    b.Property<int?>("idAlojamiento")
                        .HasColumnType("int");

                    b.Property<int?>("idCliente")
                        .HasColumnType("int");

                    b.Property<double>("precioTotal")
                        .HasColumnType("float");

                    b.Property<DateTime>("salida")
                        .HasColumnType("datetime2");

                    b.HasKey("idReserva");

                    b.HasIndex("alojamientoidAlojamiento");

                    b.HasIndex("clienteidCliente");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("PROYECTO_TP_PNT1.Models.Reserva", b =>
                {
                    b.HasOne("PROYECTO_TP_PNT1.Models.Alojamiento", "alojamiento")
                        .WithMany()
                        .HasForeignKey("alojamientoidAlojamiento");

                    b.HasOne("PROYECTO_TP_PNT1.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteidCliente");
                });
#pragma warning restore 612, 618
        }
    }
}
