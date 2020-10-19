using Desafio.Ioasys.Application.ViewModels;
using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Application.Interfaces.ServiceMapper
{
    public interface IVotoServiceMapper
    {
        List<VotoViewModel> MapToListaVotoViewModel(IEnumerable<Voto> votos);
        VotoViewModel MapToVotoViewModel(Voto voto);
    }
}
