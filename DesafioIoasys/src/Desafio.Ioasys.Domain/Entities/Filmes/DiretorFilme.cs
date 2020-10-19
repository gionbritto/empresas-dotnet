using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Domain.Entities.Filmes
{
    public class DiretorFilme
    {
        public DiretorFilme(
           Guid idDiretorFilme,
           Guid idFilme,
           Guid idDiretor)
        {
            IdDiretorFilme = idDiretorFilme;
            IdFilme = idFilme;
            IdDiretor = idDiretor;
        }

        protected DiretorFilme() { }

        public Guid IdDiretorFilme { get; protected set; }
        public Guid IdFilme { get; protected set; }
        public Guid IdDiretor { get; protected set; }

        public virtual Filme Filme { get; protected set; }
        public virtual Diretor Diretor { get; protected set; }
    }
}
