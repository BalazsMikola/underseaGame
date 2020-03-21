using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.Interface;
using StrategyGame.Dal;
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

        public async Task<City> GetCity(string cityName)
        {
            return await _applicationDbContext.Cities
                .Where(city => city.Name == cityName)
                .Include(city => city.CityBuildings)
                .ThenInclude(building => building.Building)
                .SingleOrDefaultAsync();
        }
    }
}
