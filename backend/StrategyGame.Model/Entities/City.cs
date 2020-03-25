using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Model.Entities
{
    public class City : Entity
    {
        public string Name { get; set; }

        public int Population { get; set; }

        public int Pearl { get; set; }

        public int Coral { get; set; }

        public int Rank { get; set; }

        public virtual ICollection<CityBuilding> CityBuildings { get; set; }

        public virtual ICollection<CityUpgrade> CityUpgrades { get; set; }

        public virtual ICollection<Army> Armies { get; set; }

    }
}
