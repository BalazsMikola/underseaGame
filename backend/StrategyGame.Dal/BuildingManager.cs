using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrategyGame.Dal;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;

namespace StrategyGame.Model.DataManager
{
    public class BuildingManager : IBuildingDataRepository<Building>
    {
        readonly ApplicationDbContext _applicationDbContext;

        public BuildingManager(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public IEnumerable<Building> GetAll()
        {
            return _applicationDbContext.Buildings.ToList();
        }


    }

}
