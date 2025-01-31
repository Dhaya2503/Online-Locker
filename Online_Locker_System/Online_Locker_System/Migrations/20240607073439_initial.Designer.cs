﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Online_Locker_System.Models;

#nullable disable

namespace Online_Locker_System.Migrations
{
    [DbContext(typeof(LockerDbContext))]
    [Migration("20240607073439_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Online_Locker_System.Models.Approved_Locker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Approved_Date")
                        .HasColumnType("date");

                    b.Property<string>("Branch_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Requested_Date")
                        .HasColumnType("date");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.Property<int>("branch_DetailBranch_Id")
                        .HasColumnType("int");

                    b.Property<int>("customer_DetailUser_Id")
                        .HasColumnType("int");

                    b.Property<DateOnly>("requested_LockerRequested_Date")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("branch_DetailBranch_Id");

                    b.HasIndex("customer_DetailUser_Id");

                    b.HasIndex("requested_LockerRequested_Date");

                    b.ToTable("Approves");
                });

            modelBuilder.Entity("Online_Locker_System.Models.Branch_Detail", b =>
                {
                    b.Property<int>("Branch_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Branch_Id"));

                    b.Property<int>("Available_Locker")
                        .HasColumnType("int");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Total_locker")
                        .HasColumnType("int");

                    b.HasKey("Branch_Id");

                    b.ToTable("Branchs");
                });

            modelBuilder.Entity("Online_Locker_System.Models.Customer_Detail", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Id"));

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Locker_Status")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Online_Locker_System.Models.Requested_Locker", b =>
                {
                    b.Property<DateOnly>("Requested_Date")
                        .HasColumnType("date");

                    b.Property<string>("Branch_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.Property<int>("branch_DetailBranch_Id")
                        .HasColumnType("int");

                    b.Property<int>("customer_DetailUser_Id")
                        .HasColumnType("int");

                    b.HasKey("Requested_Date");

                    b.HasIndex("branch_DetailBranch_Id");

                    b.HasIndex("customer_DetailUser_Id");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Online_Locker_System.Models.Approved_Locker", b =>
                {
                    b.HasOne("Online_Locker_System.Models.Branch_Detail", "branch_Detail")
                        .WithMany()
                        .HasForeignKey("branch_DetailBranch_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_Locker_System.Models.Customer_Detail", "customer_Detail")
                        .WithMany()
                        .HasForeignKey("customer_DetailUser_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_Locker_System.Models.Requested_Locker", "requested_Locker")
                        .WithMany()
                        .HasForeignKey("requested_LockerRequested_Date")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("branch_Detail");

                    b.Navigation("customer_Detail");

                    b.Navigation("requested_Locker");
                });

            modelBuilder.Entity("Online_Locker_System.Models.Requested_Locker", b =>
                {
                    b.HasOne("Online_Locker_System.Models.Branch_Detail", "branch_Detail")
                        .WithMany()
                        .HasForeignKey("branch_DetailBranch_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_Locker_System.Models.Customer_Detail", "customer_Detail")
                        .WithMany()
                        .HasForeignKey("customer_DetailUser_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("branch_Detail");

                    b.Navigation("customer_Detail");
                });
#pragma warning restore 612, 618
        }
    }
}
