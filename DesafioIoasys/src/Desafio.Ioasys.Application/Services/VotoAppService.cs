using Desafio.Ioasys.Application.Interfaces.AppService;
using Desafio.Ioasys.Application.Interfaces.ServiceMapper;
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
    public class VotoAppService : ApplicationService, IVotoAppService
    {

        private readonly IVotoService _votoService;
        private readonly IVotoServiceMapper _votoServiceMapper;
        public VotoAppService(IVotoService votoService,
                              IVotoServiceMapper votoServiceMapper,
                              IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _votoService = votoService;
            _votoServiceMapper = votoServiceMapper;
        }

        public async Task<VotoViewModel> Adicionar(VotoViewModel votoViewModel)
        {
            var voto = new Voto(votoViewModel.IdVoto, votoViewModel.IdFilme,
                                   votoViewModel.IdUsuario, votoViewModel.Pontuacao,
                                   votoViewModel.Ativo);
            BeginTransaction();
            var votoServiceRetorno = await _votoService.Adicionar(voto);

            votoViewModel = _votoServiceMapper.MapToVotoViewModel(votoServiceRetorno);
            if (!votoServiceRetorno.ValidationResult.IsValid)
            {
                return votoViewModel;
            }

            var sucessoCommit = await Commit();
            if (!sucessoCommit)
            {
                if (!sucessoCommit)
                {
                    votoViewModel.ValidationResult.Errors.Add(new ValidationFailure("Commit", "Ocorreu um erro ao salvar as informações no banco de dados. Por favor, tente novamente"));
                }
            }

            return votoViewModel;
        }

        public Task<VotoViewModel> Atualizar(VotoViewModel voto)
        {
            throw new NotImplementedException();
        }

        public async Task<VotoViewModel> ObterPorId(Guid id)
        {
            var voto = await _votoService.ObterPorId(id);
            return _votoServiceMapper.MapToVotoViewModel(voto);
        }

        public async Task<IEnumerable<VotoViewModel>> ObterTodos()
        {
            var votos = await _votoService.ObterTodos();
            return _votoServiceMapper.MapToListaVotoViewModel(votos);
        }

        public IEnumerable<VotoViewModel> ObterVotosPorIdFilme(Guid id)
        {
            var votos =  _votoService.ObterVotosPorIdFilme(id);
            return _votoServiceMapper.MapToListaVotoViewModel(votos);
        }
    }
}
