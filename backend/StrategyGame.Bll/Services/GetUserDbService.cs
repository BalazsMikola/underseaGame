using Microsoft.AspNetCore.Identity;
using StrategyGame.Bll.Interface;
using StrategyGame.Model.DTOs;
using StrategyGame.Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class GetUserDbService : IGetUserDbService
    {
        private UserManager<AppUser> userManager { get; }

        public GetUserDbService(UserManager<AppUser> userMgr)
        {
            userManager = userMgr;
        }

        public async Task<UserDto> GetUser(string userName)
        {
            AppUser userData = await userManager.FindByNameAsync(userName);
            return new UserDto
            {
                Id = userData.Id,
                UserName = userData.UserName,
                City = userData.City
            };
        }
    }
}
