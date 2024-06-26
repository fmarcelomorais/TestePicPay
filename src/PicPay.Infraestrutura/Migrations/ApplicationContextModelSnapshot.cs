﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PicPay.Infraestrutura.Context;

#nullable disable

namespace PicPay.Infraestrutura.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PicPay.Domain.Models.Conta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NumeroConta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Saldo")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Contas", (string)null);
                });

            modelBuilder.Entity("PicPay.Domain.Models.Transacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataTransacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("NumeroTransacao")
                        .HasColumnType("VARCHAR(32)");

                    b.Property<bool>("StatusTransacao")
                        .HasColumnType("BIT");

                    b.Property<Guid>("UsuarioEnviaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioRecebeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ValorTransacao")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioEnviaId");

                    b.HasIndex("UsuarioRecebeId");

                    b.ToTable("Transacoes", (string)null);
                });

            modelBuilder.Entity("PicPay.Domain.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("PicPay.Domain.Models.Conta", b =>
                {
                    b.HasOne("PicPay.Domain.Models.Usuario", "Usuario")
                        .WithOne("Conta")
                        .HasForeignKey("PicPay.Domain.Models.Conta", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PicPay.Domain.Models.Transacao", b =>
                {
                    b.HasOne("PicPay.Domain.Models.Usuario", "UsuarioEnvia")
                        .WithMany("Transacoes")
                        .HasForeignKey("UsuarioEnviaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PicPay.Domain.Models.Usuario", "UsuarioRecebe")
                        .WithMany()
                        .HasForeignKey("UsuarioRecebeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioEnvia");

                    b.Navigation("UsuarioRecebe");
                });

            modelBuilder.Entity("PicPay.Domain.Models.Usuario", b =>
                {
                    b.Navigation("Conta")
                        .IsRequired();

                    b.Navigation("Transacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
