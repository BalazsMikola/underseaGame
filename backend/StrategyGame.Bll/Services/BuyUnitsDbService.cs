using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.Interface;
using StrategyGame.Dal;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class BuyUnitsDbService: IBuyUnitsDbService
    {
        readonly ApplicationDbContext _applicationDbContext;

        public BuyUnitsDbService(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IdentityResult> BuyUnits(List<int> amountOfNewUnits, int cityId)
        {

            var newMoneyService = new MoneyManagerAppService(_applicationDbContext);
            var result = await newMoneyService.checkMoneyForNewUnits(amountOfNewUnits, cityId);

            if (!result.Succeeded)
            {
                return IdentityResult.Failed(); //not enought money
            }
            else
            {
                var army = await _applicationDbContext.Armies
                    .Where(x => x.CityId == cityId && x.EnemyCityId == null).SingleOrDefaultAsync();

                var armyRecords = _applicationDbContext.ArmyUnits.Where(x => x.ArmyId == army.ArmyId).ToList();

                for (var i = 0; i < armyRecords.Count(); i++)
                {
                    armyRecords[i].UnitId = i+1;
                    armyRecords[i].Number += amountOfNewUnits[i];
                    armyRecords[i].ArmyId = army.ArmyId;
                    _applicationDbContext.ArmyUnits.Update(armyRecords[i]);
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
