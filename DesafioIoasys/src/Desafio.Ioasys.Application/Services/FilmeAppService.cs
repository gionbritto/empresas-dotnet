using Desafio.Ioasys.Application.Interfaces.ServiceMapper;
using Desafio.Ioasys.Application.Interfaces.Services;
using Desafio.Ioasys.Application.ViewModels.Filmes;
using Desafio.Ioasys.Domain.Entities.Filmes;
using Desafio.Ioasys.Domain.Interfaces.Services;
using Desafio.Ioasys.Infra.Data.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Application.Services
{
    public class FilmeAppService : ApplicationService, IFilmeAppService
    {
        private readonly IFilmeService _filmeService;
        private readonly IFilmeServiceMapper _filmeServiceMapper;

        public FilmeAppService(IFilmeService filmeService,
                              IFilmeServiceMapper filmeServiceMapper,
                              IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _filmeService = filmeService;
            _filmeServiceMapper = filmeServiceMapper;
        }
        public async Task<FilmeViewModel> Adicionar(FilmeViewModel filmeViewModel)
        {
            var filme = new Filme(filmeViewModel.IdFilme, filmeViewModel.Nome, true,
                               filmeViewModel.IdCriadoPor, filmeViewModel.IdAtualizadoPor, filmeViewModel.IdExcluidoPor);
            BeginTransaction();
            var atorServiceRetorno = await _filmeService.Adicionar(filme);

            filmeViewModel = _filmeServiceMapper.MapToFilmeViewModel(atorServiceRetorno);
            if (!filmeViewModel.ValidationResult.IsValid)
            {
                return filmeViewModel;
            }

            var sucessoCommit = await Commit();
            if (!sucessoCommit)
            {
                if (!sucessoCommit)
                {
                    filmeViewModel.ValidationResult.Errors.Add(new ValidationFailure("Commit", "Ocorreu um erro ao salvar as informações no banco de dados. Por favor, tente novamente"));
                }
            }

            return filmeViewModel;
        }

        public async Task<FilmeViewModel> Atualizar(FilmeViewModel filmeViewModel)
        {
            var filme = new Filme(filmeViewModel.IdFilme, filmeViewModel.Nome, filmeViewModel.Ativo,
                               filmeViewModel.IdCriadoPor, filmeViewModel.IdAtualizadoPor, filmeViewModel.IdExcluidoPor);
            BeginTransaction();
            var atorServiceRetorno = _filmeService.Atualizar(filme);

            filmeViewModel = _filmeServiceMapper.MapToFilmeViewModel(atorServiceRetorno);
            if (!filmeViewModel.ValidationResult.IsValid)
            {
                return filmeViewModel;
            }

            var sucessoCommit = await Commit();
            if (!sucessoCommit)
            {
                if (!sucessoCommit)
                {
                    filmeViewModel.ValidationResult.Errors.Add(new ValidationFailure("Commit", "Ocorreu um erro ao salvar as informações no banco de dados. Por favor, tente novamente"));
                }
            }

            return filmeViewModel;
        }

        public void Dispose()
        {
            _filmeService.Dispose();
        }

        public bool Inativar(Guid id, Guid idExcluidoPor)
        {
            throw new NotImplementedException();
        }

        public async Task<FilmeViewModel> ObterPorId(Guid id)
        {
            var filme = await _filmeService.ObterPorId(id);
            return _filmeServiceMapper.MapToFilmeViewModel(filme);
        }

        public async Task<IEnumerable<FilmeViewModel>> ObterTodos()
        {
            var atores = await _filmeService.ObterTodos();
            return _filmeServiceMapper.MapToListaFilmeViewModel(atores);
        }
    }
}
