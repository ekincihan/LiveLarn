using LiveLarn.Core.Infrastructure.Base.Abstract;

namespace LiveLarn.Core.Infrastructure.Base
{
    public class ModelBase<T> : IModelBase
    {
        public T Id { get; set; }
        public bool IsActive { get; set; }
    }
}
