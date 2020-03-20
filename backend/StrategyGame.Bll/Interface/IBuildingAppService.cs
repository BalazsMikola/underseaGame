using StrategyGame.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Interface
{
    public interface IBuildingAppService
    {
        Task<List<Building>> GetAll();
    }
}
