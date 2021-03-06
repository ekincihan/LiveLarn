﻿using LiveLarn.Core.Infrastructure.Abstract.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace LiveLarn.Core.Infrastructure.Base
{
    public class EntityBase<Type> : IEntity
    {
        [Key]
        [Required]
        public Type Id { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid? CreatedBy { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
