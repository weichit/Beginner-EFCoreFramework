﻿// <auto-generated />
using System;
using EFAssessment.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFAssessment.Migrations
{
    [DbContext(typeof(AppointmentDb))]
    partial class AppointmentDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Appointment_Db")
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EFAssessment.Entities.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsReversed")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Doctors", "Appointment_Db");
                });

            modelBuilder.Entity("EFAssessment.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ReversedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("SlotId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Patients", "Appointment_Db");
                });
#pragma warning restore 612, 618
        }
    }
}
