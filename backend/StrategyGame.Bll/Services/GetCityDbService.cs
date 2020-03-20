using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.Interface;
using StrategyGame.Dal;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<City> GetCity(string userName)
        {
            var userData = await _applicationDbContext.Users.FindAsync(userName);

            return await _applicationDbContext.Cities.FindAsync(userData.City);

        }
    }
}
