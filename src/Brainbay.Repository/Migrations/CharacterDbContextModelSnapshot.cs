﻿// <auto-generated />
using System;
using Brainbay.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Brainbay.Repository.Migrations
{
    [DbContext(typeof(CharacterDbContext))]
    partial class CharacterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Brainbay.Common.Entities.Character", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CharacterTypeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GenderID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LocationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OriginID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SpeciesID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StatusID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CharacterTypeID");

                    b.HasIndex("GenderID");

                    b.HasIndex("LocationID");

                    b.HasIndex("OriginID");

                    b.HasIndex("SpeciesID");

                    b.HasIndex("StatusID");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Brainbay.Common.Entities.CharacterType", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CharacterTypes");
                });

            modelBuilder.Entity("Brainbay.Common.Entities.Episode", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CharacterID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CharacterID");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("Brainbay.Common.Entities.Gender", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Brainbay.Common.Entities.Location", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Brainbay.Common.Entities.Origin", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Origins");
                });

            modelBuilder.Entity("Brainbay.Common.Entities.Species", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("Brainbay.Common.Entities.Status", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Brainbay.Common.Entities.Character", b =>
                {
                    b.HasOne("Brainbay.Common.Entities.CharacterType", "CharacterType")
                        .WithMany("Characters")
                        .HasForeignKey("CharacterTypeID");

                    b.HasOne("Brainbay.Common.Entities.Gender", "Gender")
                        .WithMany("Characters")
                        .HasForeignKey("GenderID");

                    b.HasOne("Brainbay.Common.Entities.Location", "Location")
                        .WithMany("Characters")
                        .HasForeignKey("LocationID");

                    b.HasOne("Brainbay.Common.Entities.Origin", "Origin")
                        .WithMany("Characters")
                        .HasForeignKey("OriginID");

                    b.HasOne("Brainbay.Common.Entities.Species", "Species")
                        .WithMany("Characters")
                        .HasForeignKey("SpeciesID");

                    b.HasOne("Brainbay.Common.Entities.Status", "Status")
                        .WithMany("Characters")
                        .HasForeignKey("StatusID");

                    b.Navigation("CharacterType");

                    b.Navigation("Gender");

                    b.Navigation("Location");

                    b.Navigation("Origin");

                    b.Navigation("Species");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Brainbay.Common.Entities.Episode", b =>
                {
                    b.HasOne("Brainbay.Common.Entities.Character", "Character")
                        .WithMany("Episodes")
                        .HasForeignKey("CharacterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("Brainbay.Common.Entities.Character", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("Brainbay.Common.Entities.CharacterType", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Brainbay.Common.Entities.Gender", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Brainbay.Common.Entities.Location", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Brainbay.Common.Entities.Origin", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Brainbay.Common.Entities.Species", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Brainbay.Common.Entities.Status", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
