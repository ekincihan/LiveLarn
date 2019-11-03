using Microsoft.EntityFrameworkCore;

namespace LiveLarn.Core.DataAccess
{
    public interface IApplicationContext<T> where T : DbContext, new()
    {
        DbContext Context();
    }
}
