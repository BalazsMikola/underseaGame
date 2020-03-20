using Microsoft.AspNetCore.Mvc;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;
using StrategyGame.Bll.Interface;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Api.Controllers
{
    public class UpgradeController : ControllerBase
    {
        private readonly IUpgradeAppService _dataRepository;

        public UpgradeController(IUpgradeAppService dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [Route("api/upgrades")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Upgrade> upgrades = await _dataRepository.GetAll();
            return Ok(upgrades);
        }
    }
}
