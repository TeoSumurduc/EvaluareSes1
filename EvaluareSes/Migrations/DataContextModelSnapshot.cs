﻿// <auto-generated />
using EvaluareSes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EvaluareSes.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EvaluareSes.Models.Autori", b =>
                {
                    b.Property<int>("CodAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodAutor"));

                    b.Property<int>("EdituraCodEditura")
                        .HasColumnType("int");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodAutor");

                    b.HasIndex("EdituraCodEditura");

                    b.ToTable("Autori");
                });

            modelBuilder.Entity("EvaluareSes.Models.AutoriCarti", b =>
                {
                    b.Property<int>("CodCarte")
                        .HasColumnType("int");

                    b.Property<int>("CodAutor")
                        .HasColumnType("int");

                    b.HasKey("CodCarte", "CodAutor");

                    b.HasIndex("CodAutor");

                    b.ToTable("AutoriCarti");
                });

            modelBuilder.Entity("EvaluareSes.Models.Carti", b =>
                {
                    b.Property<int>("CodCarte")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodCarte"));

                    b.Property<string>("Denumire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodCarte");

                    b.ToTable("Carti");
                });

            modelBuilder.Entity("EvaluareSes.Models.Editura", b =>
                {
                    b.Property<int>("CodEditura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodEditura"));

                    b.Property<int>("Denumire")
                        .HasColumnType("int");

                    b.HasKey("CodEditura");

                    b.ToTable("Editura");
                });

            modelBuilder.Entity("EvaluareSes.Models.Autori", b =>
                {
                    b.HasOne("EvaluareSes.Models.Editura", "Editura")
                        .WithMany("Autori")
                        .HasForeignKey("EdituraCodEditura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Editura");
                });

            modelBuilder.Entity("EvaluareSes.Models.AutoriCarti", b =>
                {
                    b.HasOne("EvaluareSes.Models.Autori", "Autori")
                        .WithMany("AutoriCarti")
                        .HasForeignKey("CodAutor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EvaluareSes.Models.Carti", "Carti")
                        .WithMany("AutoriCarti")
                        .HasForeignKey("CodCarte")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autori");

                    b.Navigation("Carti");
                });

            modelBuilder.Entity("EvaluareSes.Models.Autori", b =>
                {
                    b.Navigation("AutoriCarti");
                });

            modelBuilder.Entity("EvaluareSes.Models.Carti", b =>
                {
                    b.Navigation("AutoriCarti");
                });

            modelBuilder.Entity("EvaluareSes.Models.Editura", b =>
                {
                    b.Navigation("Autori");
                });
#pragma warning restore 612, 618
        }
    }
}
