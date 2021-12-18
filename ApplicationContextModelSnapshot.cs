﻿// <auto-generated />
using System;
using FinanceManager.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinanceManager.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("FinanceManager.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Balance")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("ToCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("FinanceManager.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte>("A")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("B")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("G")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageSource")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("R")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FinanceManager.Models.MoneyChange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Impact")
                        .HasColumnType("REAL");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CategoryId");

                    b.ToTable("MoneyChanges");
                });

            modelBuilder.Entity("FinanceManager.Models.MoneyChange", b =>
                {
                    b.HasOne("FinanceManager.Models.Account", "Account")
                        .WithMany("InfluenceMoneyChanges")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanceManager.Models.Category", "Category")
                        .WithMany("MoneyChanges")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FinanceManager.Models.Account", b =>
                {
                    b.Navigation("InfluenceMoneyChanges");
                });

            modelBuilder.Entity("FinanceManager.Models.Category", b =>
                {
                    b.Navigation("MoneyChanges");
                });
#pragma warning restore 612, 618
        }
    }
}