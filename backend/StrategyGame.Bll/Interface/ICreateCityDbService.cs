using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Interface
{
    public interface ICreateCityDbService
    {
        Task<IdentityResult> CreateCity(string cityName);

    }
}
