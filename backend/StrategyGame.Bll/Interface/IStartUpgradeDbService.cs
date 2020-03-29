using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Interface
{
    public interface IStartUpgradeDbService
    {
        Task<IdentityResult> StartUpgrade(int upgradeId, int cityId);
    }
}
