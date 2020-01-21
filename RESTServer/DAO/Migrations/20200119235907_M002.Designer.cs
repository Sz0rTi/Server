﻿// <auto-generated />
using System;
using DAO.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAO.Migrations
{
    [DbContext(typeof(MagazineContext))]
    [Migration("20200119235907_M002")]
    partial class M002
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAO.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NIP");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PostCode");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DAO.Models.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DAO.Models.Client", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("NIP");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<string>("PostCode");

                    b.Property<string>("Street");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("DAO.Models.InvoiceBuy", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsPaid");

                    b.Property<string>("Name");

                    b.Property<DateTime>("PaymentDeadline");

                    b.Property<Guid>("PaymentMethodID");

                    b.Property<double>("PriceBrutto");

                    b.Property<double>("PriceNetto");

                    b.Property<Guid>("SellerID");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("SellerID");

                    b.HasIndex("UserID");

                    b.ToTable("InvoicesBuy");
                });

            modelBuilder.Entity("DAO.Models.InvoiceSell", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClientID");

                    b.Property<string>("Code");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsPaid");

                    b.Property<string>("Name");

                    b.Property<DateTime>("PaymentDeadline");

                    b.Property<Guid>("PaymentMethodID");

                    b.Property<double>("PriceBrutto");

                    b.Property<double>("PriceNetto");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("UserID");

                    b.ToTable("InvoicesSell");
                });

            modelBuilder.Entity("DAO.Models.PaymentMethod", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("DAO.Models.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<Guid>("CategoryID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<double>("PriceNetto");

                    b.Property<Guid>("TaxStageID");

                    b.Property<Guid>("UnitID");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("TaxStageID");

                    b.HasIndex("UnitID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DAO.Models.ProductBuy", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<Guid>("InvoiceBuyID");

                    b.Property<string>("Name");

                    b.Property<double>("PricePerItemBrutto");

                    b.Property<double>("PricePerItemNetto");

                    b.Property<Guid>("ProductID");

                    b.Property<Guid>("TaxStageID");

                    b.Property<Guid>("UnitID");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("InvoiceBuyID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductsBuy");
                });

            modelBuilder.Entity("DAO.Models.ProductSell", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<double>("BasePriceNetto");

                    b.Property<Guid>("InvoiceSellID");

                    b.Property<string>("Name");

                    b.Property<double>("PricePerItemBrutto");

                    b.Property<double>("PricePerItemNetto");

                    b.Property<Guid>("ProductID");

                    b.Property<Guid>("TaxStageID");

                    b.Property<Guid>("UnitID");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("InvoiceSellID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductsSell");
                });

            modelBuilder.Entity("DAO.Models.Purchase", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<double>("PriceNetto");

                    b.Property<Guid>("ProductID");

                    b.Property<Guid>("TaxStageID");

                    b.Property<Guid>("UnitID");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("DAO.Models.Seller", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("NIP");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<string>("PostCode");

                    b.Property<string>("Street");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("DAO.Models.TaxStage", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Stage");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.ToTable("TaxStages");
                });

            modelBuilder.Entity("DAO.Models.Unit", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "8d09d664-988d-45d1-a5ac-7dc9740a736a",
                            ConcurrencyStamp = "973f0436-73da-4767-a63a-529d9c1c5747",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "629d8567-7990-44a1-bd49-c02cbab24256",
                            ConcurrencyStamp = "7540b9f3-7982-4c37-8cfd-dfe6e693df48",
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DAO.Models.InvoiceBuy", b =>
                {
                    b.HasOne("DAO.Models.Seller", "Seller")
                        .WithMany("InvoicesBuy")
                        .HasForeignKey("SellerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAO.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("DAO.Models.InvoiceSell", b =>
                {
                    b.HasOne("DAO.Models.Client", "Client")
                        .WithMany("InvoicesSell")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAO.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("DAO.Models.Product", b =>
                {
                    b.HasOne("DAO.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAO.Models.TaxStage", "TaxStage")
                        .WithMany("Product")
                        .HasForeignKey("TaxStageID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAO.Models.Unit", "Unit")
                        .WithMany("Products")
                        .HasForeignKey("UnitID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAO.Models.ProductBuy", b =>
                {
                    b.HasOne("DAO.Models.InvoiceBuy", "InvoiceBuy")
                        .WithMany("ProductsBuy")
                        .HasForeignKey("InvoiceBuyID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAO.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAO.Models.ProductSell", b =>
                {
                    b.HasOne("DAO.Models.InvoiceSell", "InvoiceSell")
                        .WithMany("ProductsSell")
                        .HasForeignKey("InvoiceSellID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAO.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAO.Models.Purchase", b =>
                {
                    b.HasOne("DAO.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DAO.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DAO.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAO.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DAO.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
