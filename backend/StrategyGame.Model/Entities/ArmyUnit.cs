using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class ArmyUnit : Entity
    {
        public int? UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        public int Number { get; set; }

        public int ArmyId { get; set; }
        public virtual Army Army { get; set; }
    }
}
