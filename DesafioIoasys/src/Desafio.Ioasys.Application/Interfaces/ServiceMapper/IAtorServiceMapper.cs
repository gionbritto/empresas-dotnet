using Desafio.Ioasys.Application.ViewModels;
using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Application.Interfaces.ServiceMapper
{
    public interface IAtorServiceMapper
    {
        List<AtorViewModel> MapToListaAtorViewModel(IEnumerable<Ator> atores);
        AtorViewModel MapToAtorViewModel(Ator ator);
    }
}
