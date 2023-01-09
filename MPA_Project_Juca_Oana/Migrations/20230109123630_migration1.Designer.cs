﻿// <auto-generated />
using System;
using MPA_Project_Juca_Oana.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MPAProjectJucaOana.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20230109123630_migration1")]
    partial class migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MPA_Project_Juca_Oana.Models.Customers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("MPA_Project_Juca_Oana.Models.Orders", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("CustomersID")
                        .HasColumnType("int");

                    b.Property<int>("StadiumID")
                        .HasColumnType("int");

                    b.Property<int>("StadiumsID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomersID");

                    b.HasIndex("StadiumsID");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("MPA_Project_Juca_Oana.Models.Players", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Players", (string)null);
                });

            modelBuilder.Entity("MPA_Project_Juca_Oana.Models.Stadiums", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.Property<int?>("TeamsID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TeamsID");

                    b.ToTable("Stadiums", (string)null);
                });

            modelBuilder.Entity("MPA_Project_Juca_Oana.Models.Teams", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayersID")
                        .HasColumnType("int");

                    b.Property<int>("TranersID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PlayersID");

                    b.HasIndex("TranersID");

                    b.ToTable("Teams", (string)null);
                });

            modelBuilder.Entity("MPA_Project_Juca_Oana.Models.Trainers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Trainers", (string)null);
                });

            modelBuilder.Entity("MPA_Project_Juca_Oana.Models.Orders", b =>
                {
                    b.HasOne("MPA_Project_Juca_Oana.Models.Customers", "Customers")
                        .WithMany("Orders")
                        .HasForeignKey("CustomersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MPA_Project_Juca_Oana.Models.Stadiums", "Stadiums")
                        .WithMany("Orders")
                        .HasForeignKey("StadiumsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");

                    b.Navigation("Stadiums");
                });

            modelBuilder.Entity("MPA_Project_Juca_Oana.Models.Stadiums", b =>
                {
                    b.HasOne("MPA_Project_Juca_Oana.Models.Teams", "Teams")
                        .WithMany()
                        .HasForeignKey("TeamsID");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("MPA_Project_Juca_Oana.Models.Teams", b =>
                {
                    b.HasOne("MPA_Project_Juca_Oana.Models.Players", "Players")
                        .WithMany()
                        .HasForeignKey("PlayersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MPA_Project_Juca_Oana.Models.Trainers", "Traners")
                        .WithMany()
                        .HasForeignKey("TranersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Players");

                    b.Navigation("Traners");
                });

            modelBuilder.Entity("MPA_Project_Juca_Oana.Models.Customers", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MPA_Project_Juca_Oana.Models.Stadiums", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}