﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shipping.DAL.Persistent.Data.Context;

#nullable disable

namespace Shipping.DAL.Migrations
{
    [DbContext(typeof(ShippingContext))]
    [Migration("20250324154406_V1")]
    partial class V1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GovernorateId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVillageDelivery")
                        .HasColumnType("bit");

                    b.Property<decimal>("OrderPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<int>("RejectionReason")
                        .HasColumnType("int");

                    b.Property<int>("ShippingMethod")
                        .HasColumnType("int");

                    b.Property<decimal>("ShippingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ShippingTypeId")
                        .HasColumnType("int");

                    b.Property<double>("TotalWeight")
                        .HasColumnType("float");

                    b.Property<int>("VillageDeliveryId")
                        .HasColumnType("int");

                    b.Property<int>("WeightPriceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("GovernorateId");

                    b.HasIndex("ShippingTypeId");

                    b.HasIndex("VillageDeliveryId");

                    b.HasIndex("WeightPriceId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Order_Product", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.Branches", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GovId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PickUpShippingPrice")
                        .HasColumnType("money");

                    b.Property<decimal>("ShippingPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("GovId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.Governorate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("governorates");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.ShippingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("ShippingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("shippingTypes");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.SpecialPackages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("ShippingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("cityID")
                        .HasColumnType("int");

                    b.Property<int>("governorateID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("cityID")
                        .IsUnique();

                    b.HasIndex("governorateID");

                    b.ToTable("specialPackages");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.VillageDelivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("villageDeliveries");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.WeightPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("DefaultPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DefaultWeight")
                        .HasColumnType("int");

                    b.Property<decimal>("ExtraPricePerKilo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("weightPrices");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.HasOne("Shipping.DAL.Entities.City", "City")
                        .WithMany("orders")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shipping.DAL.Entities.Governorate", "Governorate")
                        .WithMany("orders")
                        .HasForeignKey("GovernorateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shipping.DAL.Entities.ShippingType", "ShippingType")
                        .WithMany("orders")
                        .HasForeignKey("ShippingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shipping.DAL.Entities.VillageDelivery", "VillageDelivery")
                        .WithMany("orders")
                        .HasForeignKey("VillageDeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shipping.DAL.Entities.WeightPrice", "weightPrice")
                        .WithMany("orders")
                        .HasForeignKey("WeightPriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Governorate");

                    b.Navigation("ShippingType");

                    b.Navigation("VillageDelivery");

                    b.Navigation("weightPrice");
                });

            modelBuilder.Entity("Order_Product", b =>
                {
                    b.HasOne("Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.City", b =>
                {
                    b.HasOne("Shipping.DAL.Entities.Governorate", "governorate")
                        .WithMany("cities")
                        .HasForeignKey("GovId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("governorate");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.SpecialPackages", b =>
                {
                    b.HasOne("Shipping.DAL.Entities.City", "city")
                        .WithOne("specialPackages")
                        .HasForeignKey("Shipping.DAL.Entities.SpecialPackages", "cityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shipping.DAL.Entities.Governorate", "governorate")
                        .WithMany("specialPackages")
                        .HasForeignKey("governorateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("city");

                    b.Navigation("governorate");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.City", b =>
                {
                    b.Navigation("orders");

                    b.Navigation("specialPackages");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.Governorate", b =>
                {
                    b.Navigation("cities");

                    b.Navigation("orders");

                    b.Navigation("specialPackages");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.ShippingType", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.VillageDelivery", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.WeightPrice", b =>
                {
                    b.Navigation("orders");
                });
#pragma warning restore 612, 618
        }
    }
}
