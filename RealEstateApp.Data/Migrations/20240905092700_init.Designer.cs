﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstateApp.Data.DbContexts;

#nullable disable

namespace RealEstateApp.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240905092700_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RealEstateApp.Data.DataModels.Entities.PropertyEntity", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyId"));

                    b.Property<DateTime>("Availibility")
                        .HasColumnType("datetime2");

                    b.Property<double?>("BuiltArea")
                        .HasColumnType("float");

                    b.Property<int?>("CarParking")
                        .HasColumnType("int");

                    b.Property<double?>("CarpetArea")
                        .HasColumnType("float");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("CommercialUse")
                        .HasColumnType("int");

                    b.Property<int?>("Floor")
                        .HasColumnType("int");

                    b.Property<bool>("Furnishing")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsGate")
                        .HasColumnType("bit");

                    b.Property<string>("MainEntrance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfBedrooms")
                        .HasColumnType("int");

                    b.Property<double?>("PropertyAge")
                        .HasColumnType("float");

                    b.Property<int>("PropertyType")
                        .HasColumnType("int");

                    b.Property<string>("SpecialFeatures")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TotalFloors")
                        .HasColumnType("int");

                    b.Property<double>("TotalPropertyArea")
                        .HasColumnType("float");

                    b.HasKey("PropertyId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("RealEstateApp.Data.DataModels.Entities.UserEntity", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
