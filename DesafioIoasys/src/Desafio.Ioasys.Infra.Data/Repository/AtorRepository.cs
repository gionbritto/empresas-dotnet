using Desafio.Ioasys.Domain.Entities.Filmes;
using Desafio.Ioasys.Domain.Interfaces.Repository;
using Desafio.Ioasys.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Infra.Data.Repository
{
    public class AtorRepository : Repository<Ator>, IAtorRepository
    {
        public AtorRepository(DesafioIOContext context) : base(context)
        {
        }
    }
}
