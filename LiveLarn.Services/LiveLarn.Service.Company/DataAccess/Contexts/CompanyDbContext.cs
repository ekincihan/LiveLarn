using LiveLarn.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveLarn.Service.Company.DataAccess.Contexts
{
    public class CompanyDbContext : DbContext
    {
        private DbSet<Model.Entity.Company> Companies { get; set; }
        private DbSet<Model.Entity.Branch> Branches { get; set; }
        public CompanyDbContext()
        {

        }
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(AppConfiguration.Instance.Configuration.GetConnectionString("CompanyDbContext"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
