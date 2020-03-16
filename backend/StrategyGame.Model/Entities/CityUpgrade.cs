using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Model.Entities
{
    public class CityUpgrade
    {
        public int Id { get; set; }

        public City City { get; set; }

        public Upgrade Upgrade { get; set; }

        public int RoundToFinish { get; set; }
    }
}
