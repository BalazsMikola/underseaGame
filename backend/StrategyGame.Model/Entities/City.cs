using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Model.Entities
{
    public class City
    {

        public int CityId { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }

        public int Pearl { get; set; }

        public int Coral { get; set; }

        public int Rank { get; set; }

        public virtual ICollection<CityBuilding> CityBuildings { get; set; }

        public virtual CityUpgrade Upgrade { get; set; }

        public virtual ICollection<CityUnit> CityUnits { get; set; }

        public virtual ICollection<CityArmy> CityArmies { get; set; }

    }
}
