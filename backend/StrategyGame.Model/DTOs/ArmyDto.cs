using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.DTOs
{
    public class ArmyDto
    {
        public int CityId { get; set; }
        public int ArmyId { get; set; }
        public IEnumerable<ArmyUnitDto> ArmyUnits { get; set; }
        public int? EnemyCityId { get; set; }
    }
}
