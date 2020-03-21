﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StrategyGame.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Model.Identity;

namespace StrategyGame.Bll.Interface
{
    public interface IGetCityDbService
    {
        Task<City> GetCity(string cityName);
    }
}
