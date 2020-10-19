using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task<bool> Commit();
    }
}
