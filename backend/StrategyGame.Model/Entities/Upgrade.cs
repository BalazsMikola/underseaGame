using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Model.Entities
{
    public class Upgrade
    {
        public int UpgradeId { get; set; }

        public string Name { get; set; }

        public int Coral { get; set; }

        public int Defend { get; set; }

        public int Attack { get; set; }

        public int Tax { get; set; }

        public virtual ICollection<CityUpgrade> CityUpgrades { get; set; }

    }
}
