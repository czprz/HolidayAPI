﻿// <auto-generated />
using System;
using HolidayAPI.Storage.Rational;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HolidayAPI.Storage.Rational.Migrations
{
    [DbContext(typeof(HolidayContext))]
    partial class HolidayContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("HolidayAPI.Storage.Rational.Models.CountryDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("HolidayAPI.Storage.Rational.Models.HolidayCountryDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("HolidayDbId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("HolidayDbId");

                    b.ToTable("Methods");
                });

            modelBuilder.Entity("HolidayAPI.Storage.Rational.Models.HolidayDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("End")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Holidays");
                });

            modelBuilder.Entity("HolidayAPI.Storage.Rational.Models.RegionDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("HolidayCountryDbId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("HolidayCountryDbId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("HolidayAPI.Storage.Rational.Models.HolidayCountryDb", b =>
                {
                    b.HasOne("HolidayAPI.Storage.Rational.Models.CountryDb", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HolidayAPI.Storage.Rational.Models.HolidayDb", null)
                        .WithMany("Countries")
                        .HasForeignKey("HolidayDbId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("HolidayAPI.Storage.Rational.Models.RegionDb", b =>
                {
                    b.HasOne("HolidayAPI.Storage.Rational.Models.CountryDb", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HolidayAPI.Storage.Rational.Models.HolidayCountryDb", null)
                        .WithMany("Regions")
                        .HasForeignKey("HolidayCountryDbId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("HolidayAPI.Storage.Rational.Models.HolidayCountryDb", b =>
                {
                    b.Navigation("Regions");
                });

            modelBuilder.Entity("HolidayAPI.Storage.Rational.Models.HolidayDb", b =>
                {
                    b.Navigation("Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
