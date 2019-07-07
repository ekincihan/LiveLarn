using LiveLarn.Core.DataAccess;
using LiveLarn.Service.Company.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveLarn.Service.Company.Model.Abstract
{
    public interface IBranch : IEntityRepository<Branch>
    {
    }
}
