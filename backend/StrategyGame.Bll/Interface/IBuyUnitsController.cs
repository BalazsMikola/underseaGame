using Microsoft.AspNetCore.Identity;
using StrategyGame.Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Interface
{
    public interface IBuyUnitService
    {
        Task<IdentityResult> BuyUnits(NewUnitsModel units, int cityId);

    }
}
