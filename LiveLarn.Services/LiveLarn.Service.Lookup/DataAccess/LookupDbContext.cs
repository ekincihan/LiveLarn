using LiveLarn.Core.Configuration;
using LiveLarn.Service.Lookup.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LiveLarn.Service.Lookup.DataAccess
{
    public class LookupDbContext : DbContext
    {
        private DbSet<Country> Countries { get; set; }
        private DbSet<City> Cities{ get; set; }
        private DbSet<District> Districts { get; set; }
        public LookupDbContext()
        {

        }
        public LookupDbContext(DbContextOptions<LookupDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(AppConfiguration.Instance.Configuration.GetConnectionString("LookupDbContext"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
