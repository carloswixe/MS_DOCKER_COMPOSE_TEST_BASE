﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DataAccesLayer.Data;

#nullable disable

namespace NET_TEST_BASE.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240919061622_RemoveColumns")]
    partial class RemoveColumns
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NET_TEST_BASE.Models.Beneficiario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Beneficiario");
                });

            modelBuilder.Entity("NET_TEST_BASE.Models.Bitacora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Accion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detalles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Entidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bitacoras");
                });

            modelBuilder.Entity("NET_TEST_BASE.Models.Ordenante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ordenante");
                });

            modelBuilder.Entity("NET_TEST_BASE.Models.Pago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BeneficiarioId")
                        .HasColumnType("int");

                    b.Property<int>("CantidadProductos")
                        .HasColumnType("int");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MontoTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrdenanteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BeneficiarioId");

                    b.HasIndex("OrdenanteId");

                    b.ToTable("Pagos");

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("NET_TEST_BASE.Models.Pago", b =>
                {
                    b.HasOne("NET_TEST_BASE.Models.Beneficiario", "AQuienSeLePaga")
                        .WithMany("Pagos")
                        .HasForeignKey("BeneficiarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NET_TEST_BASE.Models.Ordenante", "QuienRealizaPago")
                        .WithMany("Pagos")
                        .HasForeignKey("OrdenanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AQuienSeLePaga");

                    b.Navigation("QuienRealizaPago");
                });

            modelBuilder.Entity("NET_TEST_BASE.Models.Beneficiario", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("NET_TEST_BASE.Models.Ordenante", b =>
                {
                    b.Navigation("Pagos");
                });
#pragma warning restore 612, 618
        }
    }
}
