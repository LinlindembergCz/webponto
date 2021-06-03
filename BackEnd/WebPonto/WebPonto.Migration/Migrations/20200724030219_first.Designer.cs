﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebPonto.Infra.Data.Context;

namespace WebPonto.Infra.Data.Configuration.Migrations
{
    [DbContext(typeof(ExampleContext))]
    [Migration("20200724030219_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PGC.Charge.Domain.Aggregates.ExampleAggregate.Example", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Example","dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Example 1"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Example 2"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Example 3"
                        });
                });

            modelBuilder.Entity("PGC.Charge.Domain.Aggregates.PersonAggregate.Person", b =>
                {
                    b.Property<int>("BusinessEntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BusinessEntityID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.HasKey("BusinessEntityID");

                    b.ToTable("Person","dbo");

                    b.HasData(
                        new
                        {
                            BusinessEntityID = 1,
                            Name = "User One"
                        });
                });

            modelBuilder.Entity("PGC.Charge.Domain.Aggregates.PersonAggregate.PersonPhone", b =>
                {
                    b.Property<int>("BusinessEntityID")
                        .HasColumnName("BusinessEntityID");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("PhoneNumber");

                    b.Property<int>("PhoneNumberTypeID")
                        .HasColumnName("PhoneNumberTypeID");

                    b.HasKey("BusinessEntityID", "PhoneNumber", "PhoneNumberTypeID");

                    b.HasIndex("PhoneNumberTypeID");

                    b.ToTable("PersonPhone","dbo");

                    b.HasData(
                        new
                        {
                            BusinessEntityID = 1,
                            PhoneNumber = "(19)99999-2883",
                            PhoneNumberTypeID = 1
                        },
                        new
                        {
                            BusinessEntityID = 1,
                            PhoneNumber = "(19)99999-4021",
                            PhoneNumberTypeID = 2
                        });
                });

            modelBuilder.Entity("PGC.Charge.Domain.Aggregates.PersonAggregate.PhoneNumberType", b =>
                {
                    b.Property<int>("PhoneNumberTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BusinessEntityID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.HasKey("PhoneNumberTypeID");

                    b.ToTable("PhoneNumberType","dbo");

                    b.HasData(
                        new
                        {
                            PhoneNumberTypeID = 1,
                            Name = "Local phone"
                        },
                        new
                        {
                            PhoneNumberTypeID = 2,
                            Name = "Cellphone"
                        });
                });

            modelBuilder.Entity("PGC.Charge.Domain.Aggregates.PersonAggregate.PersonPhone", b =>
                {
                    b.HasOne("PGC.Charge.Domain.Aggregates.PersonAggregate.Person", "Person")
                        .WithMany("Phones")
                        .HasForeignKey("BusinessEntityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PGC.Charge.Domain.Aggregates.PersonAggregate.PhoneNumberType", "PhoneNumberType")
                        .WithMany()
                        .HasForeignKey("PhoneNumberTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
