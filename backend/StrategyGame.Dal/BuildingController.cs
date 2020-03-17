using Microsoft.AspNetCore.Mvc;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Dal
{
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingDataRepository<Building> _dataRepository;

        public BuildingController(IBuildingDataRepository<Building> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [Route("api/buildings")]
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Building> buildings = _dataRepository.GetAll();
            return Ok(buildings);
        }
    }
}
