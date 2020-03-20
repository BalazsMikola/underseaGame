using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.Interface;
using StrategyGame.Dal;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace StrategyGame.Bll.Services
{
    public class BuildingAppService : IBuildingAppService
    {
        readonly ApplicationDbContext _applicationDbContext;

        public BuildingAppService(ApplicationDbContext context)
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
