﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TokenWithMigrations.Models;

#nullable disable

namespace TokenWithMigrations.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220808163541_initialdb")]
    partial class initialdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TokenWithMigrations.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Gender")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<DateTime>("HireDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("JobTitle")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LoginID")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("MaritalStatus")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<DateTime>("ModifiedDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("NationalIDNumber")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<Guid?>("RowGuid")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("SickLeaveHours")
                        .IsUnicode(false)
                        .HasColumnType("smallint");

                    b.Property<short>("VacationHours")
                        .IsUnicode(false)
                        .HasColumnType("smallint");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("TokenWithMigrations.Models.UserInfo", b =>
                {
                    b.Property<DateTime?>("CreatedDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Password")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<string>("UserName")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.ToTable("UserInfo", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
