﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Model.Entities
{
    public class CityUpgrade : Entity
    {
        public int CityId { get; set; }
        public City City { get; set; }

        public int UpgradeId { get; set; }
        public Upgrade Upgrade { get; set; }

        public int Number { get; set; }

        public int RoundToFinish { get; set; }
    }
}
