using Desafio.Ioasys.Application.Interfaces.ServiceMapper;
using Desafio.Ioasys.Application.ViewModels;
using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Application.ServiceMapper
{
    public class DiretorServiceMapper : IDiretorServiceMapper
    {
        public DiretorViewModel MapToDiretorViewModel(Diretor diretor)
        {
            if (diretor != null)
            {
                return new DiretorViewModel
                {
                    IdDiretor = diretor.IdDiretor,
                    Nome = diretor.Nome,
                    DataCadastro = diretor.DataCadastro,
                    DataModificacao = diretor.DataModificacao ?? DateTime.MinValue,
                    DataExclusao = diretor.DataExclusao,
                    Ativo = diretor.Ativo,
                    IdCriadoPor = diretor.IdCriadoPor,
                    IdAtualizadoPor = diretor.IdAtualizadoPor,
                    IdExcluidoPor = diretor.IdExcluidoPor
                    
                };
            }
            return null;
        }

        public List<DiretorViewModel> MapToListaDiretorViewModel(IEnumerable<Diretor> diretores)
        {
            List<DiretorViewModel> lista = new List<DiretorViewModel>();
            if (diretores != null)
            {
                foreach (var item in diretores)
                {
                    lista.Add(new DiretorViewModel
                    {
                        IdDiretor = item.IdDiretor,
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
