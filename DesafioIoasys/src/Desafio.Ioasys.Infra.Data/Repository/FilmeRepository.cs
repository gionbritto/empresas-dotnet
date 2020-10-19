using Desafio.Ioasys.Domain.Entities.Filmes;
using Desafio.Ioasys.Domain.Interfaces.Repository;
using Desafio.Ioasys.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Infra.Data.Repository
{
    public class FilmeRepository : Repository<Filme>, IFilmeRepository
    {
        public FilmeRepository(DesafioIOContext context) : base(context)
        {
        }

        public bool Inativar(Guid id, Guid idExcluidoPor)
        {
            throw new NotImplementedException();
        }

        public bool VerificarFilmeExistente(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
