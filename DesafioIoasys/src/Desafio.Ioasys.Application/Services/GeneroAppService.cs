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
    public class GeneroAppService : ApplicationService, IGeneroAppService
    {
        private readonly IGeneroService _generoService;
        private readonly IGeneroServiceMapper _generoServiceMapper;        

        public GeneroAppService(IGeneroService generoService,
                              IGeneroServiceMapper generoServiceMapper,
                              IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _generoService = generoService;
            _generoServiceMapper = generoServiceMapper;
        }

        public async Task<GeneroViewModel> Adicionar(GeneroViewModel generoViewModel)
        {
            var genero = new Genero(generoViewModel.IdGenero, generoViewModel.Nome, generoViewModel.Ativo,
                                generoViewModel.IdCriadoPor, generoViewModel.IdCriadoPor, generoViewModel.IdExcluidoPor);
            BeginTransaction();
            var generoServiceRetorno = await _generoService.Adicionar(genero);

            generoViewModel = _generoServiceMapper.MapToGeneroViewModel(generoServiceRetorno);
            if (!generoViewModel.ValidationResult.IsValid)
            {
                return generoViewModel;
            }

            var sucessoCommit = await Commit();
            if (!sucessoCommit)
            {
                if (!sucessoCommit)
                {
                    generoViewModel.ValidationResult.Errors.Add(new ValidationFailure("Commit", "Ocorreu um erro ao salvar as informações no banco de dados. Por favor, tente novamente"));
                }
            }

            return generoViewModel;
        }

        public async Task<GeneroViewModel> ObterPorId(Guid id)
        {
            var genero = await _generoService.ObterPorId(id);
            return _generoServiceMapper.MapToGeneroViewModel(genero);
        }

        public async Task<IEnumerable<GeneroViewModel>> ObterTodos()
        {
            var generos = await _generoService.ObterTodos();
            return _generoServiceMapper.MapToListaGeneroViewModel(generos);
        }
    }
}
