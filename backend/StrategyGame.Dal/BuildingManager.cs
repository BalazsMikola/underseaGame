using Microsoft.EntityFrameworkCore;
using StrategyGame.Dal;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StrategyGame.Model.DataManager
{
    public class BuildingManager : IBuildingDataRepository<Building>
    {
        readonly ApplicationDbContext _applicationDbContext;

        public BuildingManager(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<List<Building>> GetAll()
        {
            var buildings = await _applicationDbContext.Buildings.ToListAsync();
            return buildings;
        }
    }
}
