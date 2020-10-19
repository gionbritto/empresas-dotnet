using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Application.ViewModels.FIltros
{
    public abstract class FiltroBaseViewModel : ICloneable
    {
        public FiltroBaseViewModel()
        {
            Pagina = 1;
            Limite = 50;
        }

        public int Pagina { get; set; }
        public int Limite { get; set; }

        public abstract object Clone();
        
    }
}
