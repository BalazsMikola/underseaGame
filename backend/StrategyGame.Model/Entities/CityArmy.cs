using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class CityArmy
    {
        public int Id { get; set; }
        public int CityId { get; set; }

        public int ArmyNumber { get; set; }

        public City City { get; set; }

        public Army Army { get; set; }

        public int EnemyId { get; set; }
    }
}
