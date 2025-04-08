﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shipping.DAL.Persistent.Data.Context;

#nullable disable

namespace Shipping.DAL.Migrations
{
    [DbContext(typeof(ShippingContext))]
    partial class ShippingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

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

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

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

                    b.Property<int?>("VillageDeliveryId")
                        .HasColumnType("int");

                    b.Property<string>("VillageStreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeightPriceId")
                        .HasColumnType("int");

                    b.Property<int>("orderStatus")
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

            modelBuilder.Entity("Shipping.DAL.Entities.Delivery", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<float>("CompanyPercent")
                        .HasColumnType("real");

                    b.Property<string>("TypeOfDiscount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.DeliveryBranch", b =>
                {
                    b.Property<int>("BranchID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("DeliveryID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("BranchID", "DeliveryID");

                    b.HasIndex("DeliveryID");

                    b.ToTable("DeliveryBranches");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Employees");
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

            modelBuilder.Entity("Shipping.DAL.Entities.Identity.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Shipping.DAL.Entities.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Shipping.DAL.Entities.Merchant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("PickUpPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RejectedOrderPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Merchants");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.MerchantBranch", b =>
                {
                    b.Property<int>("BranchID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("MerchantID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("BranchID", "MerchantID");

                    b.HasIndex("MerchantID");

                    b.ToTable("MerchantBranches");
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

                    b.Property<int>("DefaultWeight")
                        .HasColumnType("int");

                    b.Property<decimal>("ExtraPricePerKilo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("weightPrices");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Shipping.DAL.Entities.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Shipping.DAL.Entities.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Shipping.DAL.Entities.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Shipping.DAL.Entities.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shipping.DAL.Entities.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Shipping.DAL.Entities.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                        .HasForeignKey("VillageDeliveryId");

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

            modelBuilder.Entity("Shipping.DAL.Entities.Delivery", b =>
                {
                    b.HasOne("Shipping.DAL.Entities.Identity.ApplicationUser", "User")
                        .WithOne("Delivery")
                        .HasForeignKey("Shipping.DAL.Entities.Delivery", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.DeliveryBranch", b =>
                {
                    b.HasOne("Shipping.DAL.Entities.Branches", "Branch")
                        .WithMany("DeliveryBranches")
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shipping.DAL.Entities.Delivery", "Delivery")
                        .WithMany("DeliveryBranches")
                        .HasForeignKey("DeliveryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Delivery");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.Employee", b =>
                {
                    b.HasOne("Shipping.DAL.Entities.Identity.ApplicationUser", "User")
                        .WithOne("Employee")
                        .HasForeignKey("Shipping.DAL.Entities.Employee", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.Merchant", b =>
                {
                    b.HasOne("Shipping.DAL.Entities.Identity.ApplicationUser", "User")
                        .WithOne("Merchant")
                        .HasForeignKey("Shipping.DAL.Entities.Merchant", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.MerchantBranch", b =>
                {
                    b.HasOne("Shipping.DAL.Entities.Branches", "Branch")
                        .WithMany("MerchantBranches")
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shipping.DAL.Entities.Merchant", "Merchant")
                        .WithMany("MerchantBranches")
                        .HasForeignKey("MerchantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Merchant");
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

            modelBuilder.Entity("Shipping.DAL.Entities.Branches", b =>
                {
                    b.Navigation("DeliveryBranches");

                    b.Navigation("MerchantBranches");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.City", b =>
                {
                    b.Navigation("orders");

                    b.Navigation("specialPackages");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.Delivery", b =>
                {
                    b.Navigation("DeliveryBranches");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.Governorate", b =>
                {
                    b.Navigation("cities");

                    b.Navigation("orders");

                    b.Navigation("specialPackages");
                });

            modelBuilder.Entity("Shipping.DAL.Entities.Identity.ApplicationUser", b =>
                {
                    b.Navigation("Delivery")
                        .IsRequired();

                    b.Navigation("Employee")
                        .IsRequired();

                    b.Navigation("Merchant")
                        .IsRequired();
                });

            modelBuilder.Entity("Shipping.DAL.Entities.Merchant", b =>
                {
                    b.Navigation("MerchantBranches");
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
