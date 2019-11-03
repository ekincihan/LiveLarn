using LiveLarn.Core.Infrastructure.Abstract.Base;

namespace LiveLarn.Core.Infrastructure.Base
{
    public class SingletonBase<T> : IBase where T : class, new()
    {
        private static readonly object padlock = new object();
        private static T _instance;

        public static T Instance
        {
            get
            {
                lock (padlock)
                {

                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                    return _instance;
                }
            }
        }
    }
}