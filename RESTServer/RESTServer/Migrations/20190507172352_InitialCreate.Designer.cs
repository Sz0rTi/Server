﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RESTServer.Data;

namespace RESTServer.Migrations
{
    [DbContext(typeof(MagazineContext))]
    [Migration("20190507172352_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RESTServer.Models.Category", b =>
                {
                    b.Property<long>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("RESTServer.Models.Client", b =>
                {
                    b.Property<long>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress");

                    b.Property<string>("Mail");

                    b.Property<string>("NIP");

                    b.Property<string>("Name");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("RESTServer.Models.InvoiceBuy", b =>
                {
                    b.Property<long>("InvoiceBuyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsPaid");

                    b.Property<double>("PriceBrutto");

                    b.Property<double>("PriceNetto");

                    b.Property<long>("SellerId");

                    b.Property<long?>("UserId");

                    b.HasKey("InvoiceBuyId");

                    b.HasIndex("SellerId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("InvoicesBuy");
                });

            modelBuilder.Entity("RESTServer.Models.InvoiceSell", b =>
                {
                    b.Property<int>("InvoiceSellId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientId");

                    b.Property<long?>("ClientId1");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsPaid");

                    b.Property<DateTime>("PaymentDeadline");

                    b.Property<double>("PriceBrutto");

                    b.Property<double>("PriceNetto");

                    b.Property<long?>("UserId");

                    b.HasKey("InvoiceSellId");

                    b.HasIndex("ClientId1");

                    b.HasIndex("UserId");

                    b.ToTable("InvoicesSell");
                });

            modelBuilder.Entity("RESTServer.Models.Product", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<double>("PriceNetto");

                    b.Property<long>("TaxStageId");

                    b.Property<long>("UnitId");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TaxStageId");

                    b.HasIndex("UnitId")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("RESTServer.Models.ProductBuy", b =>
                {
                    b.Property<long>("ProductBuyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<long>("InvoiceBuyId");

                    b.Property<double>("PricePerItemBrutto");

                    b.Property<double>("PricePerItemNetto");

                    b.Property<long>("ProductId");

                    b.HasKey("ProductBuyId");

                    b.HasIndex("InvoiceBuyId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductsBuy");
                });

            modelBuilder.Entity("RESTServer.Models.ProductSell", b =>
                {
                    b.Property<long>("ProductSellId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<long>("InvoiceSellId");

                    b.Property<int?>("InvoiceSellId1");

                    b.Property<double>("PricePerItemBrutto");

                    b.Property<double>("PricePerItemNetto");

                    b.Property<long>("ProductId");

                    b.Property<long>("TaxStageId");

                    b.HasKey("ProductSellId");

                    b.HasIndex("InvoiceSellId1");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductsSell");
                });

            modelBuilder.Entity("RESTServer.Models.Role", b =>
                {
                    b.Property<long>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("RESTServer.Models.Seller", b =>
                {
                    b.Property<long>("SellerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("NIP");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("SellerId");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("RESTServer.Models.TaxStage", b =>
                {
                    b.Property<long>("TaxStageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Stage");

                    b.HasKey("TaxStageId");

                    b.ToTable("TaxStages");
                });

            modelBuilder.Entity("RESTServer.Models.Unit", b =>
                {
                    b.Property<long>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("UnitId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("RESTServer.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<long>("RoleId");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("RESTServer.Models.InvoiceBuy", b =>
                {
                    b.HasOne("RESTServer.Models.Seller", "Seller")
                        .WithOne("InvoiceBuy")
                        .HasForeignKey("RESTServer.Models.InvoiceBuy", "SellerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RESTServer.Models.User", "User")
                        .WithMany("InvoicesBuy")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("RESTServer.Models.InvoiceSell", b =>
                {
                    b.HasOne("RESTServer.Models.Client", "Client")
                        .WithMany("InvoicesSell")
                        .HasForeignKey("ClientId1");

                    b.HasOne("RESTServer.Models.User", "User")
                        .WithMany("InvoicesSell")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("RESTServer.Models.Product", b =>
                {
                    b.HasOne("RESTServer.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RESTServer.Models.TaxStage", "TaxStage")
                        .WithMany("Product")
                        .HasForeignKey("TaxStageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RESTServer.Models.Unit", "Unit")
                        .WithOne("Product")
                        .HasForeignKey("RESTServer.Models.Product", "UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RESTServer.Models.ProductBuy", b =>
                {
                    b.HasOne("RESTServer.Models.InvoiceBuy", "InvoiceBuy")
                        .WithMany("Products")
                        .HasForeignKey("InvoiceBuyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RESTServer.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RESTServer.Models.ProductSell", b =>
                {
                    b.HasOne("RESTServer.Models.InvoiceSell", "InvoiceSell")
                        .WithMany("Products")
                        .HasForeignKey("InvoiceSellId1");

                    b.HasOne("RESTServer.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RESTServer.Models.User", b =>
                {
                    b.HasOne("RESTServer.Models.Role", "Role")
                        .WithOne("User")
                        .HasForeignKey("RESTServer.Models.User", "RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
