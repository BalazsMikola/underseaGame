using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.DTOs
{
    public class CityDto
    {

        public string Name { get; set; }

        public int Population { get; set; }

        public int Pearl { get; set; }

        public int Coral { get; set; }

        public int Rank { get; set; }

        public ICollection<CityBuilding> CityBuildings { get; set; }

        public ICollection<CityUpgrade> CityUpgrades { get; set; }

        public ICollection<CityArmy> CityArmies { get; set; }

    }
}
