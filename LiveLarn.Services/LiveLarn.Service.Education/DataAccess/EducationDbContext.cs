using LiveLarn.Core.Configuration;
using LiveLarn.Service.Education.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveLarn.Service.Education.DataAccess
{
    public class EducationDbContext : DbContext
    {
        private DbSet<Category> Categories { get; set; }

        private DbSet<ClassLevel> ClassLevels { get; set; }

        private DbSet<Subject> Subjects { get; set; }

        private DbSet<Models.Entity.Type> Types { get; set; }

        public EducationDbContext()
        {
                
        }

        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(AppConfiguration.Instance.Configuration.GetConnectionString("EducationDbContext"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
