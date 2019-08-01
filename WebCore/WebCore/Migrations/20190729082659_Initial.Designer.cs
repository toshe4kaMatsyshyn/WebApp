﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebCore.Models;

namespace WebCore.Migrations
{
    [DbContext(typeof(WebAppDatabaseContext))]
    [Migration("20190729082659_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebCore.Models.Brands", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("WebCore.Models.DeliveredBrands", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20);

                    b.Property<int?>("CountOfDelivered");

                    b.Property<string>("ProduceBrandsId")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("ProduceBrandsId");

                    b.ToTable("DeliveredBrands");
                });

            modelBuilder.Entity("WebCore.Models.ProducedBrands", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20);

                    b.Property<string>("BrandId")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int?>("CountOfProduced");

                    b.Property<DateTime?>("YearOfProduced")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("ProducedBrands");
                });

            modelBuilder.Entity("WebCore.Models.Terminal", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .HasMaxLength(30);

                    b.Property<int?>("ProducedBrands");

                    b.HasKey("Id");

                    b.ToTable("Terminal");
                });

            modelBuilder.Entity("WebCore.Models.TerminalsAndBrands", b =>
                {
                    b.Property<string>("ProducedBrandsId")
                        .HasMaxLength(20);

                    b.Property<string>("TerminalId")
                        .HasMaxLength(10);

                    b.HasKey("ProducedBrandsId", "TerminalId");

                    b.HasIndex("TerminalId");

                    b.ToTable("TerminalsAndBrands");
                });

            modelBuilder.Entity("WebCore.Models.DeliveredBrands", b =>
                {
                    b.HasOne("WebCore.Models.ProducedBrands", "ProduceBrands")
                        .WithMany("DeliveredBrands")
                        .HasForeignKey("ProduceBrandsId")
                        .HasConstraintName("FK_DeliveredBrands_ProducedBrands");
                });

            modelBuilder.Entity("WebCore.Models.ProducedBrands", b =>
                {
                    b.HasOne("WebCore.Models.Brands", "Brand")
                        .WithMany("ProducedBrands")
                        .HasForeignKey("BrandId")
                        .HasConstraintName("FK_ProducedBrands_Brands");
                });

            modelBuilder.Entity("WebCore.Models.TerminalsAndBrands", b =>
                {
                    b.HasOne("WebCore.Models.ProducedBrands", "ProducedBrands")
                        .WithMany("TerminalsAndBrands")
                        .HasForeignKey("ProducedBrandsId")
                        .HasConstraintName("FK_TerminalsAndBrands_ProducedBrands");

                    b.HasOne("WebCore.Models.Terminal", "Terminal")
                        .WithMany("TerminalsAndBrands")
                        .HasForeignKey("TerminalId")
                        .HasConstraintName("FK_TerminalsAndBrands_Terminal");
                });
#pragma warning restore 612, 618
        }
    }
}
