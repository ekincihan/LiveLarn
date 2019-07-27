using LiveLarn.Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveLarn.Service.Education.Models.Entity
{
    public class EducationBase : EntityBase<Int64>
    {
        public string Name { get; set; }
    }
}
