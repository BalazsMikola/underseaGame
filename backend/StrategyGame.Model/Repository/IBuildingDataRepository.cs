using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Repository
{
    public interface IBuildingDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

    }
}
