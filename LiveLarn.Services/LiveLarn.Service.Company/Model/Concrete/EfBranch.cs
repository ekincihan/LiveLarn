using Koton.ArthurService.Core.DataAccess.EntityFramework;
using LiveLarn.Service.Company.DataAccess.Contexts;
using LiveLarn.Service.Company.Model.Abstract;
using LiveLarn.Service.Company.Model.Entity;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace LiveLarn.Service.Company.Model.Concrete
{
    public class EfBranch : EfEntityRepositoryBase<Branch, CompanyDbContext>, IBranch, IDisposable
    {
        private bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public void Dispose()
        {
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
