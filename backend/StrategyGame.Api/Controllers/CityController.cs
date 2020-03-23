using Microsoft.AspNetCore.Mvc;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Api.Controllers
{
    public class CityController : ControllerBase
    {
        private readonly ICityDataRepository<City> _dataRepository;

        public CityController(ICityDataRepository<City> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [Route("api/cities")]
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<City> Cities = _dataRepository.GetAll();
            return Ok(Cities);
        }


    }
}
