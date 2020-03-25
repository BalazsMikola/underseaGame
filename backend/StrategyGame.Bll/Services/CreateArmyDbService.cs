using Microsoft.AspNetCore.Identity;
using StrategyGame.Bll.Interface;
using StrategyGame.Dal;
using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class CreateArmyDbService : ICreateArmyDbService
    {
        readonly ApplicationDbContext _applicationDbContext;

        public CreateArmyDbService(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IdentityResult> CreateArmy(object newArmy, int cityId)
        {

            var newArmyid = (_applicationDbContext.ArmyUnits
                .Select(a => a.ArmyId).DefaultIfEmpty(0).Max()) + 1;

            var armyUnit = new ArmyUnit
            {
                UnitId = 1,
                Number = 5,
                ArmyId = 117
            };
            _applicationDbContext.ArmyUnits.Add(armyUnit);

            var success = await _applicationDbContext.SaveChangesAsync() > 0;

            if (!success)
            {
                return IdentityResult.Failed();
            }

            return IdentityResult.Success;
        } 

    }
}

