using Desafio.Ioasys.Domain.Entities.Filmes;
using Desafio.Ioasys.Domain.Interfaces.Repository;
using Desafio.Ioasys.Domain.Interfaces.Services;
using Desafio.Ioasys.Domain.Validations.Filmes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Domain.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<Filme> Adicionar(Filme filme)
        {
            if (filme == null) return null;

            if (!filme.IsValid())
            {
                return filme;
            }

            var regrasFilme = new FilmeAptoParaCadastroValidation(_filmeRepository).Validate(filme);

            foreach (var item in regrasFilme.Errors)
            {
                filme.ValidationResult.Errors.Add(item);
            }

            filme = await _filmeRepository.Adicionar(filme);
            return filme;            
        }

        public Filme Atualizar(Filme filme)
        {
            if (filme == null) return null;

            if (!filme.IsValid())
            {
                return filme;
            }

            var regrasFilme = new FilmeAptoParaAtualizacaoValidation(_filmeRepository).Validate(filme);

            foreach (var item in regrasFilme.Errors)
            {
                filme.ValidationResult.Errors.Add(item);
            }

            filme = _filmeRepository.Atualizar(filme);
            return filme;
        }

        public void Dispose()
        {
            _filmeRepository.Dispose();
        }

        public bool Inativar(Guid id, Guid idExcluidoPor)
        {
            var retorno = _filmeRepository.Inativar(id, idExcluidoPor);
            return retorno;
        }

        public async Task<Filme> ObterPorId(Guid id)
        {
            var filme = await _filmeRepository.ObterPorId(id);
            return filme;
        }

        public async Task<IEnumerable<Filme>> ObterTodos()
        {
            var filmes = await _filmeRepository.ObterTodos();
            return filmes;
        }
    }
}
