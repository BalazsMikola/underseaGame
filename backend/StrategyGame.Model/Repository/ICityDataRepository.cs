using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Repository
{
    public interface ICityDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
