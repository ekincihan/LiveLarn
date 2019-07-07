using Koton.ArthurService.Core.DataAccess.EntityFramework;
using LiveLarn.Service.Company.DataAccess.Contexts;
using LiveLarn.Service.Company.Model.Abstract;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace LiveLarn.Service.Company.Model.Concrete
{
    public class EfCompany : EfEntityRepositoryBase<Model.Entity.Company, CompanyDbContext>, ICompany, IDisposable
    {
        private bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }

            disposed = true;
        }
    }
}
