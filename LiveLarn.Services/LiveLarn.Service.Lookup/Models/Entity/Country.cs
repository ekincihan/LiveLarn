using LiveLarn.Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveLarn.Service.Lookup.Models.Entity
{
    public class Country : EntityBase<Int64>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
