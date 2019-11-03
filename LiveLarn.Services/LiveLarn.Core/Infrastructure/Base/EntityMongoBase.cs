using LiveLarn.Core.Infrastructure.Abstract.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace LiveLarn.Core.Infrastructure.Base
{
    public class EntityMongoBase<Type> : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Type Id { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid? CreatedBy { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
