﻿// <auto-generated />
using Artikler.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Artikler.Migrations
{
    [DbContext(typeof(ArtikelContext))]
    [Migration("20200315233014_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Artikler.Entities.Artikel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Forfatter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Overskrift")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tekst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Årstal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Artikler");
                });
#pragma warning restore 612, 618
        }
    }
}
