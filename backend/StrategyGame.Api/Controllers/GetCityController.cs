using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.Interface;
using StrategyGame.Bll.Services;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StrategyGame.Api.Controllers
{
    public class GetCityController : ControllerBase
    {
        private readonly IGetCityDbService _cityService;
        private UserManager<AppUser> userManager { get; }

        public GetCityController(IGetCityDbService cityService, UserManager<AppUser> userMgr)
        {
            _cityService = cityService;
            userManager = userMgr;
        }

        [Route("api/city")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtTokens.AuthSchemes)]
        public async Task<IActionResult> Get()
        {
            string jwt = Request.Headers["Authorization"];
            string userName = JwtTokenAppService.decodeTokenForUserName(jwt);
            var userData = await userManager.FindByNameAsync(userName);
            var cityData = await _cityService.GetCity(userData.City);
            return Ok(cityData);
        }
    }
}
