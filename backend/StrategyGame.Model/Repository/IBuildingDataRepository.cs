using System.Collections.Generic;
using System.Threading.Tasks;

namespace StrategyGame.Model.Repository
{
    public interface IBuildingDataRepository<TEntity>
    {
        Task<List<TEntity>> GetAll();

    }
}
