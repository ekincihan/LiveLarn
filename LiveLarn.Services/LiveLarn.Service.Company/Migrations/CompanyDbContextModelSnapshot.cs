﻿// <auto-generated />
using System;
using LiveLarn.Service.Company.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LiveLarn.Service.Company.Migrations
{
    [DbContext(typeof(CompanyDbContext))]
    partial class CompanyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("LiveLarn.Service.Company.Model.Entity.Branch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1")
                        .HasMaxLength(250);

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(250);

                    b.Property<int>("CityId");

                    b.Property<string>("Code")
                        .HasMaxLength(4);

                    b.Property<long?>("CompanyId");

                    b.Property<int>("CountryId");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<int>("DistrictId");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Mail")
                        .HasMaxLength(150);

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .HasMaxLength(150);

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("LiveLarn.Service.Company.Model.Entity.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateDate");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<bool>("IsActive");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("LiveLarn.Service.Company.Model.Entity.Branch", b =>
                {
                    b.HasOne("LiveLarn.Service.Company.Model.Entity.Company")
                        .WithMany("Branches")
                        .HasForeignKey("CompanyId");
                });
#pragma warning restore 612, 618
        }
    }
}
