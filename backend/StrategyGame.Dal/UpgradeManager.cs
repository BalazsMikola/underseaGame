using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrategyGame.Dal;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;

namespace StrategyGame.Model.DataManager
{
    public class UpgradeManager : IUpgradeDataRepository<Upgrade>
    {
        readonly ApplicationDbContext _applicationDbContext;

        public UpgradeManager(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public IEnumerable<Upgrade> GetAll()
        {
            return _applicationDbContext.Upgrades.ToList();
        }


    }
}
