using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.DTOs
{
    public class BuildingDto
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int Grow_pop { get; set; }

        public int Grow_coral { get; set; }

        public int Space { get; set; }
    }
}
