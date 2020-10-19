using Desafio.Ioasys.Application.Interfaces.ServiceMapper;
using Desafio.Ioasys.Application.ViewModels;
using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Application.ServiceMapper
{
    public class VotoServiceMapper : IVotoServiceMapper
    {
        public List<VotoViewModel> MapToListaVotoViewModel(IEnumerable<Voto> votos)
        {
            List<VotoViewModel> lista = new List<VotoViewModel>();
            if (votos != null)
            {
                foreach (var item in votos)
                {
                    lista.Add(new VotoViewModel
                    {
                        IdVoto = item.IdVoto,
                        IdFilme = item.IdFilme,
                        IdUsuario = item.IdUsuario,
                        Pontuacao = item.Pontuacao,
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

        public VotoViewModel MapToVotoViewModel(Voto voto)
        {
            if (voto != null)
            {
                return new VotoViewModel
                {
                    IdVoto = voto.IdVoto,
                    IdFilme = voto.IdFilme,
                    IdUsuario = voto.IdUsuario,
                    Pontuacao = voto.Pontuacao,
                    DataCadastro = voto.DataCadastro,
                    DataModificacao = voto.DataModificacao ?? DateTime.MinValue,
                    DataExclusao = voto.DataExclusao,
                    Ativo = voto.Ativo,
                    IdCriadoPor = voto.IdCriadoPor,
                    IdAtualizadoPor = voto.IdAtualizadoPor,
                    IdExcluidoPor = voto.IdExcluidoPor,
                    ValidationResult = voto.ValidationResult
                };
            }
            return null;
        }
       
    }
}
