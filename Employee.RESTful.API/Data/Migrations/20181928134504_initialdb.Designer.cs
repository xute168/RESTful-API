﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Employee.RESTful.API.Data.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20180928134504_initialdb")]
    partial class initialdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview2-35157")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreEmp.Data.Employee", b =>
            {
                b.Property<int>("EmployeeId")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                b.Property<string>("FirstName");
                b.Property<string>("Lastname");
                b.Property<DateTime>("HireDate");

                b.HasKey("EmployeeId");

                b.ToTable("Employees");

                b.HasData(
                    new
                    {
                        EmployeesId = 1,
                        HireDate = new DateTime(2020, 01, 04, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        LastName = "ATL2018",
                        FirstName = "Atlanta Code Camp"
                    });
            });

            modelBuilder.Entity("CoreEmp.Data.EmployeeTask", b =>
            {
                b.Property<int>("EmployeeTaskId")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("TaskName");

                b.Property<DateTime>("StartDate");

                b.Property<DateTime>("DeadLine");

                b.Property<int?>("EmployeeId");

                b.HasKey("EmployeeTaskId");

                b.HasIndex("EmployeeId");

                b.ToTable("EmployeeTasks");

                b.HasData(
                    new
                    {
                        EmployeeTaskId = 1,
                        EmployeeId = 1,
                        StartDate = new DateTime(2020, 01, 04, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        DeadLine = new DateTime(2020, 01, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        TaskName = "Entity Framework From Scratch"
                    },
                    new
                    {
                        EmployeeTaskId = 2,
                        EmployeeId = 1,
                        StartDate = new DateTime(2020, 01, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        DeadLine = new DateTime(2020, 02, 04, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        TaskName = "Writing Sample Data Made Easy"
                    });
            });

            modelBuilder.Entity("CoreEmp.Data.EmployeeTask", b =>
            {
                b.HasOne("CoreEmp.Data.Employee", "Employee")
                    .WithMany("EmployeeTasks")
                    .HasForeignKey("EmployeeId");

            });
#pragma warning restore 612, 618
        }
    }
}
