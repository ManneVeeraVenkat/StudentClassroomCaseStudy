﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentClassroomCaseStudy.Data;

#nullable disable

namespace StudentClassroomCaseStudy.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231101144214_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentClassroomCaseStudy.Model.AllocateClassroom", b =>
                {
                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int>("ClassroomId")
                        .HasColumnType("int");

                    b.Property<int>("AllocateClassroomId")
                        .HasColumnType("int");

                    b.HasKey("TeacherId", "ClassroomId");

                    b.HasIndex("ClassroomId");

                    b.ToTable("AllocateClassrooms");

                    b.HasData(
                        new
                        {
                            TeacherId = 1,
                            ClassroomId = 1,
                            AllocateClassroomId = 1
                        },
                        new
                        {
                            TeacherId = 2,
                            ClassroomId = 2,
                            AllocateClassroomId = 2
                        });
                });

            modelBuilder.Entity("StudentClassroomCaseStudy.Model.AllocateSubject", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int>("AllocateSubjectId")
                        .HasColumnType("int");

                    b.HasKey("SubjectId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("AllocateSubjects");

                    b.HasData(
                        new
                        {
                            SubjectId = 1,
                            TeacherId = 1,
                            AllocateSubjectId = 1
                        },
                        new
                        {
                            SubjectId = 2,
                            TeacherId = 1,
                            AllocateSubjectId = 2
                        },
                        new
                        {
                            SubjectId = 2,
                            TeacherId = 2,
                            AllocateSubjectId = 3
                        });
                });

            modelBuilder.Entity("StudentClassroomCaseStudy.Model.Classroom", b =>
                {
                    b.Property<int>("ClassroomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassroomId"));

                    b.Property<string>("ClassroomName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassroomId");

                    b.ToTable("Classrooms");

                    b.HasData(
                        new
                        {
                            ClassroomId = 1,
                            ClassroomName = "Class A"
                        },
                        new
                        {
                            ClassroomId = 2,
                            ClassroomName = "Class B"
                        });
                });

            modelBuilder.Entity("StudentClassroomCaseStudy.Model.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("ClassroomId")
                        .HasColumnType("int");

                    b.Property<int>("ContactNo")
                        .HasColumnType("int");

                    b.Property<string>("ContactPerson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassroomId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            Age = 0,
                            ClassroomId = 1,
                            ContactNo = 0,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            StudentId = 2,
                            Age = 0,
                            ClassroomId = 2,
                            ContactNo = 0,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jane",
                            LastName = "Smith"
                        });
                });

            modelBuilder.Entity("StudentClassroomCaseStudy.Model.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            SubjectId = 1,
                            SubjectName = "Math"
                        },
                        new
                        {
                            SubjectId = 2,
                            SubjectName = "Science"
                        });
                });

            modelBuilder.Entity("StudentClassroomCaseStudy.Model.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<int>("ContactNo")
                        .HasColumnType("int");

                    b.Property<string>("EmailAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            TeacherId = 1,
                            ContactNo = 0,
                            FirstName = "Teacher1",
                            LastName = "Smith"
                        },
                        new
                        {
                            TeacherId = 2,
                            ContactNo = 0,
                            FirstName = "Teacher2",
                            LastName = "Doe"
                        });
                });

            modelBuilder.Entity("StudentClassroomCaseStudy.Model.AllocateClassroom", b =>
                {
                    b.HasOne("StudentClassroomCaseStudy.Model.Classroom", "Classroom")
                        .WithMany("AllocateClassrooms")
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentClassroomCaseStudy.Model.Teacher", "Teacher")
                        .WithMany("AllocateClassrooms")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("StudentClassroomCaseStudy.Model.AllocateSubject", b =>
                {
                    b.HasOne("StudentClassroomCaseStudy.Model.Subject", "Subject")
                        .WithMany("AllocateSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentClassroomCaseStudy.Model.Teacher", "Teacher")
                        .WithMany("AllocateSubjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("StudentClassroomCaseStudy.Model.Student", b =>
                {
                    b.HasOne("StudentClassroomCaseStudy.Model.Classroom", "Classroom")
                        .WithMany("Students")
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");
                });

            modelBuilder.Entity("StudentClassroomCaseStudy.Model.Classroom", b =>
                {
                    b.Navigation("AllocateClassrooms");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("StudentClassroomCaseStudy.Model.Subject", b =>
                {
                    b.Navigation("AllocateSubjects");
                });

            modelBuilder.Entity("StudentClassroomCaseStudy.Model.Teacher", b =>
                {
                    b.Navigation("AllocateClassrooms");

                    b.Navigation("AllocateSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
