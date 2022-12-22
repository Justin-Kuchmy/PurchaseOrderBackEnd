﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PurchaseOrderBackEnd.Data;

#nullable disable

namespace PurchaseOrderBackEnd.Migrations
{
    [DbContext(typeof(VendorAndProductsDBContext))]
    [Migration("20221221193201_Vendor")]
    partial class Vendor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PurchaseOrderBackEnd.Products.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("costprice")
                        .HasColumnType("bigint");

                    b.Property<int>("eoq")
                        .HasColumnType("int");

                    b.Property<long>("msrp")
                        .HasColumnType("bigint");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("qoh")
                        .HasColumnType("int");

                    b.Property<int>("qoo")
                        .HasColumnType("int");

                    b.Property<byte[]>("qrcode")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("qrcodetxt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rop")
                        .HasColumnType("int");

                    b.Property<int>("vendorid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("vendors");
                });

            modelBuilder.Entity("PurchaseOrderBackEnd.Vendors.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postalcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vendors");
                });
#pragma warning restore 612, 618
        }
    }
}