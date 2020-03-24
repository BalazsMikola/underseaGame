using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class Army
    {
        public int Id { get; set; }
        public int UnitId { get; set; }

        public int Number { get; set; }

        public int ArmyNumber { get; set; }

        public Unit Unit { get; set; }

    }
}
