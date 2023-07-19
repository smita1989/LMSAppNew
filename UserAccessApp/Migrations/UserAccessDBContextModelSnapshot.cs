﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserAccessApp.DBContext;

#nullable disable

namespace UserAccessApp.Migrations
{
    [DbContext(typeof(UserAccessDBContext))]
    partial class UserAccessDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UserAccessApp.Models.LoanDetails", b =>
                {
                    b.Property<int>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanId"), 1L, 1);

                    b.Property<string>("BorrowerInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LienInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LoanAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LoanHistory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoanNumber")
                        .HasColumnType("int");

                    b.Property<string>("LoanTerm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Loanfees")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("OriginalAccount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OriginationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PropertyInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoanId");

                    b.HasIndex("UserId");

                    b.ToTable("LoanDetails");
                });

            modelBuilder.Entity("UserAccessApp.Models.LoanDocumentsDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DocNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoanId");

                    b.ToTable("LoanDocumentsDetails");
                });

            modelBuilder.Entity("UserAccessApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("UserAccessApp.Models.LoanDetails", b =>
                {
                    b.HasOne("UserAccessApp.Models.User", "User")
                        .WithMany("LoanDetails")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserAccessApp.Models.LoanDocumentsDetails", b =>
                {
                    b.HasOne("UserAccessApp.Models.LoanDetails", "LoanDetails")
                        .WithMany("LoanDocumentsDetails")
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoanDetails");
                });

            modelBuilder.Entity("UserAccessApp.Models.LoanDetails", b =>
                {
                    b.Navigation("LoanDocumentsDetails");
                });

            modelBuilder.Entity("UserAccessApp.Models.User", b =>
                {
                    b.Navigation("LoanDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
