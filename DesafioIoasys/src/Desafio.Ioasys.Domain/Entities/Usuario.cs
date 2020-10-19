using Desafio.Ioasys.Domain.Core;
using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Domain
{
    public class Usuario : Entity<Usuario>
    {
        public string IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Voto> Votos { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
