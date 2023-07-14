﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MineralWaterMonitoring.Data;

#nullable disable

namespace MineralWaterMonitoring.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MineralWaterMonitoring.Domain.Collection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("CollectionId");

                    b.Property<int>("CollectionAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("MineralWaterMonitoring.Domain.Contributions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("ContributionId");

                    b.Property<Guid>("CollectionId")
                        .HasColumnType("char(36)");

                    b.Property<int>("ContributionAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PayerId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.HasIndex("PayerId");

                    b.ToTable("Contributions");
                });

            modelBuilder.Entity("MineralWaterMonitoring.Domain.Groups", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("GroupId");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("GroupCode")
                        .HasColumnType("longtext");

                    b.Property<string>("GroupName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("MineralWaterMonitoring.Domain.Payers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("PayerId");

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Fullname")
                        .HasColumnType("longtext");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Payers");
                });

            modelBuilder.Entity("MineralWaterMonitoring.Domain.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("UserId");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MineralWaterMonitoring.Domain.Collection", b =>
                {
                    b.HasOne("MineralWaterMonitoring.Domain.Groups", "Groups")
                        .WithMany("Collection")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Groups");
                });

            modelBuilder.Entity("MineralWaterMonitoring.Domain.Contributions", b =>
                {
                    b.HasOne("MineralWaterMonitoring.Domain.Collection", "Collection")
                        .WithMany()
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MineralWaterMonitoring.Domain.Payers", "Payer")
                        .WithMany("Contributions")
                        .HasForeignKey("PayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Collection");

                    b.Navigation("Payer");
                });

            modelBuilder.Entity("MineralWaterMonitoring.Domain.Payers", b =>
                {
                    b.HasOne("MineralWaterMonitoring.Domain.Groups", "Groups")
                        .WithMany("Payers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Groups");
                });

            modelBuilder.Entity("MineralWaterMonitoring.Domain.Groups", b =>
                {
                    b.Navigation("Collection");

                    b.Navigation("Payers");
                });

            modelBuilder.Entity("MineralWaterMonitoring.Domain.Payers", b =>
                {
                    b.Navigation("Contributions");
                });
#pragma warning restore 612, 618
        }
    }
}
