﻿// <auto-generated />
using System;
using JumgaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JumgaAPI.Migrations
{
    [DbContext(typeof(JumgaContext))]
    [Migration("20210113101956_order-cart-rider-subaccount")]
    partial class ordercartridersubaccount
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("JumgaAPI.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductUnit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("JumgaAPI.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("JumgaAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("DeliveryFee")
                        .HasColumnType("float");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.Property<int>("ProductUnit")
                        .HasColumnType("int");

                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("JumgaAPI.Models.Rider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubAccountId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Riders");
                });

            modelBuilder.Entity("JumgaAPI.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<int?>("MerchId")
                        .HasColumnType("int");

                    b.Property<int?>("RiderId")
                        .HasColumnType("int");

                    b.Property<string>("ShopEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShopName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShopNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubAccountId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RiderId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("JumgaAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JumgaAPI.Models.Item", b =>
                {
                    b.HasOne("JumgaAPI.Models.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("JumgaAPI.Models.Order", b =>
                {
                    b.HasOne("JumgaAPI.Models.Shop", null)
                        .WithMany("Orders")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JumgaAPI.Models.Product", b =>
                {
                    b.HasOne("JumgaAPI.Models.Shop", null)
                        .WithMany("Products")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JumgaAPI.Models.Shop", b =>
                {
                    b.HasOne("JumgaAPI.Models.Rider", "DispatchRider")
                        .WithMany()
                        .HasForeignKey("RiderId");

                    b.HasOne("JumgaAPI.Models.User", null)
                        .WithOne("UserShop")
                        .HasForeignKey("JumgaAPI.Models.Shop", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DispatchRider");
                });

            modelBuilder.Entity("JumgaAPI.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("JumgaAPI.Models.Shop", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("JumgaAPI.Models.User", b =>
                {
                    b.Navigation("UserShop");
                });
#pragma warning restore 612, 618
        }
    }
}
