using Desafio.Ioasys.Application.Interfaces.ServiceMapper;
using Desafio.Ioasys.Application.ViewModels;
using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Application.ServiceMapper
{
    public class AtorServiceMapper : IAtorServiceMapper
    {
        public AtorViewModel MapToAtorViewModel(Ator ator)
        {
            if (ator != null)
            {
                return new AtorViewModel
                {
                    IdAtor = ator.IdAtor,
                    Nome = ator.Nome,
                    DataCadastro = ator.DataCadastro,
                    DataModificacao = ator.DataModificacao ?? DateTime.MinValue,
                    DataExclusao = ator.DataExclusao,
                    Ativo = ator.Ativo,
                    IdCriadoPor = ator.IdCriadoPor,
                    IdAtualizadoPor = ator.IdAtualizadoPor,
                    IdExcluidoPor = ator.IdExcluidoPor
                    
                };
            }
            return null;
        }

        public List<AtorViewModel> MapToListaAtorViewModel(IEnumerable<Ator> atores)
        {
            List<AtorViewModel> lista = new List<AtorViewModel>();
            if (atores != null)
            {
                foreach (var item in atores)
                {
                    lista.Add(new AtorViewModel
                    {
                        IdAtor = item.IdAtor,
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
