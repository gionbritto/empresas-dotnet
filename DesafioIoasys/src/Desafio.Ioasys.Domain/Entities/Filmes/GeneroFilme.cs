using Desafio.Ioasys.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Domain.Entities.Filmes
{
    public class GeneroFilme
    {
        public GeneroFilme(
            Guid idGeneroFilme,
            Guid idFilme,
            Guid idGenero)
        {
            IdGeneroFilme = idGeneroFilme;
            IdFilme = idFilme;
            IdGenero = idGenero;
        }

        protected GeneroFilme() { }

        public Guid IdGeneroFilme { get; protected set; }
        public Guid IdFilme { get; protected set; }
        public Guid IdGenero { get; protected set; }

        public virtual Filme Filme { get; protected set; }
        public virtual Genero Genero { get; protected set; }       
       
    }
}
