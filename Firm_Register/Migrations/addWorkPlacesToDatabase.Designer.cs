﻿// <auto-generated />
using System;
using Firm_Register.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Firm_Register.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220317123151_addWorkPlacesToDatabase")]
    partial class addWorkPlacesToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Firm_Register.Data.Males", b =>
                {
                    b.Property<int>("Male_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Male_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Male_Id");

                    b.ToTable("Males");
                });

            modelBuilder.Entity("Firm_Register.Models.Family", b =>
                {
                    b.Property<int>("Family_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Family_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Family_Id");

                    b.ToTable("Family");
                });

            modelBuilder.Entity("Firm_Register.Models.Females", b =>
                {
                    b.Property<int>("Female_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Female_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Female_Id");

                    b.ToTable("Females");
                });

            modelBuilder.Entity("Firm_Register.Models.Firms", b =>
                {
                    b.Property<int>("Firm_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capital")
                        .HasColumnType("int");

                    b.Property<string>("EIK")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firm_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Found_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Region_Id")
                        .HasColumnType("int");

                    b.HasKey("Firm_ID");

                    b.HasIndex("Region_Id");

                    b.ToTable("Firms");
                });

            modelBuilder.Entity("Firm_Register.Models.People", b =>
                {
                    b.Property<int>("Person_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Person_EGN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Person_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Person_First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Person_Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Person_Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Person_Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Firm_Register.Models.Regions", b =>
                {
                    b.Property<int>("Region_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Region_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Region_Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Firm_Register.Models.Roles", b =>
                {
                    b.Property<int>("Role_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Role_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Role_Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Firm_Register.Models.WorkPlace", b =>
                {
                    b.Property<int>("Person_Id")
                        .HasColumnType("int");

                    b.Property<int>("Firm_Id")
                        .HasColumnType("int");

                    b.HasKey("Person_Id", "Firm_Id");

                    b.HasIndex("Firm_Id");

                    b.ToTable("WorkPlaces");
                });

            modelBuilder.Entity("Firm_Register.Models.Firms", b =>
                {
                    b.HasOne("Firm_Register.Models.Regions", "Region")
                        .WithMany()
                        .HasForeignKey("Region_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Firm_Register.Models.WorkPlace", b =>
                {
                    b.HasOne("Firm_Register.Models.Firms", "Firm")
                        .WithMany()
                        .HasForeignKey("Firm_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Firm_Register.Models.People", "Person")
                        .WithMany()
                        .HasForeignKey("Person_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Firm");

                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
