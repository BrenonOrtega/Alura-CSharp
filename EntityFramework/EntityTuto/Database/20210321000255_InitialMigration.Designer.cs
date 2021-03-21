﻿// <auto-generated />
using System;
using EntityAccessData.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityASP.Migrations
{
    [DbContext(typeof(PeopleContext))]
    [Migration("20210321000255_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("EntityAccessedData.Models.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetAdress")
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EntityAccessedData.Models.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("EntityAccessedData.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Age")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("EntityAccessedData.Models.Adress", b =>
                {
                    b.HasOne("EntityAccessedData.Models.Person", null)
                        .WithMany("Adresses")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("EntityAccessedData.Models.Email", b =>
                {
                    b.HasOne("EntityAccessedData.Models.Person", null)
                        .WithMany("Emails")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("EntityAccessedData.Models.Person", b =>
                {
                    b.Navigation("Adresses");

                    b.Navigation("Emails");
                });
#pragma warning restore 612, 618
        }
    }
}
