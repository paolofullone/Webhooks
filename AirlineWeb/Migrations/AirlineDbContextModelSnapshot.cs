﻿// <auto-generated />
using AirlineWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirlineWeb.Migrations
{
    [DbContext(typeof(AirlineDbContext))]
    partial class AirlineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirlineWeb.Models.FlightDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FlightCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.ToTable("FlightDetails");
                });

            modelBuilder.Entity("AirlineWeb.Models.WebhookSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Secret")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebhookPublisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebhookType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebhookUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WebhookSubscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
