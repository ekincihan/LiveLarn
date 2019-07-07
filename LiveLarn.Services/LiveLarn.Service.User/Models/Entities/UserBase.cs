using LiveLarn.Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiveLarn.Service.User.Models.Entities
{
    public class UserBase :EntityBase<Guid>
    {
        [Required]
        public int UserId { get; set; }
        [MaxLength(11)] 
        public string TCKN { get; set; }
        public string Name{ get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
