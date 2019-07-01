using LiveLarn.Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveLarn.Service.Company.Model
{
    public class CountryModel : ModelBase<Int64>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
