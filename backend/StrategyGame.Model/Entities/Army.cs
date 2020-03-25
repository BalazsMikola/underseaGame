using System.Collections.Generic;

namespace StrategyGame.Model.Entities
{
    public class Army : Entity
    {
        public int? EnemyCityId { get; set; }
        public virtual City EnemyCity { get; set; }

        public int ArmyId { get; set; }

        public virtual ICollection<ArmyUnit> ArmyUnits { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

    }

}
