using Microsoft.AspNetCore.Mvc;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;
<<<<<<<< HEAD:backend/StrategyGame.Api/Controllers/BuildingController.cs
using StrategyGame.Bll.Interface;
using System.Collections.Generic;
using System.Text;
========
using System.Collections.Generic;
>>>>>>>> 4337e8e276c07692a0b94b80121bf3917e9dcd33:backend/StrategyGame.Dal/BuildingController.cs
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
