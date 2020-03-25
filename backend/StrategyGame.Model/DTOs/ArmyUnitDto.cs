using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.DTOs
{
    public class ArmyUnitDto
    {
        public int Id { get; set; }

        public int? UnitId { get; set; }

        public int Number { get; set; }

        public int ArmyId { get; set; }
    }
}
