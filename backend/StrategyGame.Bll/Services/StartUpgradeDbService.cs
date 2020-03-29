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
    public class StartUpgradeDbService: IStartUpgradeDbService
    {
        readonly ApplicationDbContext _applicationDbContext;

        public StartUpgradeDbService(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IdentityResult> StartUpgrade(int upgradegId, int cityId)
        {

            var newMoneyService = new MoneyManagerAppService(_applicationDbContext);
            var result = await newMoneyService.checkAvailabilityForNewUpgrade(upgradegId, cityId);

            if (!result.Succeeded)
            {
                return IdentityResult.Failed(); //aready runnung a research
            }
            else
            {
                var upgradeRecord = await _applicationDbContext.CityUpgrades
                    .Where(x => x.CityId == cityId && x.UpgradeId == upgradegId).SingleOrDefaultAsync();

                upgradeRecord.RoundToFinish = 15;
                _applicationDbContext.CityUpgrades.Update(upgradeRecord);


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
