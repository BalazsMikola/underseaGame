using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class CityUnit
    {
        public int Id { get; set; }

        public City City { get; set; }

        public Unit Unit { get; set; }

        public int Number { get; set; }
    }
}
