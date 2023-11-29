﻿// <auto-generated />
using System;
using Application.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Application.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231129103017_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Application.Models.Domain.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("integer");

                    b.Property<int>("ParentSectorId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ParentSectorId");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("Application.Models.Domain.SessionData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Consent")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("SectorSessionData", b =>
                {
                    b.Property<int>("SectorsId")
                        .HasColumnType("integer");

                    b.Property<Guid>("SessionDataId")
                        .HasColumnType("uuid");

                    b.HasKey("SectorsId", "SessionDataId");

                    b.HasIndex("SessionDataId");

                    b.ToTable("SectorSessionData");
                });

            modelBuilder.Entity("Application.Models.Domain.Sector", b =>
                {
                    b.HasOne("Application.Models.Domain.Sector", "ParentSector")
                        .WithMany("SubSectors")
                        .HasForeignKey("ParentSectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentSector");
                });

            modelBuilder.Entity("SectorSessionData", b =>
                {
                    b.HasOne("Application.Models.Domain.Sector", null)
                        .WithMany()
                        .HasForeignKey("SectorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Models.Domain.SessionData", null)
                        .WithMany()
                        .HasForeignKey("SessionDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Application.Models.Domain.Sector", b =>
                {
                    b.Navigation("SubSectors");
                });
#pragma warning restore 612, 618
        }
    }
}
