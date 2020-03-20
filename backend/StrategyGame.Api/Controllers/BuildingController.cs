using Microsoft.AspNetCore.Mvc;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;
using StrategyGame.Bll.Interface;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Api.Controllers
{
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingAppService _dataRepository;

        public BuildingController(IBuildingAppService dataRepository)
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
