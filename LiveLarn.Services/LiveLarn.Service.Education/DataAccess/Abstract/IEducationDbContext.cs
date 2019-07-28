using LiveLarn.Service.Education.Models.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveLarn.Service.Education.DataAccess.Abstract
{
    public interface IEducationDbContext
    {
        IMongoCollection<Category> Categories { get; }
        IMongoCollection<ClassLevel> ClassLevels { get; }
        IMongoCollection<Subject> Subjects { get; }
        IMongoCollection<Education.Models.Entity.Type> Types { get;}
    }
}
