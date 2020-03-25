using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Enums;
using StrategyGame.Model.Identity;

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
        public DbSet<ArmyUnit> ArmyUnits { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Building>()
                .HasMany(cb => cb.CityBuildings)
                .WithOne(b => b.Building)
                .HasForeignKey(cb => cb.BuildingId);

            modelBuilder.Entity<City>()
                .HasMany(cu => cu.CityUpgrades)
                .WithOne(u => u.City)
                .HasForeignKey(cu => cu.CityId);

            modelBuilder.Entity<City>()
                .HasMany(cb => cb.CityBuildings)
                .WithOne(c => c.City)
                .HasForeignKey(cb => cb.CityId);

            modelBuilder.Entity<City>()
                .HasMany(cu => cu.Armies)
                .WithOne(c => c.City)
                .HasForeignKey(cu => cu.CityId);

            modelBuilder.Entity<Upgrade>()
                .HasMany(cu => cu.CityUpgrades)
                .WithOne(u => u.Upgrade)
                .HasForeignKey(cu => cu.UpgradeId);

            modelBuilder.Entity<Army>()
                .HasMany(cu => cu.ArmyUnits)
                .WithOne(u => u.Army)
                .HasForeignKey(cu => cu.ArmyId);


            modelBuilder.Entity<Building>()
                .HasData(
                    new Building { Id = (int)BuildingTypeEnum.Aramlasiranyito, Name = "áramlásirányító", Price = 1000, Grow_pop = 50, Grow_coral = 200, Space = 0 },
                    new Building { Id = (int)BuildingTypeEnum.Zatonyvar, Name = "zátonyvár", Price = 1000, Grow_pop = 0, Grow_coral = 0, Space = 200 }
                );

            modelBuilder.Entity<Unit>()
               .HasData(
                   new Unit { Id = 1, Name = "rohamfóka", Attack = 6, Defend = 2, Price = 50, Cost = 1, Food = 1 },
                   new Unit { Id = 2, Name = "csatacsikó", Attack = 2, Defend = 6, Price = 50, Cost = 1, Food = 1 },
                   new Unit { Id = 3, Name = "lézercápa", Attack = 5, Defend = 5, Price = 100, Cost = 3, Food = 2 }
                );

            modelBuilder.Entity<Upgrade>()
               .HasData(
                   new Upgrade { Id = 1, Name = "iszaptraktor", Coral = 10, Attack = 0, Defend = 0, Tax = 0 },
                   new Upgrade { Id = 2, Name = "iszapkombájn", Coral = 15, Attack = 0, Defend = 0, Tax = 0 },
                   new Upgrade { Id = 3, Name = "korallfal", Coral = 0, Attack = 0, Defend = 20, Tax = 0 },
                   new Upgrade { Id = 4, Name = "szonárágyú", Coral = 0, Attack = 20, Defend = 0, Tax = 0 },
                   new Upgrade { Id = 5, Name = "vízalatti harcművészetek", Coral = 0, Attack = 10, Defend = 10, Tax = 0 },
                   new Upgrade { Id = 6, Name = "alkímia", Coral = 0, Attack = 0, Defend = 0, Tax = 30 }
                );

        }

    }
}
