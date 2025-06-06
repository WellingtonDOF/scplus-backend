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

            modelBuilder.Entity("backend_sc.Models.AulaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("TipoAula")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Aula");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "",
                            TipoAula = 0
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "",
                            TipoAula = 1
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "",
                            TipoAula = 2
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "",
                            TipoAula = 3
                        });
                });

            modelBuilder.Entity("backend_sc.Models.MatriculaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaPlano")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("QuantidadeAulaTotal")
                        .HasColumnType("int");

                    b.Property<bool>("StatusMatricula")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Matricula");
                });

            modelBuilder.Entity("backend_sc.Models.PagamentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("FormaPagamento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("StatusPagamento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("ValorTotal")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("backend_sc.Models.ParcelaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal?>("Juros")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal?>("Multa")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("NumeroParcela")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("PagamentoId")
                        .HasColumnType("int");

                    b.Property<string>("StatusParcela")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Valor")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal?>("ValorPago")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("PagamentoId");

                    b.ToTable("Parcelas");
                });

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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TipoPermissao = 1
                        },
                        new
                        {
                            Id = 2,
                            TipoPermissao = 2
                        },
                        new
                        {
                            Id = 3,
                            TipoPermissao = 3
                        });
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

                    b.Property<string>("Senha")
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "00000000000",
                            DataNascimento = new DateTime(2025, 6, 2, 6, 42, 7, 916, DateTimeKind.Local).AddTicks(4162),
                            Email = "Default@sistema.com",
                            Endereco = "RuaDefault",
                            NomeCompleto = "AdminDefault",
                            PermissaoId = 3,
                            Senha = "$2a$11$4KiK3FZZiE0OvwHknw0xqODme3GOxKkj1huH9mekTfvsa/4eixEKG",
                            Status = true,
                            Telefone = "0000000000"
                        });
                });

            modelBuilder.Entity("backend_sc.Models.VeiculoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAquisicao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataFabricacao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("StatusVeiculo")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("backend_sc.Models.AlunoModel", b =>
                {
                    b.HasBaseType("backend_sc.Models.PessoaModel");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

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

            modelBuilder.Entity("backend_sc.Models.MatriculaModel", b =>
                {
                    b.HasOne("backend_sc.Models.AlunoModel", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("backend_sc.Models.PagamentoModel", b =>
                {
                    b.HasOne("backend_sc.Models.AlunoModel", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("backend_sc.Models.ParcelaModel", b =>
                {
                    b.HasOne("backend_sc.Models.PagamentoModel", "Pagamento")
                        .WithMany("Parcelas")
                        .HasForeignKey("PagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pagamento");
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

            modelBuilder.Entity("backend_sc.Models.PagamentoModel", b =>
                {
                    b.Navigation("Parcelas");
                });
#pragma warning restore 612, 618
        }
    }
}
