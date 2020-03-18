using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.Interface;

namespace StrategyGame.Dal
{
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingsAppSerice buildingsAppSerice;

        public BuildingController(IBuildingsAppSerice buildingsAppSerice)
        {
            this.buildingsAppSerice = buildingsAppSerice;
        }

        [Route("api/buildings")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(buildingsAppSerice.Get());
        }
    }
}
