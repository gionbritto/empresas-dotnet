using Desafio.Ioasys.Application.ViewModels.Filmes;
using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Application.Interfaces.ServiceMapper
{
    public interface IFilmeServiceMapper
    {
        List<FilmeViewModel> MapToListaFilmeViewModel(IEnumerable<Filme> filmes);
        FilmeViewModel MapToFilmeViewModel(Filme filme);
    }
}
