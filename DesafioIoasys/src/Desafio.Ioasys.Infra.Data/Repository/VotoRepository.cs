using Desafio.Ioasys.Domain.Entities.Filmes;
using Desafio.Ioasys.Domain.Interfaces.Repository;
using Desafio.Ioasys.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.Ioasys.Infra.Data.Repository
{
    public class VotoRepository : Repository<Voto>, IVotoRepository
    {
        public VotoRepository(DesafioIOContext context) : base(context)
        {
        }

        public IEnumerable<Voto> ObterVotosPorIdFilme(Guid id)
        {
            var votos = Buscar(x => x.IdFilme == id);
            return votos; 
        }

        public bool VerificarSeFilmeExistente(Guid id)
        {
            var retorno = _db.TFilme.Any(x => x.IdFilme == id);
            return retorno;
        }

        public bool VerificarSeUsuarioExistente(string id)
        {
            var retorno = _db.TUsuario.Any(x => x.IdUsuario == id);
            return retorno;
        }

        public bool VerificarSeVotoJaExistente(Guid idFilme, string idUsuario)
        {
            var retorno = Buscar(x => x.IdFilme == idFilme && x.IdUsuario == idUsuario).Any();
            return retorno;
        }
    }
}
