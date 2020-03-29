using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.Interface;
using StrategyGame.Bll.Services;
using StrategyGame.Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Api.Controllers
{
    public class BuyBuildingController : ControllerBase
    {
        private readonly IBuyBuildingDbService _dataRepository;

        private readonly IGetCityDbService _cityService;
        private UserManager<AppUser> userManager { get; }

        public BuyBuildingController(
            IBuyBuildingDbService dataRepository,
            IGetCityDbService cityService,
            UserManager<AppUser> userMgr
        )
        {
            _dataRepository = dataRepository;
            _cityService = cityService;
            userManager = userMgr;
        }

        [Route("api/buybuilding")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtTokens.AuthSchemes)]

        public async Task<IActionResult> BuyBuilding([FromBody]newBuildingModel newbuilding)
        {

            string jwt = Request.Headers["Authorization"];
            string userName = JwtTokenAppService.decodeTokenForUserName(jwt);
            var userData = await userManager.FindByNameAsync(userName);
            var cityData = await _cityService.GetCity(userData.City);

            var result = await _dataRepository.BuyBuilding(newbuilding.BuildingId, cityData.Id);

            if (!result.Succeeded)
            {
                return BadRequest("Internal error! Can not buy new building");
            }
            return Ok();


        }

    }
}
