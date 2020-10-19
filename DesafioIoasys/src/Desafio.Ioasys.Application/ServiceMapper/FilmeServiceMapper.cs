using Desafio.Ioasys.Application.Interfaces.ServiceMapper;
using Desafio.Ioasys.Application.ViewModels;
using Desafio.Ioasys.Application.ViewModels.Filmes;
using Desafio.Ioasys.Domain.Entities.Filmes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.Ioasys.Application.ServiceMapper
{
    public class FilmeServiceMapper : IFilmeServiceMapper
    {
        private readonly IAtorServiceMapper _atorServiceMapper;
        private readonly IGeneroServiceMapper _generoServiceMapper;
        private readonly IDiretorServiceMapper _diretorServiceMapper;
        public FilmeServiceMapper(IAtorServiceMapper atorServiceMapper,
                                  IGeneroServiceMapper generoServiceMapper,
                                  IDiretorServiceMapper diretorServiceMapper)
        {
            _atorServiceMapper = atorServiceMapper;
            _generoServiceMapper = generoServiceMapper;
            _diretorServiceMapper = diretorServiceMapper;
        }

        public FilmeViewModel MapToFilmeViewModel(Filme filme)
        {
            if (filme != null)
            {
                return new FilmeViewModel
                {
                    IdFilme = filme.IdFilme,
                    Nome = filme.Nome,
                    DataCadastro = filme.DataCadastro,
                    DataModificacao = filme.DataModificacao ?? DateTime.MinValue,
                    DataExclusao = filme.DataExclusao,
                    Ativo = filme.Ativo,
                    IdCriadoPor = filme.IdCriadoPor,
                    IdAtualizadoPor = filme.IdAtualizadoPor,
                    IdExcluidoPor = filme.IdExcluidoPor,
                    Atores = MapToListaAtoresFilmeViewModel(filme.AtoresFilme),
                    Generos = MapToListaGenerosFilmeViewModel(filme.GenerosFilme),
                    Diretores = MapToListaDiretoresFilmeViewModel(filme.DiretoresFilme)
                };
            }
            return null;
        }


        public List<FilmeViewModel> MapToListaFilmeViewModel(IEnumerable<Filme> filmes)
        {
            List<FilmeViewModel> lista = new List<FilmeViewModel>();
            if (filmes != null)
            {
                foreach (var item in filmes)
                {
                    lista.Add(new FilmeViewModel
                    {
                        IdFilme = item.IdFilme,
                        Nome = item.Nome,
                        DataCadastro = item.DataCadastro,
                        DataModificacao = item.DataModificacao ?? DateTime.MinValue,
                        DataExclusao = item.DataExclusao,
                        Ativo = item.Ativo,
                        IdCriadoPor = item.IdCriadoPor,
                        IdAtualizadoPor = item.IdAtualizadoPor,
                        IdExcluidoPor = item.IdExcluidoPor,
                        Atores = MapToListaAtoresFilmeViewModel(item.AtoresFilme),
                        Generos = MapToListaGenerosFilmeViewModel(item.GenerosFilme),
                        Diretores = MapToListaDiretoresFilmeViewModel(item.DiretoresFilme)
                    });
                }
            }

            return lista;
        }

        private ICollection<AtorViewModel> MapToListaAtoresFilmeViewModel(IEnumerable<AtorFilme> atoresFilme)
        {
            List<AtorViewModel> lista = new List<AtorViewModel>();
            if (atoresFilme != null)
            {
               lista = _atorServiceMapper.MapToListaAtorViewModel(atoresFilme.Select(x => x.Ator));                
            }

            return lista;
        }

        private ICollection<DiretorViewModel> MapToListaDiretoresFilmeViewModel(ICollection<DiretorFilme> diretoresFilme)
        {
            List<DiretorViewModel> lista = new List<DiretorViewModel>();
            if (diretoresFilme != null)
            {
                lista = _diretorServiceMapper.MapToListaDiretorViewModel(diretoresFilme.Select(x => x.Diretor));
            }

            return lista;
        }

        private ICollection<GeneroViewModel> MapToListaGenerosFilmeViewModel(ICollection<GeneroFilme> generosFilme)
        {
            List<GeneroViewModel> lista = new List<GeneroViewModel>();
            if (generosFilme != null)
            {
                lista = _generoServiceMapper.MapToListaGeneroViewModel(generosFilme.Select(x => x.Genero));
            }

            return lista;
        }
    }
}
