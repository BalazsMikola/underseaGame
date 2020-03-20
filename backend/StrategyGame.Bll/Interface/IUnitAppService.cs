﻿using StrategyGame.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Interface
{
    public interface IUnitAppService
    {
        Task<List<Unit>> GetAll();
    }
}
