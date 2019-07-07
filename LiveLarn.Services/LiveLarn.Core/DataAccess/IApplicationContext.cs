using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveLarn.Core.DataAccess
{
    public interface IApplicationContext<T> where T :  DbContext, new()
    {
        DbContext Context();
    }
}
