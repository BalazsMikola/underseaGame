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

        public CreateCityDbService(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IdentityResult> CreateCity(string cityName)
        {
            var newCity = new City
            {
                Name = cityName,
                Population = 100,
                Pearl = 50,
                Coral = 20,
                Rank = 0
            };

            _applicationDbContext.Cities.Add(newCity);

            var success = await _applicationDbContext.SaveChangesAsync() > 0;

            if (!success)
            {
                return IdentityResult.Failed();
            }

            return IdentityResult.Success;
        }

    }
}
