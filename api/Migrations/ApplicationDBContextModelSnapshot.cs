﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api.Models.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Attachment")
                        .HasColumnType("varbinary(max)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IBAN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NIB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Swift")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("api.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("api.Models.Credit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountOrCardCodeToDebt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CloseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DebtCapital")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Installment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PayDay")
                        .HasColumnType("int");

                    b.Property<decimal>("StartingCapital")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TAN")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Credits");
                });

            modelBuilder.Entity("api.Models.CreditCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CloseExtractDay")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IBAN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NIB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PercentageOfPayment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Plafon")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RefNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("api.Models.DebitCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DebitCards");
                });

            modelBuilder.Entity("api.Models.Earning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationAccountOrCardCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Months")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PayDay")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Earnings");
                });

            modelBuilder.Entity("api.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationAccountOrCardCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Months")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PayDay")
                        .HasColumnType("int");

                    b.Property<string>("SourceAccountOrCardCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("api.Models.FinanceGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("CurrentDebtAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndGoalDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Goal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("OutstandingAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartGoalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FinanceGoals");
                });

            modelBuilder.Entity("api.Models.GiftCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Attachment")
                        .HasColumnType("varbinary(max)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVoucher")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("GiftCards");
                });

            modelBuilder.Entity("api.Models.OSRSWorld", b =>
                {
                    b.Property<int>("World")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("World"));

                    b.Property<bool>("IsF2P")
                        .HasColumnType("bit");

                    b.HasKey("World");

                    b.ToTable("OSRSWorlds");
                });

            modelBuilder.Entity("api.Models.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("AnnualPlafon")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal?>("MonthlyPlafond")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("api.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte[]>("Attachment")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreditId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationAccountOrCardCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EarningId")
                        .HasColumnType("int");

                    b.Property<int?>("ExpenseId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OperationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SourceAccountOrCardCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int?>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreditId");

                    b.HasIndex("EarningId");

                    b.HasIndex("ExpenseId");

                    b.HasIndex("SubCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("api.Models.Weigth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("Kg")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Weigth");
                });

            modelBuilder.Entity("api.Models.BankAccount", b =>
                {
                    b.HasOne("api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.Category", b =>
                {
                    b.HasOne("api.Models.User", "User")
                        .WithMany("Categories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.Credit", b =>
                {
                    b.HasOne("api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.CreditCard", b =>
                {
                    b.HasOne("api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.DebitCard", b =>
                {
                    b.HasOne("api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.Earning", b =>
                {
                    b.HasOne("api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.Expense", b =>
                {
                    b.HasOne("api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.FinanceGoal", b =>
                {
                    b.HasOne("api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.GiftCard", b =>
                {
                    b.HasOne("api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.SubCategory", b =>
                {
                    b.HasOne("api.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("api.Models.Transaction", b =>
                {
                    b.HasOne("api.Models.Credit", "Credit")
                        .WithMany()
                        .HasForeignKey("CreditId");

                    b.HasOne("api.Models.Earning", "Earning")
                        .WithMany()
                        .HasForeignKey("EarningId");

                    b.HasOne("api.Models.Expense", "Expense")
                        .WithMany()
                        .HasForeignKey("ExpenseId");

                    b.HasOne("api.Models.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId");

                    b.HasOne("api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Credit");

                    b.Navigation("Earning");

                    b.Navigation("Expense");

                    b.Navigation("SubCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.Weigth", b =>
                {
                    b.HasOne("api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
