using Desafio.Ioasys.Infra.Data.Interfaces;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Application.Services
{
    public class ApplicationService
    {
        private readonly IUnitOfWork _uow;

        public ApplicationService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public Task<bool> Commit()
        {
            return _uow.Commit();
        }
    }
}
