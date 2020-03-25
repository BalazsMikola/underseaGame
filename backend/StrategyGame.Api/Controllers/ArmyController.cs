using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.Interface;
using StrategyGame.Bll.Services;
using StrategyGame.Dal;
using StrategyGame.Model.DTOs;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Identity;
using StrategyGame.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Api.Controllers
{
    public class ArmyController : ControllerBase
    {
        readonly ApplicationDbContext _applicationDbContext;

        private readonly ICreateArmyDbService _dataRepository;

        private readonly IGetCityDbService _cityService;
        private UserManager<AppUser> userManager { get; }

        public ArmyController(
            ApplicationDbContext context,
            ICreateArmyDbService dataRepository,
            IGetCityDbService cityService,
            UserManager<AppUser> userMgr
        )
        {
            _applicationDbContext = context;
            _dataRepository = dataRepository;
            _cityService = cityService;
            userManager = userMgr;
        }

        [Route("api/addarmy")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtTokens.AuthSchemes)]

        public async Task<IActionResult> CreateArmy(object newArmy)
        {
            string jwt = Request.Headers["Authorization"];
            string userName = JwtTokenAppService.decodeTokenForUserName(jwt);
            var userData = await userManager.FindByNameAsync(userName);
            var cityData = await _cityService.GetCity(userData.City);

            var result = await _dataRepository.CreateArmy(newArmy, cityData.Id);

            if (!result.Succeeded)
            {
                return BadRequest("Internal error! Can not create new army");
            }
            return Ok();

        }
    }
}
