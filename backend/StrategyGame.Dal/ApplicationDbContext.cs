﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Identity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Dal
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<City> Cities { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Upgrade> Upgrades { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Rounds> Rounds { get; set; }
        public DbSet<Army> Armies { get; set; }
        public DbSet<CityBuilding> CityBuildings { get; set; }
        public DbSet<CityUpgrade> CityUpgrades { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<CityBuilding>()
            //    .HasKey(x => new { x.CityId, x.BuildingId });
            modelBuilder.Entity<CityBuilding>()
                .HasOne(cb => cb.City)
                .WithMany(c => c.CityBuildings)
                .HasForeignKey(cb => cb.CityId);
            modelBuilder.Entity<CityBuilding>()
                .HasOne(cb => cb.Building)
                .WithMany(b => b.CityBuildings)
                .HasForeignKey(cb => cb.BuildingId);


            //modelBuilder.Entity<CityUpgrade>()
            //    .HasKey(x => new { x.CityId, x.UpgradeId });
            modelBuilder.Entity<CityUpgrade>()
                .HasOne(cu => cu.City)
                .WithMany(u => u.CityUpgrades)
                .HasForeignKey(cu => cu.CityId);
            modelBuilder.Entity<CityUpgrade>()
                .HasOne(cu => cu.Upgrade)
                .WithMany(u => u.CityUpgrades)
                .HasForeignKey(cu => cu.UpgradeId);


            modelBuilder.Entity<CityArmy>()
                .HasOne(cu => cu.City)
                .WithMany(c => c.CityArmies)
                .HasForeignKey(cu => cu.CityId);
            modelBuilder.Entity<CityArmy>()
                .HasOne(ca => ca.Army)
                .WithOne()
                .HasForeignKey<CityArmy>(cu => cu.Id);


            //modelBuilder.Entity<CityUpgrade>()
            //    .HasOne(cu => cu.City)
            //    .WithOne(u => u.Upgrade)
            //    .HasForeignKey<CityUpgrade>(cu => cu.Id);
            //modelBuilder.Entity<CityUpgrade>()
            //    .HasOne(cu => cu.Upgrade)
            //    .WithMany()
            //    .HasForeignKey(cu => cu.Id);

            //modelBuilder.Entity<CityUnit>()
            //    .HasKey(x => new { x.CityId, x.UnitId });
            //modelBuilder.Entity<CityUnit>()
            //    .HasOne(cu => cu.City)
            //    .WithMany(u => u.CityUnits)
            //    .HasForeignKey(cu => cu.CityId);
            //modelBuilder.Entity<CityUnit>()
            //    .HasOne(cu => cu.Unit)
            //    .WithMany()
            //    .HasForeignKey(cu => cu.UnitId);

            //modelBuilder.Entity<CityArmy>()
            //    .HasKey(x => new { x.CityId, x.UnitId });
            //modelBuilder.Entity<CityArmy>()
            //    .HasOne(ca => ca.City)
            //    .WithMany(a => a.CityArmies)
            //    .HasForeignKey(ca => ca.CityId);
            //modelBuilder.Entity<CityArmy>()
            //    .HasOne(ca => ca.Unit)
            //    .WithOne()
            //    .HasForeignKey<CityArmy>(ca => ca.UnitId);

            modelBuilder.Entity<Building>()
                .HasData(
                    new Building { BuildingId = 1, Name = "áramlásirányító", Price = 1000, Grow_pop = 50, Grow_coral = 200, Space = 0 },
                    new Building { BuildingId = 2, Name = "zátonyvár", Price = 1000, Grow_pop = 0, Grow_coral = 0, Space = 200 }
                );

            modelBuilder.Entity<Unit>()
               .HasData(
                   new Unit { Id = 1, Name = "rohamfóka", Attack = 6, Defend = 2, Price = 50, Cost = 1, Food = 1 },
                   new Unit { Id = 2, Name = "csatacsikó", Attack = 2, Defend = 6, Price = 50, Cost = 1, Food = 1 },
                   new Unit { Id = 3, Name = "lézercápa", Attack = 5, Defend = 5, Price = 100, Cost = 3, Food = 2 }
                );

            modelBuilder.Entity<Upgrade>()
               .HasData(
                   new Upgrade { UpgradeId = 1, Name = "iszaptraktor", Coral = 10, Attack = 0, Defend = 0, Tax = 0 },
                   new Upgrade { UpgradeId = 2, Name = "iszapkombájn", Coral = 15, Attack = 0, Defend = 0, Tax = 0 },
                   new Upgrade { UpgradeId = 3, Name = "korallfal", Coral = 0, Attack = 0, Defend = 20, Tax = 0 },
                   new Upgrade { UpgradeId = 4, Name = "szonárágyú", Coral = 0, Attack = 20, Defend = 0, Tax = 0 },
                   new Upgrade { UpgradeId = 5, Name = "vízalatti harcművészetek", Coral = 0, Attack = 10, Defend = 10, Tax = 0 },
                   new Upgrade { UpgradeId = 6, Name = "alkímia", Coral = 0, Attack = 0, Defend = 0, Tax = 30 }
                );

        }

    }
}
