using Microsoft.AspNetCore.Mvc;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Dal
{
    public class UnitController : ControllerBase
    {
        private readonly IUnitDataRepository<Unit> _dataRepository;

        public UnitController(IUnitDataRepository<Unit> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [Route("api/units")]
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Unit> units = _dataRepository.GetAll();
            return Ok(units);
        }
    }
}