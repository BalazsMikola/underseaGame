using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.DTOs
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Population { get; set; }

        public int Pearl { get; set; }

        public int Coral { get; set; }

        public int Rank { get; set; }

        public ICollection<CityBuildingDto> CityBuildings { get; set; }

        public ICollection<CityUpgradesDto> CityUpgrades { get; set; }

        public ICollection<ArmyDto> Armies { get; set; }

    }
}
