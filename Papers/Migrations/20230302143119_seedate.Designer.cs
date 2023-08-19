﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Papers.Models;

namespace Papers.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20230302143119_seedate")]
    partial class seedate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Papers.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Notepads",
                            Name = "A4 Refill Pad: 80 Sheets",
                            Price = 2m
                        },
                        new
                        {
                            Id = 2,
                            Category = "Files & Folders",
                            Name = "Pukka Black Box File",
                            Price = 4m
                        },
                        new
                        {
                            Id = 3,
                            Category = "Pens & Pencils",
                            Name = "5 Tier Gel Pen Case: Set of 60",
                            Price = 8m
                        },
                        new
                        {
                            Id = 4,
                            Category = "Pens & Pencils",
                            Name = "Colouring Pencils: Pack of 15",
                            Price = 1m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
