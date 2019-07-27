﻿// <auto-generated />
using System;
using LiveLarn.Service.Lookup.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LiveLarn.Service.Lookup.Migrations
{
    [DbContext(typeof(LookupDbContext))]
    [Migration("20190707155849_Initial Create")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("LiveLarn.Service.Lookup.Models.Entity.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<long?>("CountryId");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<bool>("IsActive");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("LiveLarn.Service.Lookup.Models.Entity.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<bool>("IsActive");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("LiveLarn.Service.Lookup.Models.Entity.District", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CityId");

                    b.Property<string>("Code");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<bool>("IsActive");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("LiveLarn.Service.Lookup.Models.Entity.City", b =>
                {
                    b.HasOne("LiveLarn.Service.Lookup.Models.Entity.Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("LiveLarn.Service.Lookup.Models.Entity.District", b =>
                {
                    b.HasOne("LiveLarn.Service.Lookup.Models.Entity.City")
                        .WithMany("Districts")
                        .HasForeignKey("CityId");
                });
#pragma warning restore 612, 618
        }
    }
}
