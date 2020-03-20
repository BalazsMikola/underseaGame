using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.Interface;
using StrategyGame.Dal;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class UnitAppService : IUnitAppService
    {
        readonly ApplicationDbContext _applicationDbContext;

        public UnitAppService(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<List<Unit>> GetAll()
        {
            var units = await _applicationDbContext.Units.ToListAsync();
            return units;
        }
    }
}
