using LiveLarn.Core.Infrastructure.Abstract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLarn.Core.Infrastructure.Base
{
    public class EntityBase<Type> : IEntity
    {
        public Type Id { get; set; }
    }
}
