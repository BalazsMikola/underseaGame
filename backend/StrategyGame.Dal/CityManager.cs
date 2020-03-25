using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrategyGame.Dal;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;

namespace StrategyGame.Model.DataManager
{
    public class CityManager : ICityDataRepository<City>
    {
        readonly ApplicationDbContext _applicationDbContext;

        public CityManager(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public IEnumerable<City> GetAll()
        {
            return _applicationDbContext.Cities.ToList();
        }

        public City Get(long id)
        {
            return _applicationDbContext.Cities
                  .FirstOrDefault(e => e.Id == id);
        }

        public void Add(City entity)
        {
            _applicationDbContext.Cities.Add(entity);
            _applicationDbContext.SaveChanges();
        }

        public void Update(City city, City entity)
        {
            city.Name = entity.Name;
            city.Population = entity.Population;
            city.Pearl = entity.Pearl;
            city.Coral = entity.Coral;
            city.Rank = entity.Rank;

            _applicationDbContext.SaveChanges();
        }

        public void Delete(City employee)
        {
            _applicationDbContext.Cities.Remove(employee);
            _applicationDbContext.SaveChanges();
        }

    }
}
