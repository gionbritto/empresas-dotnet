using Desafio.Ioasys.Application.ViewModels;
using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Application.Interfaces.ServiceMapper
{
    public interface IDiretorServiceMapper
    {
        List<DiretorViewModel> MapToListaDiretorViewModel(IEnumerable<Diretor> diretores);
        DiretorViewModel MapToDiretorViewModel(Diretor diretor);
    }
}
