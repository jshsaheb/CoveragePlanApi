﻿// <auto-generated />
using System;
using CoveragePlanApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoveragePlanApi.Migrations
{
    [DbContext(typeof(CoveragePlanDBContext))]
    partial class CoveragePlanDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoveragePlanApi.Models.Contracts", b =>
                {
                    b.Property<int>("customerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("coveragePlan")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("customerAddress")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("customerCountry")
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("customerDateofBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("customerGender")
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("customerName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("netPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("saleDate")
                        .HasColumnType("datetime");

                    b.HasKey("customerId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("CoveragePlanApi.Models.CoveragePlan", b =>
                {
                    b.Property<int>("coveragePlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EligibilityCountry")
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("EligibilityDateFrom")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("EligibilityDateTo")
                        .HasColumnType("datetime");

                    b.Property<string>("coveragePlan")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("coveragePlanId");

                    b.ToTable("coveragePlans");
                });

            modelBuilder.Entity("CoveragePlanApi.Models.RateChart", b =>
                {
                    b.Property<int>("rateChartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerAge")
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("coveragePlan")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("customerGender")
                        .HasColumnType("nvarchar(1)");

                    b.Property<double>("netPrice")
                        .HasColumnType("float");

                    b.HasKey("rateChartId");

                    b.ToTable("rateCharts");
                });
#pragma warning restore 612, 618
        }
    }
}
