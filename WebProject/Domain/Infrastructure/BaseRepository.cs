using Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructure
{
    public class BaseRepository : IDisposable
    {
        public EfFileCoreContext _context;
        public BaseRepository(EfFileCoreContext context) {
            _context = context;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
