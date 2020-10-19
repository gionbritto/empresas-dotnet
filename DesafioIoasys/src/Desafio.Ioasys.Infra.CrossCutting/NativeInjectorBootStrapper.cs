using System;
using Desafio.Ioasys.Application.Interfaces.AppService;
using Desafio.Ioasys.Application.Interfaces.ServiceMapper;
using Desafio.Ioasys.Application.Interfaces.Services;
using Desafio.Ioasys.Application.ServiceMapper;
using Desafio.Ioasys.Application.Services;
using Desafio.Ioasys.Domain.Interfaces.Repository;
using Desafio.Ioasys.Domain.Interfaces.Services;
using Desafio.Ioasys.Domain.Services;
using Desafio.Ioasys.Infra.Data.Context;
using Desafio.Ioasys.Infra.Data.Interfaces;
using Desafio.Ioasys.Infra.Data.Repository;
using Desafio.Ioasys.Infra.Data.Uow;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Ioasys.Infra.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void RegistrarServices(IServiceCollection services)
        {

            #region Application
            services.AddScoped<IAtorServiceMapper, AtorServiceMapper>();
            services.AddScoped<IDiretorServiceMapper, DiretorServiceMapper>();
            services.AddScoped<IGeneroServiceMapper, GeneroServiceMapper>();
            services.AddScoped<IFilmeServiceMapper, FilmeServiceMapper>();
            services.AddScoped<IVotoServiceMapper, VotoServiceMapper>();

            services.AddScoped<IAtorAppService, AtorAppService>();
            services.AddScoped<IDiretorAppService, DiretorAppService>();
            services.AddScoped<IGeneroAppService, GeneroAppService>();
            services.AddScoped<IFilmeAppService, FilmeAppService>();
            services.AddScoped<IVotoAppService, VotoAppService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            #endregion Application

            #region Domain
            services.AddScoped<IAtorService, AtorService>();
            services.AddScoped<IDiretorService, DiretorService>();
            services.AddScoped<IGeneroService, GeneroService>();
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<IVotoService, VotoService>();
            #endregion Domain

            #region Infra
            services.AddScoped<DesafioIOContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAtorRepository, AtorRepository>();
            services.AddScoped<IDiretorRepository, DiretorRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IVotoRepository, VotoRepository>();
            #endregion Infra
        }
    }
}
