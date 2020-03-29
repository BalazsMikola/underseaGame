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
    public class BuyBuildingDbService: IBuyBuildingDbService
    {
        readonly ApplicationDbContext _applicationDbContext;

        public BuyBuildingDbService(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IdentityResult> BuyBuilding(int buildingId, int cityId)
        {

            var newMoneyService = new MoneyManagerAppService(_applicationDbContext);
            var result = await newMoneyService.checkMoneyForNewBuilding(buildingId, cityId);

            if (!result.Succeeded)
            {
                return IdentityResult.Failed(); //not enought money
            }
            else
            {
                var buildingRecord = await _applicationDbContext.CityBuildings
                    .Where(x => x.CityId == cityId && x.BuildingId == buildingId).SingleOrDefaultAsync();

                buildingRecord.RoundToFinish = 5;
                _applicationDbContext.CityBuildings.Update(buildingRecord);


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
