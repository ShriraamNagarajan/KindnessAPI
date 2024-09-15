﻿// <auto-generated />
using System;
using KindnessAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KindnessAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240915232113_AddActTable")]
    partial class AddActTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KindnessAPI.Models.Act", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImpactType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LocationType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TimeRequired")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Acts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Action = "Hold the door open for someone",
                            CreatedAt = new DateTime(2024, 9, 15, 23, 21, 13, 51, DateTimeKind.Utc).AddTicks(9857),
                            Difficulty = "Simple",
                            ImpactType = "Personal",
                            LocationType = "Local",
                            TimeRequired = "Quick"
                        },
                        new
                        {
                            Id = 2,
                            Action = "Donate to a local charity",
                            CreatedAt = new DateTime(2024, 9, 15, 23, 21, 13, 51, DateTimeKind.Utc).AddTicks(9860),
                            Difficulty = "Moderate",
                            ImpactType = "Community",
                            LocationType = "Local",
                            TimeRequired = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            Action = "Plant a tree",
                            CreatedAt = new DateTime(2024, 9, 15, 23, 21, 13, 51, DateTimeKind.Utc).AddTicks(9862),
                            Difficulty = "Challenging",
                            ImpactType = "Environmental",
                            LocationType = "Local",
                            TimeRequired = "Long"
                        },
                        new
                        {
                            Id = 4,
                            Action = "Leave a positive review for a local business",
                            CreatedAt = new DateTime(2024, 9, 15, 23, 21, 13, 51, DateTimeKind.Utc).AddTicks(9864),
                            Difficulty = "Simple",
                            ImpactType = "Community",
                            LocationType = "Virtual",
                            TimeRequired = "Quick"
                        },
                        new
                        {
                            Id = 5,
                            Action = "Send a thank you note to a friend",
                            CreatedAt = new DateTime(2024, 9, 15, 23, 21, 13, 51, DateTimeKind.Utc).AddTicks(9865),
                            Difficulty = "Simple",
                            ImpactType = "Personal",
                            LocationType = "Virtual",
                            TimeRequired = "Quick"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
