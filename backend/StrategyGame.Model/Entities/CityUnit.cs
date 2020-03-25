using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class CityUpgrades : Entity
    {
        public int CityId { get; set; }

        public int UnitId { get; set; }

        public City City { get; set; }

        public Unit Unit { get; set; }

        public int Number { get; set; }
    }
}
