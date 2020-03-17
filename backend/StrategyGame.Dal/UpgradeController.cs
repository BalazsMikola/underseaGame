using Microsoft.AspNetCore.Mvc;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Dal
{
    public class UpgradeController : ControllerBase
    {
        private readonly IUpgradeDataRepository<Upgrade> _dataRepository;

        public UpgradeController(IUpgradeDataRepository<Upgrade> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [Route("api/upgrades")]
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Upgrade> upgrades = _dataRepository.GetAll();
            return Ok(upgrades);
        }
    }
}
