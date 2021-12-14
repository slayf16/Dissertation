using LibraryForOptimization.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization.Repository
{
    public class StationContext: DbContext
    {
        public StationContext(): base("DefaultConnection")
        {}

        public DbSet<Station> Stations { get; set; }
    }
}
