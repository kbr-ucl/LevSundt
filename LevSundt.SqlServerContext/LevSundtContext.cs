using LevSundt.Bmi.Domain.Model;
using LevSundt.SqlServerContext.BmiConfiguration;
using Microsoft.EntityFrameworkCore;

namespace LevSundt.SqlServerContext
{
    public class LevSundtContext : DbContext
    {
        public LevSundtContext(DbContextOptions<LevSundtContext> options) : base(options)
        {
            
        }

        public DbSet<BmiEntity> BmiEntities { get; set; }

        protected override void OnModelCreating (ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new BmiTypeConfiguration());
        }
    }
}
