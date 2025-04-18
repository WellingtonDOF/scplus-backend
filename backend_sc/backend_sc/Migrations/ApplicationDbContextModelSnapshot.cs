﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend_sc.DataContext;

#nullable disable

namespace backend_sc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("backend_sc.Models.PermissaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TipoPermissao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Permissoes");
                });

            modelBuilder.Entity("backend_sc.Models.PessoaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("PermissaoId")
                        .HasColumnType("int");

                    b.Property<string>("SenhaHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(22)
                        .HasColumnType("varchar(22)");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("PermissaoId");

                    b.ToTable("Pessoas");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("backend_sc.Models.AlunoModel", b =>
                {
                    b.HasBaseType("backend_sc.Models.PessoaModel");

                    b.Property<string>("CategoriaCnh")
                        .IsRequired()
                        .HasMaxLength(22)
                        .HasColumnType("varchar(22)");

                    b.Property<bool>("StatusCurso")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("StatusPagamento")
                        .HasColumnType("int");

                    b.ToTable("Alunos", (string)null);
                });

            modelBuilder.Entity("backend_sc.Models.InstrutorModel", b =>
                {
                    b.HasBaseType("backend_sc.Models.PessoaModel");

                    b.Property<string>("CategoriaCnh")
                        .IsRequired()
                        .HasMaxLength(22)
                        .HasColumnType("varchar(22)");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("datetime(6)");

                    b.ToTable("Instrutores", (string)null);
                });

            modelBuilder.Entity("backend_sc.Models.PessoaModel", b =>
                {
                    b.HasOne("backend_sc.Models.PermissaoModel", "Permissao")
                        .WithMany()
                        .HasForeignKey("PermissaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permissao");
                });

            modelBuilder.Entity("backend_sc.Models.AlunoModel", b =>
                {
                    b.HasOne("backend_sc.Models.PessoaModel", null)
                        .WithOne()
                        .HasForeignKey("backend_sc.Models.AlunoModel", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backend_sc.Models.InstrutorModel", b =>
                {
                    b.HasOne("backend_sc.Models.PessoaModel", null)
                        .WithOne()
                        .HasForeignKey("backend_sc.Models.InstrutorModel", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
