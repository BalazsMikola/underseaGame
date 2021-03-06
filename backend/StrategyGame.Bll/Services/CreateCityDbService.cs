﻿using StrategyGame.Dal;
using StrategyGame.Bll.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StrategyGame.Model.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Identity;
using StrategyGame.Model.Enums;
using System.Linq;

namespace StrategyGame.Bll.Services
{
    public class CreateCityDbService : ICreateCityDbService
    {
        readonly ApplicationDbContext _applicationDbContext;

        public CreateCityDbService(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IdentityResult> CreateCity(string cityName)
        {
            using (_applicationDbContext)
            {
                City newCity = new City
                {
                    Name = cityName,
                    Population = 1000,
                    Pearl = 10000,
                    Coral = 10000,
                    Rank = 0
                };
                _applicationDbContext.Cities.Add(newCity);

                CityBuilding cityBuildingData1 = new CityBuilding
                {
                    CityId = newCity.Id,
                    BuildingId = (int)BuildingTypeEnum.Aramlasiranyito,
                    Number = 0,
                    RoundToFinish = 0,
                };
                _applicationDbContext.CityBuildings.Add(cityBuildingData1);

                CityBuilding cityBuildingData2 = new CityBuilding
                {
                    CityId = newCity.Id,
                    BuildingId = (int)BuildingTypeEnum.Zatonyvar,
                    Number = 0,
                    RoundToFinish = 0,
                };
                _applicationDbContext.CityBuildings.Add(cityBuildingData2);

                for (var i=1; i<=6; i++)
                {
                    CityUpgrade cityUpgradeData = new CityUpgrade
                    {
                        CityId = newCity.Id,
                        UpgradeId = i,
                        Number = 0,
                        RoundToFinish = 0,
                    };
                    _applicationDbContext.CityUpgrades.Add(cityUpgradeData);
                }

                var newArmyid = (_applicationDbContext.Armies
                    .Select(a => a.ArmyId).DefaultIfEmpty(0).Max()) + 1;

                var cityArmy = new Army
                {
                    CityId = newCity.Id,
                    ArmyId = newArmyid,
                    EnemyCityId = null,
                };
                _applicationDbContext.Armies.Add(cityArmy);
                await _applicationDbContext.SaveChangesAsync();

                for (var i = 1; i <= 3; i++)
                {
                    var Units = new ArmyUnit
                    {
                        UnitId = i,
                        Number = 0,
                        ArmyId = newArmyid,
                    };
                    _applicationDbContext.ArmyUnits.Add(Units);
                }

                var success = await _applicationDbContext.SaveChangesAsync() > 0;
  
                if (!success)
                {
                    return IdentityResult.Failed();
                }

                return IdentityResult.Success;

            }
        }

    }
}
