using DotaDrainCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaDrainCore.DataContext
{
    public class DotaDrainContext: DbContext
    {
        public DotaDrainContext(DbContextOptions<DotaDrainContext> options): base(options)
        {

        }
        
        public DbSet<BatchSizeConfiguration> BatchSizeConfigurations { get; set; }
        public DbSet<GameVersion> GameVersions { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<HeroItem> HeroItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<PlayerMatchHistory> PlayerMatchHistories { get; set; }
        public DbSet<Strategy> Strategies { get; set; }
        public DbSet<WeightConfiguration> WeightConfigurations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BatchSizeConfiguration>().ToTable("BatchSizeConfigurations");
            modelBuilder.Entity<GameVersion>().ToTable("GameVersions");
            modelBuilder.Entity<Player>().ToTable("Players");
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<HeroItem>().ToTable("HeroItems");
            modelBuilder.Entity<Match>().ToTable("Matches");
            modelBuilder.Entity<PlayerMatchHistory>().ToTable("PlayerMatchHistories");
            modelBuilder.Entity<Strategy>().ToTable("Strategies");
            modelBuilder.Entity<WeightConfiguration>().ToTable("WeightConfigurations");
        }
    }
}
