using LiveLarn.Core.Infrastructure.Abstract.Base;
using LiveLarn.Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiveLarn.Service.Company.Model.Entity
{
    public class Company : EntityBase<Int64>
    {
        [StringLength(100)]
        public string Name { get; set; }
 
        public List<Branch> Branches { get; set; }
    }
}
