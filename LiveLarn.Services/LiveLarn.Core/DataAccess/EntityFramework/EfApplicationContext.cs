using System;
using System.Collections.Generic;
using System.Text;
using LiveLarn.Core.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;

namespace LiveLarn.Core.DataAccess.EntityFramework
{
    public class EfApplicationContext<TContext> : SingletonBase<EfApplicationContext<TContext>>, IApplicationContext<TContext> where TContext : DbContext, new()
    {
        public DbContext Context()
        {
            return new TContext();
        }
    }
}
