
using Desafio.Ioasys.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Desafio.Ioasys.Application.ViewModels.Filmes
{
    public class FilmeViewModel : ViewModelBase
    { 

        public Guid IdFilme { get;  set; }
        public string Nome { get;  set; }

        public virtual IEnumerable<AtorViewModel> Atores { get; set; }
        public virtual ICollection<DiretorViewModel> Diretores { get; set; }
        public virtual ICollection<GeneroViewModel> Generos { get; set; }


    }
}
