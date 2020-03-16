using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Model.Entities
{
    public class Building
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Grow_pop { get; set; }

        public int Grow_coral { get; set; }

        public int Space { get; set; }

        public virtual ICollection<CityBuilding> CityBuildings { get; set; }

    }
}
