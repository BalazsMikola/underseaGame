using Microsoft.EntityFrameworkCore;
using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Dal
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<City> Cities { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Upgrade> Upgrades { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Rounds> Rounds { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<CityBuilding>()
                .HasOne(cb => cb.City)
                .WithMany(b => b.CityBuildings)
                .HasForeignKey(cb => cb.Id);
            modelBuilder.Entity<CityBuilding>()
                .HasOne(cb => cb.Building)
                .WithMany(b => b.CityBuildings)
                .HasForeignKey(cb => cb.Id);


            modelBuilder.Entity<CityUpgrade>()
                .HasOne(cu => cu.City)
                .WithOne(u => u.Upgrade)
                .HasForeignKey<CityUpgrade>(cu => cu.Id);
            modelBuilder.Entity<CityUpgrade>()
                .HasOne(cu => cu.Upgrade)
                .WithMany()
                .HasForeignKey(cu => cu.Id);


            modelBuilder.Entity<CityUnit>()
                .HasOne(cu => cu.City)
                .WithMany(u => u.CityUnits)
                .HasForeignKey(cu => cu.Id);
            modelBuilder.Entity<CityUnit>()
                .HasOne(cu => cu.Unit)
                .WithMany()
                .HasForeignKey(cu => cu.Id);


            modelBuilder.Entity<CityArmy>()
                .HasOne(ca => ca.City)
                .WithMany(a => a.CityArmies)
                .HasForeignKey(ca => ca.Id);
            modelBuilder.Entity<CityArmy>()
                .HasOne(ca => ca.Unit)
                .WithOne(u => u.Army)
                .HasForeignKey<CityArmy>(ca => ca.Id);
        }

    }
}
