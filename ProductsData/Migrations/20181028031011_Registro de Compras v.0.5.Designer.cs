﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsData;

namespace TiendaData.Migrations
{
    [DbContext(typeof(TiendaContext))]
    [Migration("20181028031011_Registro de Compras v.0.5")]
    partial class RegistrodeComprasv05
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TiendaData.Models.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cedula");

                    b.Property<string>("Celular");

                    b.Property<string>("Direccion");

                    b.Property<string>("PrimerNombre");

                    b.Property<string>("SegundoNombre");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("TiendaData.Models.Estados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("TiendaData.Models.EstadosPedidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("EstadosPedidos");
                });

            modelBuilder.Entity("TiendaData.Models.Productos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadProducto");

                    b.Property<decimal>("Capacidad");

                    b.Property<string>("Color");

                    b.Property<double>("Costo");

                    b.Property<string>("DescripcionProducto")
                        .IsRequired();

                    b.Property<int>("EstadosId");

                    b.Property<string>("NombreProducto")
                        .IsRequired();

                    b.Property<string>("UrlImagen");

                    b.HasKey("Id");

                    b.HasIndex("EstadosId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("TiendaData.Models.RegistroPedidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadProducto");

                    b.Property<int>("Cedula");

                    b.Property<DateTime>("FechaNovedad");

                    b.Property<int>("IdEstado");

                    b.Property<int>("IdProducto");

                    b.Property<int>("PendientePorPagar");

                    b.Property<int>("TotalPagado");

                    b.Property<int>("ValorTotalCompra");

                    b.HasKey("Id");

                    b.ToTable("RegistroPedidos");
                });

            modelBuilder.Entity("TiendaData.Models.RegistroPedidosDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaNovedad");

                    b.Property<int>("IdRegistroPedido");

                    b.Property<double>("PendientePorPagar");

                    b.Property<double>("TotalPagado");

                    b.HasKey("Id");

                    b.ToTable("RegistroPedidosDetalle");
                });

            modelBuilder.Entity("TiendaData.Models.Productos", b =>
                {
                    b.HasOne("TiendaData.Models.Estados", "Estados")
                        .WithMany()
                        .HasForeignKey("EstadosId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
