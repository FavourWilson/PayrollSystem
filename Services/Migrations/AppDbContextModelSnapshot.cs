﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Services;

namespace Services.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExpensesId")
                        .HasColumnType("int");

                    b.Property<int?>("IncomeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photopath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SalaryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExpensesId");

                    b.HasIndex("IncomeId");

                    b.HasIndex("SalaryId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Models.Employee_Expenses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ExpensesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ExpensesId");

                    b.ToTable("Employee_Expenses");
                });

            modelBuilder.Entity("Models.Expenses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AmountSpent")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateSpent")
                        .HasColumnType("datetime2");

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<string>("Expense")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Models.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("incomes");
                });

            modelBuilder.Entity("Models.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AmountPaid")
                        .HasColumnType("float");

                    b.Property<DateTime>("DatePaid")
                        .HasColumnType("datetime2");

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("Models.Employee", b =>
                {
                    b.HasOne("Models.Expenses", null)
                        .WithMany("Employee")
                        .HasForeignKey("ExpensesId");

                    b.HasOne("Models.Income", "Income")
                        .WithMany("Employees")
                        .HasForeignKey("IncomeId");

                    b.HasOne("Models.Salary", "Salary")
                        .WithMany("Employee")
                        .HasForeignKey("SalaryId");

                    b.Navigation("Income");

                    b.Navigation("Salary");
                });

            modelBuilder.Entity("Models.Employee_Expenses", b =>
                {
                    b.HasOne("Models.Employee", "Employee")
                        .WithMany("Employee_Expenses")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Expenses", "Expenses")
                        .WithMany("Employee_Expenses")
                        .HasForeignKey("ExpensesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("Models.Employee", b =>
                {
                    b.Navigation("Employee_Expenses");
                });

            modelBuilder.Entity("Models.Expenses", b =>
                {
                    b.Navigation("Employee");

                    b.Navigation("Employee_Expenses");
                });

            modelBuilder.Entity("Models.Income", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Models.Salary", b =>
                {
                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
