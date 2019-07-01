using LiveLarn.Core.Configuration;
using LiveLarn.Service.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LiveLarn.Service.Identity.DAL
{
    public class ApplicationIdentityDBContext : IdentityDbContext<ApplicationUser, IdentityRole<string>, string>
    {
        public ApplicationIdentityDBContext()
        {

        }
        public ApplicationIdentityDBContext(DbContextOptions<ApplicationIdentityDBContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(AppConfiguration.Instance.Configuration.GetConnectionString("IdentityDbContext"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
