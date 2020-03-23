using StrategyGame.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Interface
{
    public interface IGetUserDbService
    {
        Task<UserDto> GetUser(string userName);
    }
}
