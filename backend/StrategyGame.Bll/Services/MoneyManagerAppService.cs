using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.Interface;
using StrategyGame.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class MoneyManagerAppService
    {
        readonly ApplicationDbContext _applicationDbContext;

        public MoneyManagerAppService(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IdentityResult> checkMoneyForNewUnits(List<int> amountOfNewUnits, int cityId)
        {
            var availablePearl = await _applicationDbContext.Cities
                .Where(x => x.Id == cityId).Select(x => x.Pearl).SingleOrDefaultAsync();

            var listOfUnitPrices = await _applicationDbContext.Units.Select(x => x.Price).ToListAsync();

            var costOfAllUnits = 0;
            for (var i = 0; i < amountOfNewUnits.Count(); i++)
            {
                costOfAllUnits += amountOfNewUnits[i] * listOfUnitPrices[i];
            }

            if(availablePearl >= costOfAllUnits)
            {
                var currentCity = await _applicationDbContext.Cities.Where(x => x.Id == cityId).SingleOrDefaultAsync();
                currentCity.Pearl -= costOfAllUnits;
                _applicationDbContext.Cities.Update(currentCity);

                await _applicationDbContext.SaveChangesAsync();
                return IdentityResult.Success;
            }
            else
            {
                return IdentityResult.Failed();
            }
        }
        public async Task<IdentityResult> checkMoneyForNewBuilding(int buildingId, int cityId)
        {

            var cityBuildingsList = await _applicationDbContext.CityBuildings.Where(x => x.CityId == cityId).ToListAsync();
            var underConstruction = cityBuildingsList.Where(x => x.RoundToFinish != 0).Select(y => y.RoundToFinish).SingleOrDefault();

            if(underConstruction != 0)
            {
                return IdentityResult.Failed(); //one of the buildings is under construction 
            }

            var availablePearl = await _applicationDbContext.Cities
                .Where(x => x.Id == cityId).Select(x => x.Pearl).SingleOrDefaultAsync();

            var priceOfBuilding = await _applicationDbContext.Buildings.Where(x => x.Id == buildingId).Select(y => y.Price).SingleOrDefaultAsync();

            if(availablePearl >= priceOfBuilding)
            {
                var currentCity = await _applicationDbContext.Cities.Where(x => x.Id == cityId).SingleOrDefaultAsync();
                currentCity.Pearl -= priceOfBuilding;
                _applicationDbContext.Cities.Update(currentCity);

                await _applicationDbContext.SaveChangesAsync();
                return IdentityResult.Success;

            }
            else
            {
                return IdentityResult.Failed();
            }

        }

        public async Task<IdentityResult> checkAvailabilityForNewUpgrade(int upgradeId, int cityId)
        {
            var cityUpgradesList = await _applicationDbContext.CityUpgrades.Where(x => x.CityId == cityId).ToListAsync();
            var underResearch = cityUpgradesList.Where(x => x.RoundToFinish != 0).Select(y => y.RoundToFinish).SingleOrDefault();

            if (underResearch != 0)
            {
                return IdentityResult.Failed(); //one of the upgrades is under research 
            }
            else
            {
                return IdentityResult.Success;
            }

        }

    }
}
