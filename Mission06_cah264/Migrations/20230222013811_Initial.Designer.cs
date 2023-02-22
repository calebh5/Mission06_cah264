﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission06_cah264.Models;

namespace Mission06_cah264.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20230222013811_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("Mission06_cah264.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Sci-fi/Adventure"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Comedy"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "War/Drama"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Action"
                        },
                        new
                        {
                            CategoryID = 5,
                            CategoryName = "Boring"
                        });
                });

            modelBuilder.Entity("Mission06_cah264.Models.FormResponse", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LentTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieID");

                    b.HasIndex("CategoryID");

                    b.ToTable("responses");

                    b.HasData(
                        new
                        {
                            MovieID = 1,
                            CategoryID = 1,
                            Director = "Christopher Nolan",
                            Edited = false,
                            Rating = "PG13",
                            Title = "Interstellar",
                            Year = (short)2014
                        },
                        new
                        {
                            MovieID = 2,
                            CategoryID = 2,
                            Director = "Jared Hess",
                            Edited = false,
                            Rating = "PG",
                            Title = "Napoleon Dynamite",
                            Year = (short)2004
                        },
                        new
                        {
                            MovieID = 3,
                            CategoryID = 3,
                            Director = "Mel Gibson",
                            Edited = false,
                            Rating = "R",
                            Title = "Hacksaw Ridge",
                            Year = (short)2016
                        });
                });

            modelBuilder.Entity("Mission06_cah264.Models.FormResponse", b =>
                {
                    b.HasOne("Mission06_cah264.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}