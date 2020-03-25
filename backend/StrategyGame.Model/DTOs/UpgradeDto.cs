using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.DTOs
{
    public class UpgradeDto
    {
        public string Name { get; set; }

        public int Coral { get; set; }

        public int Defend { get; set; }

        public int Attack { get; set; }

        public int Tax { get; set; }
    }
}
