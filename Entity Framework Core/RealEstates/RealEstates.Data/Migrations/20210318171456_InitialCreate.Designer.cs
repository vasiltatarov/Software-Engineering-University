﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstates.Data;

namespace RealEstates.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210318171456_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RealEstates.Models.BuildingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BuildingTypes");
                });

            modelBuilder.Entity("RealEstates.Models.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("RealEstates.Models.RealEstatePropertyAd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("BuildingYear")
                        .HasColumnType("int");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<int?>("Floor")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RealEstatePropertyTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int?>("TotalBuildingFloors")
                        .HasColumnType("int");

                    b.Property<int?>("YardSize")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuildingTypeId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("RealEstatePropertyTypeId");

                    b.ToTable("RealEstatePropertyAds");
                });

            modelBuilder.Entity("RealEstates.Models.RealEstatePropertyTag", b =>
                {
                    b.Property<int>("RealEstatePropertyAdId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("RealEstatePropertyAdId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("RealEstatePropertyTags");
                });

            modelBuilder.Entity("RealEstates.Models.RealEstatePropertyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RealEstatePropertyTypes");
                });

            modelBuilder.Entity("RealEstates.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TagProperty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("RealEstates.Models.RealEstatePropertyAd", b =>
                {
                    b.HasOne("RealEstates.Models.BuildingType", "BuildingType")
                        .WithMany("RealEstatePropertyAds")
                        .HasForeignKey("BuildingTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RealEstates.Models.District", "District")
                        .WithMany("RealEstatePropertyAds")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RealEstates.Models.RealEstatePropertyType", "RealEstatePropertyType")
                        .WithMany("RealEstatePropertyAds")
                        .HasForeignKey("RealEstatePropertyTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BuildingType");

                    b.Navigation("District");

                    b.Navigation("RealEstatePropertyType");
                });

            modelBuilder.Entity("RealEstates.Models.RealEstatePropertyTag", b =>
                {
                    b.HasOne("RealEstates.Models.RealEstatePropertyAd", "RealEstatePropertyAd")
                        .WithMany("Tags")
                        .HasForeignKey("RealEstatePropertyAdId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RealEstates.Models.Tag", "Tag")
                        .WithMany("Tags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RealEstatePropertyAd");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("RealEstates.Models.BuildingType", b =>
                {
                    b.Navigation("RealEstatePropertyAds");
                });

            modelBuilder.Entity("RealEstates.Models.District", b =>
                {
                    b.Navigation("RealEstatePropertyAds");
                });

            modelBuilder.Entity("RealEstates.Models.RealEstatePropertyAd", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("RealEstates.Models.RealEstatePropertyType", b =>
                {
                    b.Navigation("RealEstatePropertyAds");
                });

            modelBuilder.Entity("RealEstates.Models.Tag", b =>
                {
                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}