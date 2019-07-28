using LiveLarn.Core.Configuration;
using LiveLarn.Service.Education.DataAccess.Abstract;
using LiveLarn.Service.Education.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveLarn.Service.Education.DataAccess
{
    public class EducationDbContext : IEducationDbContext
    {
        private readonly IMongoDatabase _db;

        public EducationDbContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Category> Categories => _db.GetCollection<Category>("Categories");
        public IMongoCollection<ClassLevel> ClassLevels => _db.GetCollection<ClassLevel>("ClassLevels");
        public IMongoCollection<Subject> Subjects => _db.GetCollection<Subject>("Subjects");
        public IMongoCollection<Models.Entity.Type> Types => _db.GetCollection<Models.Entity.Type>("Types");
    }
}
