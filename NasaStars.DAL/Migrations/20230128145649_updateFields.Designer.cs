﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NasaStars.DAL;

#nullable disable

namespace NasaStars.DAL.Migrations
{
    [DbContext(typeof(NasaStarsContext))]
    [Migration("20230128145649_updateFields")]
    partial class updateFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NasaStars.DAL.Models.Star", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ComputedRegionCbhkFwbd")
                        .HasColumnType("int");

                    b.Property<int>("ComputedRegionNnqa")
                        .HasColumnType("int");

                    b.Property<string>("Fall")
                        .HasPrecision(14, 6)
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Mass")
                        .HasPrecision(14, 6)
                        .HasColumnType("decimal(14,6)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nametype")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recclass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Reclat")
                        .HasPrecision(14, 6)
                        .HasColumnType("decimal(14,6)");

                    b.Property<decimal>("Reclong")
                        .HasPrecision(14, 6)
                        .HasColumnType("decimal(14,6)");

                    b.Property<DateTime?>("Year")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Stars");
                });
#pragma warning restore 612, 618
        }
    }
}