﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NikosPizza.Infraestructure;

#nullable disable

namespace NikosPizza.Infraestructure.Migrations
{
    [DbContext(typeof(PizzaDbContext))]
    [Migration("20241114031057_initial1.2")]
    partial class initial12
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("pizza")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NikosPizza.core.Entities.Pizza", b =>
                {
                    b.Property<Guid>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<Guid?>("TamanioPizzaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("PizzaId");

                    b.HasIndex("TamanioPizzaId");

                    b.ToTable("Pizzas", "pizza");
                });

            modelBuilder.Entity("NikosPizza.core.Entities.TamanioPizza", b =>
                {
                    b.Property<Guid>("TamanioPizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("TamanioPizzaId");

                    b.ToTable("TamanioPizzas", "pizza");
                });

            modelBuilder.Entity("NikosPizza.core.Entities.Pizza", b =>
                {
                    b.HasOne("NikosPizza.core.Entities.TamanioPizza", "TamanioPizza")
                        .WithMany()
                        .HasForeignKey("TamanioPizzaId");

                    b.Navigation("TamanioPizza");
                });
#pragma warning restore 612, 618
        }
    }
}
