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

        [Route("api/city/{id}")]
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            City City = _dataRepository.Get(id);

            if (City == null)
            {
                return NotFound("The City record couldn't be found.");
            }

            return Ok(City);
        }

        [Route("api/city")]
        [HttpPost]
        public IActionResult Post([FromBody] City City)
        {
            if (City == null)
            {
                return BadRequest("City is null.");
            }

            _dataRepository.Add(City);
            return CreatedAtRoute("Get", new { Id = City.CityId }, City);
        }

    }
}
