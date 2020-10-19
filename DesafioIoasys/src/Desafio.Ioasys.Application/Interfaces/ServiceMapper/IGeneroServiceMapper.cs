using Desafio.Ioasys.Application.ViewModels;
using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Application.Interfaces.ServiceMapper
{
    public interface IGeneroServiceMapper
    {
        List<GeneroViewModel> MapToListaGeneroViewModel(IEnumerable<Genero> generos);
        GeneroViewModel MapToGeneroViewModel(Genero genero);
    }
}
