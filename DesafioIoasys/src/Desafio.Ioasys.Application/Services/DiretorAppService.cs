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
    public class DiretorAppService : ApplicationService, IDiretorAppService
    {
        private readonly IDiretorService _diretorService;
        private readonly IDiretorServiceMapper _diretorServiceMapper;        

        public DiretorAppService(IDiretorService diretorService,
                              IDiretorServiceMapper diretorServiceMapper,
                              IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _diretorService = diretorService;
            _diretorServiceMapper = diretorServiceMapper;
        }

        public async Task<DiretorViewModel> Adicionar(DiretorViewModel diretorViewModel)
        {
            var diretor = new Diretor(diretorViewModel.IdDiretor, diretorViewModel.Nome, diretorViewModel.Ativo,
                                diretorViewModel.IdCriadoPor, diretorViewModel.IdCriadoPor, diretorViewModel.IdExcluidoPor);
            BeginTransaction();
            var diretorServiceRetorno = await _diretorService.Adicionar(diretor);

            diretorViewModel = _diretorServiceMapper.MapToDiretorViewModel(diretorServiceRetorno);
            if (!diretorViewModel.ValidationResult.IsValid)
            {
                return diretorViewModel;
            }

            var sucessoCommit = await Commit();
            if (!sucessoCommit)
            {
                if (!sucessoCommit)
                {
                    diretorViewModel.ValidationResult.Errors.Add(new ValidationFailure("Commit", "Ocorreu um erro ao salvar as informações no banco de dados. Por favor, tente novamente"));
                }
            }

            return diretorViewModel;
        }

        public async Task<DiretorViewModel> ObterPorId(Guid id)
        {
            var diretor = await _diretorService.ObterPorId(id);
            return _diretorServiceMapper.MapToDiretorViewModel(diretor);
        }

        public async Task<IEnumerable<DiretorViewModel>> ObterTodos()
        {
            var diretores = await _diretorService.ObterTodos();
            return _diretorServiceMapper.MapToListaDiretorViewModel(diretores);
        }
    }
}
