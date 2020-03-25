using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.Interface;
using StrategyGame.Dal;
using StrategyGame.Model.DTOs;
using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class GetCityDbService : IGetCityDbService
    {
        readonly ApplicationDbContext _applicationDbContext;

        public GetCityDbService(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<CityDto> GetCity(string cityName)
        {
            City cityData = await _applicationDbContext.Cities
                .Where(city => city.Name == cityName)

                .Include(city => city.CityBuildings)
                .ThenInclude(building => building.Building)

                .Include(city => city.CityUpgrades)
                .ThenInclude(upgrade => upgrade.Upgrade)

                .Include(city => city.Armies)
                .ThenInclude(armies => armies.ArmyUnits)

                .SingleOrDefaultAsync();

            if (cityData != null)
            {
                return new CityDto
                {
                    Id = cityData.Id,
                    Name = cityData.Name,
                    Population = cityData.Population,
                    Pearl = cityData.Pearl,
                    Coral = cityData.Coral,
                    Rank = cityData.Rank,
                    CityBuildings =
                        cityData.CityBuildings.Select(x => new CityBuildingDto
                        {
                            BuildingId = x.BuildingId,
                            Number = x.Number,
                            RoundToFinish = x.RoundToFinish,
                            Building = new BuildingDto
                            {
                                Name = x.Building.Name,
                                Price = x.Building.Price,
                                Grow_coral = x.Building.Grow_coral,
                                Grow_pop = x.Building.Grow_pop,
                                Space = x.Building.Space
                            }
                        }).ToList()
                    ,
                    CityUpgrades =
                        cityData.CityUpgrades.Select(x => new CityUpgradesDto
                        {
                            CityId = x.CityId,
                            Number = x.Number,
                            RoundToFinish = x.RoundToFinish,
                            UpgradeId = x.UpgradeId,
                            Upgrade = new UpgradeDto
                            {
                                Name = x.Upgrade.Name,
                                Coral = x.Upgrade.Coral,
                                Defend = x.Upgrade.Defend,
                                Attack = x.Upgrade.Attack,
                                Tax = x.Upgrade.Tax
                            }
                        }).ToList()
                    ,
                    Armies = 
                        cityData.Armies.Select(x => new ArmyDto
                        {
                            CityId = x.CityId,
                            ArmyId = x.ArmyId,
                            EnemyCityId = x.EnemyCityId,
                            ArmyUnits = x.ArmyUnits.Select(y => new ArmyUnitDto 
                            { 
                                ArmyId = y.ArmyId,
                                Id = y.Id,
                                Number = y.Number,
                                UnitId = y.UnitId
                            })
                        }).ToList()
                };
            }
            else
            {
                return null;
            }

        }
    }
}
