using Microsoft.AspNetCore.Mvc;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;
using StrategyGame.Bll.Interface;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Api.Controllers
{
    public class UnitController : ControllerBase
    {
        private readonly IUnitAppService _dataRepository;

        public UnitController(IUnitAppService dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [Route("api/units")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Unit> units = await _dataRepository.GetAll();
            return Ok(units);
        }
    }
}