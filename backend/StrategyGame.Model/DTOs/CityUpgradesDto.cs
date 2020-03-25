using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.DTOs
{
    public class CityUpgradesDto
    {
        public int CityId { get; set; }

        public int UpgradeId { get; set; }
        public UpgradeDto Upgrade { get; set; }

        public int Number { get; set; }

        public int RoundToFinish { get; set; }
    }
}
