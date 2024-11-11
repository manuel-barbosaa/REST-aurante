﻿// <auto-generated />
using System;
using Cozinha.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace REST_aurante.Cozinha.Migrations
{
    [DbContext(typeof(CozinhaContext))]
    [Migration("20241103212032_UpdatePratoRefeicaopppijuhby")]
    partial class UpdatePratoRefeicaopppijuhby
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Cozinha.Model.Ementa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Frequencia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TipoRefeicaoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TipoRefeicaoId");

                    b.ToTable("Ementas");
                });

            modelBuilder.Entity("Cozinha.Model.Ingrediente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoriaAlimenticia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("PratoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PratoId");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("Cozinha.Model.Prato", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Receita")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("TipoPratoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TipoPratoId");

                    b.ToTable("Pratos");
                });

            modelBuilder.Entity("Cozinha.Model.Refeicao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<long>("PratoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TipoRefeicaoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PratoId");

                    b.HasIndex("TipoRefeicaoId");

                    b.ToTable("Refeicao");
                });

            modelBuilder.Entity("Cozinha.Model.TipoPrato", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TiposPrato");
                });

            modelBuilder.Entity("Cozinha.Model.TipoRefeicao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TipoRefeicao");
                });

            modelBuilder.Entity("Cozinha.Model.Ementa", b =>
                {
                    b.HasOne("Cozinha.Model.TipoRefeicao", "TipoRefeicao")
                        .WithMany()
                        .HasForeignKey("TipoRefeicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoRefeicao");
                });

            modelBuilder.Entity("Cozinha.Model.Ingrediente", b =>
                {
                    b.HasOne("Cozinha.Model.Prato", null)
                        .WithMany("Ingredientes")
                        .HasForeignKey("PratoId");
                });

            modelBuilder.Entity("Cozinha.Model.Prato", b =>
                {
                    b.HasOne("Cozinha.Model.TipoPrato", "TipoPrato")
                        .WithMany()
                        .HasForeignKey("TipoPratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoPrato");
                });

            modelBuilder.Entity("Cozinha.Model.Refeicao", b =>
                {
                    b.HasOne("Cozinha.Model.Prato", "Prato")
                        .WithMany()
                        .HasForeignKey("PratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cozinha.Model.TipoRefeicao", "TipoRefeicao")
                        .WithMany()
                        .HasForeignKey("TipoRefeicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prato");

                    b.Navigation("TipoRefeicao");
                });

            modelBuilder.Entity("Cozinha.Model.Prato", b =>
                {
                    b.Navigation("Ingredientes");
                });
#pragma warning restore 612, 618
        }
    }
}
