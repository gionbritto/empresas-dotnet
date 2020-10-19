using Desafio.Ioasys.Infra.Data.Context;
using Desafio.Ioasys.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DesafioIOContext _context;
        private bool _disposed;

        public UnitOfWork(DesafioIOContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
