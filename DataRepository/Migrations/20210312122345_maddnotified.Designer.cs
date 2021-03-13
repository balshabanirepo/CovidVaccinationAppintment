﻿// <auto-generated />
using System;
using DataRepository.GateWay;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataRepository.Migrations
{
    [DbContext(typeof(DbConext))]
    [Migration("20210312122345_maddnotified")]
    partial class maddnotified
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataRepository.RegistrarsRepository", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Notified")
                        .HasColumnType("bit");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Registrars");
                });

            modelBuilder.Entity("DataRepository.SystemSettingsRepository", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("NotificationType")
                        .HasColumnType("tinyint");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SystemSettings");
                });

            modelBuilder.Entity("DataRepository.VaccinationReservationRepository", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RegistrarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Taken")
                        .HasColumnType("bit");

                    b.Property<int>("VaccinationTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegistrarId");

                    b.HasIndex("VaccinationTypeId");

                    b.ToTable("VaccinationReservation");
                });

            modelBuilder.Entity("DataRepository.VaccinationTypesRepository", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VaccinationTypes");
                });

            modelBuilder.Entity("DataRepository.VaccinationReservationRepository", b =>
                {
                    b.HasOne("DataRepository.RegistrarsRepository", "Registrar")
                        .WithMany()
                        .HasForeignKey("RegistrarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataRepository.VaccinationTypesRepository", "VaccinationType")
                        .WithMany("VaccinationReservations")
                        .HasForeignKey("VaccinationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Registrar");

                    b.Navigation("VaccinationType");
                });

            modelBuilder.Entity("DataRepository.VaccinationTypesRepository", b =>
                {
                    b.Navigation("VaccinationReservations");
                });
#pragma warning restore 612, 618
        }
    }
}
