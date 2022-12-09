﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiSqlite.Data;

#nullable disable

namespace WebApiSqlite.Migrations
{
    [DbContext(typeof(WebApiSqliteContext))]
    [Migration("20221120163119_employee")]
    partial class employee
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("WebApiSqlite.Models.ActionItem", b =>
                {
                    b.Property<int>("ActionItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("DeveloperId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("OpenDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PlanDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tilte")
                        .HasColumnType("TEXT");

                    b.HasKey("ActionItemId");

                    b.HasIndex("DeveloperId");

                    b.ToTable("ActionItems");
                });

            modelBuilder.Entity("WebApiSqlite.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("TimeScheduleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("WebApiSqlite.Models.Developer", b =>
                {
                    b.Property<int>("DeveloperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ECOCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ECOSelected")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ECOYear")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("DeveloperId");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("WebApiSqlite.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Occupation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebApiSqlite.Models.ActionItem", b =>
                {
                    b.HasOne("WebApiSqlite.Models.Developer", "Developer")
                        .WithMany("ActionItems")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("WebApiSqlite.Models.Employee", b =>
                {
                    b.HasOne("WebApiSqlite.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WebApiSqlite.Models.Developer", b =>
                {
                    b.Navigation("ActionItems");
                });
#pragma warning restore 612, 618
        }
    }
}
