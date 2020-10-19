using Desafio.Ioasys.Domain.Core;
using Desafio.Ioasys.Domain.Validations.Votos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Domain.Entities.Filmes
{
    public class Voto : Entity<Voto>
    {
        public Voto(
            Guid idVoto,
            Guid idFilme,
            string idUsuario,
            int pontuacao,
            bool ativo)
        {
            IdVoto = idVoto == Guid.Empty ? Guid.NewGuid() : idVoto;
            IdFilme = idFilme;
            IdUsuario = idUsuario;
            Pontuacao = pontuacao;
            Ativo = ativo;
        }

        protected Voto() { }

        public Guid IdVoto { get; protected set; }
        public Guid IdFilme { get; protected set; }
        public string IdUsuario { get; protected set; }
        public int Pontuacao { get; protected set; }

        public virtual Filme Filme { get; set; }
        public virtual Usuario Usuario { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new VotoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
