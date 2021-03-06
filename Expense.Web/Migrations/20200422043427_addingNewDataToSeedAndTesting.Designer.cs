﻿// <auto-generated />
using System;
using Expense.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Expense.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200422043427_addingNewDataToSeedAndTesting")]
    partial class addingNewDataToSeedAndTesting
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Expense.Web.Data.Entities.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<int?>("Countryid");

                    b.HasKey("Id");

                    b.HasIndex("Countryid");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Expense.Web.Data.Entities.CountryEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country");

                    b.HasKey("id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Expense.Web.Data.Entities.ExpenseTypeEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Expense")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("ExpenseTypes");
                });

            modelBuilder.Entity("Expense.Web.Data.Entities.TripDetailsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<int?>("ExpenseTypeid");

                    b.Property<string>("PicturePath");

                    b.Property<int?>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseTypeid");

                    b.HasIndex("TripId");

                    b.ToTable("TripDetails");
                });

            modelBuilder.Entity("Expense.Web.Data.Entities.TripEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("UserId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Expense.Web.Data.Entities.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PicturePath");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.ToTable("UserEntity");
                });

            modelBuilder.Entity("Expense.Web.Data.Entities.CityEntity", b =>
                {
                    b.HasOne("Expense.Web.Data.Entities.CountryEntity", "Country")
                        .WithMany("cities")
                        .HasForeignKey("Countryid");
                });

            modelBuilder.Entity("Expense.Web.Data.Entities.TripDetailsEntity", b =>
                {
                    b.HasOne("Expense.Web.Data.Entities.ExpenseTypeEntity", "ExpenseType")
                        .WithMany("tripDetails")
                        .HasForeignKey("ExpenseTypeid");

                    b.HasOne("Expense.Web.Data.Entities.TripEntity", "Trip")
                        .WithMany("TripDetails")
                        .HasForeignKey("TripId");
                });

            modelBuilder.Entity("Expense.Web.Data.Entities.TripEntity", b =>
                {
                    b.HasOne("Expense.Web.Data.Entities.CityEntity", "City")
                        .WithMany("trips")
                        .HasForeignKey("CityId");

                    b.HasOne("Expense.Web.Data.Entities.UserEntity", "User")
                        .WithMany("Trips")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
