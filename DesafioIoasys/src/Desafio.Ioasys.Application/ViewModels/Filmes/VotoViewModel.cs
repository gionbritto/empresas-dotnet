
using Desafio.Ioasys.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Application.ViewModels
{
    public class VotoViewModel : ViewModelBase
    {
        public Guid IdVoto { get; set; }
        public Guid IdFilme { get; set; }
        public string IdUsuario { get; set; }
        public int Pontuacao { get; set; }
    }
}
