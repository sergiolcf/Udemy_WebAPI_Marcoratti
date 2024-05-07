﻿// <auto-generated />
using System;
using ApiExecUm.Context.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiExecUm.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240506230503_atualizacaoOnModelCreate")]
    partial class atualizacaoOnModelCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ApiExecUm.Model.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("ContatoPrimarioId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.HasIndex("ContatoPrimarioId");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("ApiExecUm.Model.Contato", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("varchar(180)");

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("varchar(180)");

                    b.HasKey("Id");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("ApiExecUm.Model.Conta", b =>
                {
                    b.HasOne("ApiExecUm.Model.Contato", "ContatoPrimario")
                        .WithMany()
                        .HasForeignKey("ContatoPrimarioId");

                    b.OwnsOne("ApiExecUm.Model.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("ContaId")
                                .HasColumnType("int");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasMaxLength(14)
                                .HasColumnType("varchar(14)");

                            b1.Property<string>("Complemento")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("varchar(150)");

                            b1.Property<string>("Nome")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)");

                            b1.Property<int>("Numero")
                                .HasColumnType("int");

                            b1.HasKey("ContaId");

                            b1.ToTable("Contas");

                            b1.WithOwner()
                                .HasForeignKey("ContaId");
                        });

                    b.Navigation("ContatoPrimario");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("ApiExecUm.Model.Contato", b =>
                {
                    b.HasOne("ApiExecUm.Model.Conta", "Empresa")
                        .WithMany("ContatoList")
                        .HasForeignKey("Id");

                    b.OwnsOne("ApiExecUm.Model.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("ContatoId")
                                .HasColumnType("int");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasMaxLength(14)
                                .HasColumnType("varchar(14)");

                            b1.Property<string>("Complemento")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("varchar(150)");

                            b1.Property<string>("Nome")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)");

                            b1.Property<int>("Numero")
                                .HasColumnType("int");

                            b1.HasKey("ContatoId");

                            b1.ToTable("Contatos");

                            b1.WithOwner()
                                .HasForeignKey("ContatoId");
                        });

                    b.Navigation("Empresa");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("ApiExecUm.Model.Conta", b =>
                {
                    b.Navigation("ContatoList");
                });
#pragma warning restore 612, 618
        }
    }
}
