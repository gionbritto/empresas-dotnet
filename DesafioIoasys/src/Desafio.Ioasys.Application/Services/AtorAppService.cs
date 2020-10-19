using Desafio.Ioasys.Application.Interfaces.ServiceMapper;
using Desafio.Ioasys.Application.Interfaces.Services;
using Desafio.Ioasys.Application.ViewModels;
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
    public class AtorAppService : ApplicationService, IAtorAppService
    {
        private readonly IAtorService _atorService;
        private readonly IAtorServiceMapper _atorServiceMapper;        

        public AtorAppService(IAtorService atorService,
                              IAtorServiceMapper atorServiceMapper,
                              IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _atorService = atorService;
            _atorServiceMapper = atorServiceMapper;
        }

        public async Task<AtorViewModel> Adicionar(AtorViewModel atorViewModel)
        {
            var ator = new Ator(atorViewModel.IdAtor, atorViewModel.Nome, true,
                                atorViewModel.IdCriadoPor, atorViewModel.IdAtualizadoPor, atorViewModel.IdExcluidoPor);
            BeginTransaction();
            var atorServiceRetorno = await _atorService.Adicionar(ator);

            atorViewModel = _atorServiceMapper.MapToAtorViewModel(atorServiceRetorno);
            if (!atorServiceRetorno.ValidationResult.IsValid)
            {
                return atorViewModel;
            }

            var sucessoCommit = await Commit();
            if (!sucessoCommit)
            {
                if (!sucessoCommit)
                {
                    atorViewModel.ValidationResult.Errors.Add(new ValidationFailure("Commit", "Ocorreu um erro ao salvar as informações no banco de dados. Por favor, tente novamente"));
                }
            }

            return atorViewModel;
        }

        public async Task<AtorViewModel> ObterPorId(Guid id)
        {
            var ator = await _atorService.ObterPorId(id);
            return _atorServiceMapper.MapToAtorViewModel(ator);
        }

        public async Task<IEnumerable<AtorViewModel>> ObterTodos()
        {
            var atores = await _atorService.ObterTodos();
            return _atorServiceMapper.MapToListaAtorViewModel(atores);
        }
    }
}
