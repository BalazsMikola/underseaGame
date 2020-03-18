﻿using Microsoft.AspNetCore.Mvc;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Get()
        {
            IEnumerable<Building> buildings = await _dataRepository.GetAll();
            return Ok(buildings);
        }
    }
}
