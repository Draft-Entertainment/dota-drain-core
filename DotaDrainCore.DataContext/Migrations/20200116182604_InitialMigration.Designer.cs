﻿// <auto-generated />
using System;
using DotaDrainCore.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotaDrainCore.DataContext.Migrations
{
    [DbContext(typeof(DotaDrainContext))]
    [Migration("20200116182604_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotaDrainCore.Entities.BatchSizeConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BatchSizeConfigurations");
                });

            modelBuilder.Entity("DotaDrainCore.Entities.GameVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PatchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("GameVersions");
                });

            modelBuilder.Entity("DotaDrainCore.Entities.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ExternalId")
                        .HasColumnType("bigint");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("DotaDrainCore.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ExternalId")
                        .HasColumnType("bigint");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerMatchHistoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerMatchHistoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("DotaDrainCore.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ExternalMatchId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Winner")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("DotaDrainCore.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PlayerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SteamAccountId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DotaDrainCore.Entities.PlayerMatchHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<int>("Deaths")
                        .HasColumnType("int");

                    b.Property<int>("HeroId")
                        .HasColumnType("int");

                    b.Property<int>("Kills")
                        .HasColumnType("int");

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Side")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerMatchHistories");
                });

            modelBuilder.Entity("DotaDrainCore.Entities.WeightConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("EnemyHeroWeight")
                        .HasColumnType("float");

                    b.Property<double>("ItemRate")
                        .HasColumnType("float");

                    b.Property<double>("SelfHeroWeight")
                        .HasColumnType("float");

                    b.Property<double>("TeamHeroWeight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("WeightConfigurations");
                });

            modelBuilder.Entity("DotaDrainCore.Entities.Item", b =>
                {
                    b.HasOne("DotaDrainCore.Entities.PlayerMatchHistory", null)
                        .WithMany("Items")
                        .HasForeignKey("PlayerMatchHistoryId");
                });

            modelBuilder.Entity("DotaDrainCore.Entities.PlayerMatchHistory", b =>
                {
                    b.HasOne("DotaDrainCore.Entities.Hero", "Hero")
                        .WithMany("PlayerMatchHistories")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotaDrainCore.Entities.Match", null)
                        .WithMany("MatchHistory")
                        .HasForeignKey("MatchId");

                    b.HasOne("DotaDrainCore.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
