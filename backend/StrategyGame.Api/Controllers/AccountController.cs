using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StrategyGame.Model.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Api.Controllers
{ 
    public class AccountController : Controller
    {   
        private UserManager<AppUser> userManager { get; }
        private SignInManager<AppUser> signInManager { get; }

        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signInMgr) 
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        //[Route("api/register")]
        ////[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> Register([FromBody] AppUserModel model)
        //{
        //    var newUser = new AppUser()
        //    {
        //        UserName = model.User,
        //        City = model.City
        //    };
            
        //    try
        //    {
        //        var result = await userManager.CreateAsync(newUser, model.Password);
        //        return Ok(result);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}

        //[Route("api/login")]
        ////[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> Login([FromBody] LoginModel model)
        //{
        //    var result = await signInManager.PasswordSignInAsync(model.User, model.Password, true, false);

        //    if (result.Succeeded)
        //    {
        //        //create token
        //        //collect city data
        //        //put together
        //        //return data
        //        var jwt = this.CreateToken(model);

        //        return Ok(jwt);
        //    }
            
        //    return Unauthorized();

        //}

        //public object CreateToken(LoginModel model)
        //{
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokens.Key));
        //    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //    var claims = new[]
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, model.User),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        new Claim(JwtRegisteredClaimNames.UniqueName, model.User),
        //    };
        //    var token = new JwtSecurityToken(
        //        JwtTokens.Issuer,
        //        JwtTokens.Audience,
        //        claims,
        //        expires: DateTime.UtcNow.AddMinutes(30),
        //        signingCredentials: credentials
        //    );
        //    var result = new
        //    {
        //        token = new JwtSecurityTokenHandler().WriteToken(token),
        //        expiration = token.ValidTo
        //    };
        //    return result;

        //}

        //[Route("api/createtoken")]
        //[HttpPost]
        //public async Task<IActionResult> CreateToken([FromBody] JwtTokenModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await userManager.FindByNameAsync(model.User);
        //        var signInResult = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        //        if (signInResult.Succeeded)
        //        {
        //            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokens.Key));
        //            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //            var claims = new[]
        //            {
        //                new Claim(JwtRegisteredClaimNames.Sub, model.User),
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //                new Claim(JwtRegisteredClaimNames.UniqueName, model.User),
        //            };
        //            var token = new JwtSecurityToken(
        //                    JwtTokens.Issuer,
        //                    JwtTokens.Audience,
        //                    claims,
        //                    expires: DateTime.UtcNow.AddMinutes(30),
        //                    signingCredentials: credentials
        //                );
        //            var result = new
        //            {
        //                token = new JwtSecurityTokenHandler().WriteToken(token),
        //                expiration = token.ValidTo
        //            };

        //            return Created("", result);
        //            //return Unauthorized();
        //            //return Ok(new { });
        //        }

        //    }

        //    return BadRequest();
        //}
    }
}
