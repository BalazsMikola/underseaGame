using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.Interface;
using StrategyGame.Dal;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class UpgradeAppService : IUpgradeAppService
    {
        readonly ApplicationDbContext _applicationDbContext;

        public UpgradeAppService(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<List<Upgrade>> GetAll()
        {
            var upgrades = await _applicationDbContext.Upgrades.ToListAsync();
            return upgrades;
        }
    }
}
