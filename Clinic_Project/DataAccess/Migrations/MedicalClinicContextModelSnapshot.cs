﻿// <auto-generated />
using System;
using Clinic_Project.DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clinic_Project.Migrations
{
    [DbContext(typeof(MedicalClinicContext))]
    partial class MedicalClinicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Clinic_Project.Models.DoctorAgg.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Role")
                        .HasColumnType("bit");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Clinic_Project.Models.SkillAgg.Skill", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Clinic_Project.Models.TurnAgg.Turn", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("DoctorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("bit");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Turns");
                });

            modelBuilder.Entity("Clinic_Project.Models.patientAgg.Patient", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Role")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Clinic_Project.Models.DoctorAgg.Doctor", b =>
                {
                    b.HasOne("Clinic_Project.Models.SkillAgg.Skill", "Skill")
                        .WithMany("Doctors")
                        .HasForeignKey("SkillId")
                        .IsRequired()
                        .HasConstraintName("FK_Doctors_Skills");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Clinic_Project.Models.TurnAgg.Turn", b =>
                {
                    b.HasOne("Clinic_Project.Models.DoctorAgg.Doctor", "Doctor")
                        .WithMany("Turns")
                        .HasForeignKey("DoctorId")
                        .IsRequired()
                        .HasConstraintName("FK_Turns_Doctors");

                    b.HasOne("Clinic_Project.Models.patientAgg.Patient", "Patient")
                        .WithMany("Turns")
                        .HasForeignKey("PatientId")
                        .HasConstraintName("FK_Turns_Patients");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Clinic_Project.Models.DoctorAgg.Doctor", b =>
                {
                    b.Navigation("Turns");
                });

            modelBuilder.Entity("Clinic_Project.Models.SkillAgg.Skill", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("Clinic_Project.Models.patientAgg.Patient", b =>
                {
                    b.Navigation("Turns");
                });
#pragma warning restore 612, 618
        }
    }
}
