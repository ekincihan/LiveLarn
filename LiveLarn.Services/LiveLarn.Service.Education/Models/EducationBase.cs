using LiveLarn.Core.Infrastructure.Base;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveLarn.Service.Education.Models.Entity
{
    public class EducationBase : EntityMongoBase<ObjectId>
    {
        public string Name { get; set; }
    }
}
