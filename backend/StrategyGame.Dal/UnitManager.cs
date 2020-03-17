using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrategyGame.Dal;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;

namespace StrategyGame.Model.DataManager
{
    public class UnitManager : IUnitDataRepository<Unit>
    {
        readonly ApplicationDbContext _applicationDbContext;

        public UnitManager(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public IEnumerable<Unit> GetAll()
        {
            return _applicationDbContext.Units.ToList();
        }


    }
}
