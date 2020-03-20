using StrategyGame.Bll.Interface;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class BuildingsAppSerice : IBuildingsAppSerice
    {
        private readonly IBuildingDataRepository<Building> _dataRepository;

        public BuildingsAppSerice(IBuildingDataRepository<Building> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<IEnumerable<Building>> Get()
        {
            IEnumerable<Building> buildings = await _dataRepository.GetAll();
            return buildings;
        }
    }
}
