using LiveLarn.Core.Configuration;
using LiveLarn.Service.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveLarn.Service.User.DataAccess.Contexts
{
    public class IdentityDbContext : IdentityDbContext<IdentityUser, IdentityRole<string>, string>
    {
        public IdentityDbContext()
        {

        }
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
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