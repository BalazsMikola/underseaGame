using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Repository
{
    public interface IUnitDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

    }
}
