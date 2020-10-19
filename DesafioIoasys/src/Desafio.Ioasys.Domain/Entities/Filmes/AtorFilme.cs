using Desafio.Ioasys.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Domain.Entities.Filmes
{
    public class AtorFilme
    {
        public AtorFilme(
            Guid idAtorFilme,
            Guid idFilme,
            Guid idAtor)
        {
            IdAtorFilme = idAtorFilme;
            IdFilme = idFilme;
            IdAtor = idAtor;
        }

        protected AtorFilme() { }

        public Guid IdAtorFilme { get; protected set; }
        public Guid IdFilme { get; protected set; }
        public Guid IdAtor { get; protected set; }

        public virtual Filme Filme { get; protected set; }
        public virtual Ator Ator { get; protected set; }
 
    }
}
