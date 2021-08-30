﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectQuestionPaper.Core.Models;

namespace ProjectQuestionPaper.Core.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210828172824_MigrationInit")]
    partial class MigrationInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectQuestionPaper.Core.Models.Admin", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("ProjectQuestionPaper.Core.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("YearId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("YearId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("ProjectQuestionPaper.Core.Models.Semester", b =>
                {
                    b.Property<int>("Sem")
                        .HasColumnType("int");

                    b.HasKey("Sem");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("ProjectQuestionPaper.Core.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SemesterSem")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SemesterSem");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("ProjectQuestionPaper.Core.Models.Year", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("YearNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Years");
                });

            modelBuilder.Entity("ProjectQuestionPaper.Core.Models.File", b =>
                {
                    b.HasOne("ProjectQuestionPaper.Core.Models.Year", "Year")
                        .WithMany()
                        .HasForeignKey("YearId");

                    b.Navigation("Year");
                });

            modelBuilder.Entity("ProjectQuestionPaper.Core.Models.Subject", b =>
                {
                    b.HasOne("ProjectQuestionPaper.Core.Models.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterSem");

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("ProjectQuestionPaper.Core.Models.Year", b =>
                {
                    b.HasOne("ProjectQuestionPaper.Core.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("Subject");
                });
#pragma warning restore 612, 618
        }
    }
}
