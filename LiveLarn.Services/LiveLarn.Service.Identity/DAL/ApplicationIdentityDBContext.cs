using LiveLarn.Core.Configuration;
using LiveLarn.Service.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            optionsBuilder.UseSqlServer(AppConfiguration.Instance.Configuration.GetConnectionString("Identity"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
