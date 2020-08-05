using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoveragePlanApi.Models
{
    public class CoveragePlanDBContext : DbContext
    {
        public CoveragePlanDBContext(DbContextOptions<CoveragePlanDBContext> options) : base(options)
        {

        }
        public DbSet<Contracts> Contracts { get; set; }
        public DbSet<RateChart> rateCharts { get; set; }

        public DbSet<CoveragePlan> coveragePlans { get; set; }
    }
}
