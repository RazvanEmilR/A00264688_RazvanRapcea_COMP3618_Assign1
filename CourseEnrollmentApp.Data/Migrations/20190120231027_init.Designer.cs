﻿// <auto-generated />
using System;
using CourseEnrollmentApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseEnrollmentApp.Data.Migrations
{
    [DbContext(typeof(CourseEnrollmentContext))]
    [Migration("20190120231027_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseEnrollmentApp.Domain.Course", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Credits");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CourseEnrollmentApp.Domain.Enrollment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseId");

                    b.Property<double>("Grade");

                    b.Property<string>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("CourseEnrollmentApp.Domain.Student", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CourseEnrollmentApp.Domain.Enrollment", b =>
                {
                    b.HasOne("CourseEnrollmentApp.Domain.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId");

                    b.HasOne("CourseEnrollmentApp.Domain.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId");
                });
#pragma warning restore 612, 618
        }
    }
}
