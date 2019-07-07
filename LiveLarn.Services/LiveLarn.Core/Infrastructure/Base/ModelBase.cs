using LiveLarn.Core.Infrastructure.Base.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveLarn.Core.Infrastructure.Base
{
    public class ModelBase<T> : IModelBase
    {
        public T Id { get; set; }
        public bool IsActive { get; set; }
    }
}
