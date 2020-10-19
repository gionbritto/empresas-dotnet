using Desafio.Ioasys.Application.Interfaces.ServiceMapper;
using Desafio.Ioasys.Application.ViewModels;
using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Application.ServiceMapper
{
    public class GeneroServiceMapper : IGeneroServiceMapper
    {
        public GeneroViewModel MapToGeneroViewModel(Genero genero)
        {
            if (genero != null)
            {
                return new GeneroViewModel
                {
                    IdGenero = genero.IdGenero,
                    Nome = genero.Nome,
                    DataCadastro = genero.DataCadastro,
                    DataModificacao = genero.DataModificacao ?? DateTime.MinValue,
                    DataExclusao = genero.DataExclusao,
                    Ativo = genero.Ativo,
                    IdCriadoPor = genero.IdCriadoPor,
                    IdAtualizadoPor = genero.IdAtualizadoPor,
                    IdExcluidoPor = genero.IdExcluidoPor
                    
                };
            }
            return null;
        }

        public List<GeneroViewModel> MapToListaGeneroViewModel(IEnumerable<Genero> generos)
        {
            List<GeneroViewModel> lista = new List<GeneroViewModel>();
            if (generos != null)
            {
                foreach (var item in generos)
                {
                    lista.Add(new GeneroViewModel
                    {
                        IdGenero = item.IdGenero,
                        Nome = item.Nome,
                        DataCadastro = item.DataCadastro,
                        DataModificacao = item.DataModificacao ?? DateTime.MinValue,
                        DataExclusao = item.DataExclusao,
                        Ativo = item.Ativo,
                        IdCriadoPor = item.IdCriadoPor,
                        IdAtualizadoPor = item.IdAtualizadoPor,
                        IdExcluidoPor = item.IdExcluidoPor
                    });
                }
            }

            return lista;
        }
    }
}
