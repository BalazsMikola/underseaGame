using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.Interface;
using StrategyGame.Model.Identity;
using System;
using System.Threading.Tasks;

namespace StrategyGame.Api.Controllers
{
    public class RegisterController : ControllerBase
    {

        private readonly ICreateCityDbService _dataRepository;
        private readonly IGetCityDbService _cityService;
        private UserManager<AppUser> userManager { get; }
        public RegisterController(
            UserManager<AppUser> userMgr,
            ICreateCityDbService dataRepository,
            IGetCityDbService cityService
            )
        {
            userManager = userMgr;
            _dataRepository = dataRepository;
            _cityService = cityService;
        }

        [Route("api/register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
           
            var userExists = await userManager.FindByNameAsync(model.User);
            if (userExists != null)
            {
                return BadRequest("user already exists");
            }
            
            var cityExists = await _cityService.GetCity(model.City);
            if (cityExists != null)
            {
                return BadRequest("city name already exists");
            }

            AppUser newUser = new AppUser()
            {
                UserName = model.User,
                City = model.City
            };

            var result = await userManager.CreateAsync(newUser, model.Password);
            if (result.Succeeded)
            {
                IdentityResult InitialCityData = await _dataRepository.CreateCity(model.City);
                if (!InitialCityData.Succeeded)
                {
                    return BadRequest("Internal error! Can not create new user");
                }
                return Ok();
            }
            else
            {
                return BadRequest("Password must contain at leaset one Uppercase letter and one non-alphanumeric character!");
            }

        }

    }
}
