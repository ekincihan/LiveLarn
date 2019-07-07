using LiveLarn.Core.Infrastructure.Abstract.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
 