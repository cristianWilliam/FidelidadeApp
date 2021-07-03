﻿// <auto-generated />
using System;
using FidelidadeApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FidelidadeApp.Data.Migrations
{
    [DbContext(typeof(FidelidadeAppContext))]
    [Migration("20210702185827_SeedsSqlScript")]
    partial class SeedsSqlScript
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.AuthRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.AuthUsuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CategoriaPaiId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaPaiId");

                    b.ToTable("Categoria", "Produto");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Empresa", "Empresa");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("ValorPontos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produto", "Produto");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.ProdutoCategoria", b =>
                {
                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("char(36)");

                    b.HasKey("ProdutoId", "CategoriaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("ProdutoCategoria", "Produto");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.ProdutoVenda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MovimentacaoId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("char(36)");

                    b.Property<int>("StatusEntrega")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId")
                        .IsUnique();

                    b.ToTable("ProdutoVenda", "Compra");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.UsuarioEndereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Endereco", "Usuario");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.UsuarioExtratoMovimentacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataMovimentacao")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("EmpresaId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ProdutoVendaId")
                        .HasColumnType("char(36)");

                    b.Property<int>("TipoMovimentacao")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("ProdutoVendaId")
                        .IsUnique();

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioMovimentacoes", "Compra");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.UsuarioSaldo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("PontosAtuais")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("UsuarioSaldo", "Compra");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Value")
                        .HasColumnType("varchar(100)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.Categoria", b =>
                {
                    b.HasOne("FidelidadeApp.Domain.Entities.Categoria", "CategoriaPai")
                        .WithMany("CategoriasFilhas")
                        .HasForeignKey("CategoriaPaiId");

                    b.Navigation("CategoriaPai");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.ProdutoCategoria", b =>
                {
                    b.HasOne("FidelidadeApp.Domain.Entities.Categoria", "Categoria")
                        .WithMany("ProdutoCategorias")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FidelidadeApp.Domain.Entities.Produto", "Produto")
                        .WithMany("ProdutoCategorias")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.ProdutoVenda", b =>
                {
                    b.HasOne("FidelidadeApp.Domain.Entities.Produto", "Produto")
                        .WithOne("ProdutoVenda")
                        .HasForeignKey("FidelidadeApp.Domain.Entities.ProdutoVenda", "ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("FidelidadeApp.Core.Models.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("ProdutoVendaId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnType("varchar(100)");

                            b1.Property<string>("Cep")
                                .IsRequired()
                                .HasColumnType("varchar(100)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("varchar(100)");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("varchar(2)");

                            b1.Property<string>("Pais")
                                .IsRequired()
                                .HasColumnType("varchar(100)");

                            b1.Property<string>("Rua")
                                .IsRequired()
                                .HasColumnType("varchar(100)");

                            b1.HasKey("ProdutoVendaId");

                            b1.ToTable("ProdutoVenda");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoVendaId");
                        });

                    b.Navigation("Endereco");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.UsuarioEndereco", b =>
                {
                    b.HasOne("FidelidadeApp.Domain.Entities.AuthUsuario", "Usuario")
                        .WithOne("EnderecoEntrega")
                        .HasForeignKey("FidelidadeApp.Domain.Entities.UsuarioEndereco", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("FidelidadeApp.Core.Models.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("UsuarioEnderecoId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Cep")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("varchar(2)");

                            b1.Property<string>("Pais")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Rua")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("UsuarioEnderecoId");

                            b1.ToTable("Endereco");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioEnderecoId");
                        });

                    b.Navigation("Endereco");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.UsuarioExtratoMovimentacao", b =>
                {
                    b.HasOne("FidelidadeApp.Domain.Entities.Empresa", "Empresa")
                        .WithMany("UsuarioMovimentacoes")
                        .HasForeignKey("EmpresaId");

                    b.HasOne("FidelidadeApp.Domain.Entities.ProdutoVenda", "ProdutoVenda")
                        .WithOne("Movimentacao")
                        .HasForeignKey("FidelidadeApp.Domain.Entities.UsuarioExtratoMovimentacao", "ProdutoVendaId");

                    b.HasOne("FidelidadeApp.Domain.Entities.AuthUsuario", "Usuario")
                        .WithMany("ExtratoMovimentacoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("ProdutoVenda");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.UsuarioSaldo", b =>
                {
                    b.HasOne("FidelidadeApp.Domain.Entities.AuthUsuario", "Usuario")
                        .WithOne("Saldo")
                        .HasForeignKey("FidelidadeApp.Domain.Entities.UsuarioSaldo", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("FidelidadeApp.Domain.Entities.AuthRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("FidelidadeApp.Domain.Entities.AuthUsuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("FidelidadeApp.Domain.Entities.AuthUsuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("FidelidadeApp.Domain.Entities.AuthRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FidelidadeApp.Domain.Entities.AuthUsuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("FidelidadeApp.Domain.Entities.AuthUsuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.AuthUsuario", b =>
                {
                    b.Navigation("EnderecoEntrega");

                    b.Navigation("ExtratoMovimentacoes");

                    b.Navigation("Saldo");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("CategoriasFilhas");

                    b.Navigation("ProdutoCategorias");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.Empresa", b =>
                {
                    b.Navigation("UsuarioMovimentacoes");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.Produto", b =>
                {
                    b.Navigation("ProdutoCategorias");

                    b.Navigation("ProdutoVenda");
                });

            modelBuilder.Entity("FidelidadeApp.Domain.Entities.ProdutoVenda", b =>
                {
                    b.Navigation("Movimentacao");
                });
#pragma warning restore 612, 618
        }
    }
}
