﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Model.Entities
{
    public class CityBuilding
    {
        public int Id { get; set; }

        public City City { get; set; }

        public Building Building { get; set; }

        public int Number { get; set; }

        public int RoundToFinish { get; set; }

    }
}
