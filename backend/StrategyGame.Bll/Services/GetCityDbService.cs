using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.Interface;
using StrategyGame.Dal;
using StrategyGame.Model.DTOs;
using StrategyGame.Model.Entities;
using System;
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

                .Include(city => city.CityArmies)
                .SingleOrDefaultAsync();

            if (cityData != null)
            {
                return new CityDto
                {
                    Name = cityData.Name,
                    Population = cityData.Population,
                    Pearl = cityData.Pearl,
                    Coral = cityData.Coral,
                    Rank = cityData.Rank,
                    CityBuildings = cityData.CityBuildings,
                    CityUpgrades = cityData.CityUpgrades,
                    CityArmies = cityData.CityArmies
                };

            }
            else
            {
                return null;
            }

        }
    }
}
