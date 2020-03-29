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
    public class StartUpgradeController : ControllerBase
    {
        private readonly IStartUpgradeDbService _dataRepository;

        private readonly IGetCityDbService _cityService;
        private UserManager<AppUser> userManager { get; }

        public StartUpgradeController(
            IStartUpgradeDbService dataRepository,
            IGetCityDbService cityService,
            UserManager<AppUser> userMgr
        )
        {
            _dataRepository = dataRepository;
            _cityService = cityService;
            userManager = userMgr;
        }

        [Route("api/startupgrade")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtTokens.AuthSchemes)]

        public async Task<IActionResult> StartUpgrade([FromBody]newUpgradeModel newUpgrade)
        {

            string jwt = Request.Headers["Authorization"];
            string userName = JwtTokenAppService.decodeTokenForUserName(jwt);
            var userData = await userManager.FindByNameAsync(userName);
            var cityData = await _cityService.GetCity(userData.City);


            var result = await _dataRepository.StartUpgrade(newUpgrade.UpgradeId, cityData.Id);

            if (!result.Succeeded)
            {
                return BadRequest("Internal error! Can not start new research");
            }
            return Ok();


        }
    
    }
}
