using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class Unit : Entity
    {
        public string Name { get; set; }

        public int Attack { get; set; }

        public int Defend { get; set; }

        public int Price { get; set; }

        public int Cost { get; set; }

        public int Food { get; set; }
    }
}
