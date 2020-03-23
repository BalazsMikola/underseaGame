using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Model.Identity;
using StrategyGame.Bll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StrategyGame.Bll.Interface;
using StrategyGame.Model.Entities;
using Microsoft.AspNetCore.Authorization;

namespace StrategyGame.Api.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly IGetCityDbService _dataRepository;
        private SignInManager<AppUser> signInManager { get; }
        private UserManager<AppUser> userManager { get; }

        public LoginController(SignInManager<AppUser> signInMgr, UserManager<AppUser> userMgr, IGetCityDbService dataRepository)
        {
            signInManager = signInMgr;
            userManager = userMgr;
            _dataRepository = dataRepository;
        }

        [Route("api/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            
            var result = await signInManager.PasswordSignInAsync(model.User, model.Password, true, false);

            if (result.Succeeded)
            {
                var jwt = JwtTokenAppService.CreateToken(model);

                return Ok(jwt);
            }

            return Unauthorized("Invalid username or password!");

        }

    }
}
