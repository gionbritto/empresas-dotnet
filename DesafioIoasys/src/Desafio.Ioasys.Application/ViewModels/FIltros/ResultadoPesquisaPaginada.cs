using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Application.ViewModels.FIltros
{
    public class ResultadoPesquisaPaginada<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public Uri ProximaPagina { get; set; }
        public Uri PaginaAnterior { get; set; }
    }
}
