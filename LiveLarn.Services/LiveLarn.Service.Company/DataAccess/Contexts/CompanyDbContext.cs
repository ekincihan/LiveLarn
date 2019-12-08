using AppLog.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace LiveLarn.Service.Company.DataAccess.Contexts
{
    public class CompanyDbContext : DbContext
    {
        private DbSet<Model.Entity.Company> Companies { get; set; }
        private DbSet<Model.Entity.Branch> Branches { get; set; }
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(AppConfiguration.Instance.Configuration.GetConnectionString("LookupDbContext"));
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
