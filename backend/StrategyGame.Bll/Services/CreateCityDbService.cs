using StrategyGame.Dal;
using StrategyGame.Bll.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StrategyGame.Model.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Identity;

namespace StrategyGame.Bll.Services
{
    public class CreateCityDbService : ICreateCityDbService
    {
        readonly ApplicationDbContext _applicationDbContext;
        //private readonly IGetCityDbService _cityService;

        public CreateCityDbService(
            ApplicationDbContext context
            //IGetCityDbService cityService
        )
        {
            _applicationDbContext = context;
            //_cityService = cityService;
        }

        public async Task<IdentityResult> CreateCity(string cityName)
        {
            using (_applicationDbContext)
            {
                City newCity = new City
                {
                    Name = cityName,
                    Population = 100,
                    Pearl = 50,
                    Coral = 20,
                    Rank = 0
                };
                _applicationDbContext.Cities.Add(newCity);

                CityBuilding cityBuildingData1 = new CityBuilding
                {
                    CityId = newCity.CityId,
                    BuildingId = 1,
                    Number = 0,
                    RoundToFinish = 0,
                };
                _applicationDbContext.CityBuildings.Add(cityBuildingData1);

                CityBuilding cityBuildingData2 = new CityBuilding
                {
                    CityId = newCity.CityId,
                    BuildingId = 2,
                    Number = 0,
                    RoundToFinish = 0,
                };
                _applicationDbContext.CityBuildings.Add(cityBuildingData2);

                for (var i=1; i<=6; i++)
                {
                    CityUpgrade cityUpgradeData = new CityUpgrade
                    {
                        CityId = newCity.CityId,
                        UpgradeId = i,
                        Number = 0,
                        RoundToFinish = 0,
                    };
                    _applicationDbContext.CityUpgrades.Add(cityUpgradeData);
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
