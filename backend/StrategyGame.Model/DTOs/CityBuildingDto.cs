using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.DTOs
{
    public class CityBuildingDto
    {
        public int BuildingId { get; set; }

        public BuildingDto Building { get; set; }

        public int Number { get; set; }

        public int RoundToFinish { get; set; }
    }
}
