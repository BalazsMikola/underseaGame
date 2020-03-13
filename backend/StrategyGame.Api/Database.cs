using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StrategyGame.Api
{
    public class Database : DbContext
    {
        public DbSet<City> city;
    }
}
