﻿using Desafio.Ioasys.Domain.Entities.Filmes;
using Desafio.Ioasys.Domain.Interfaces.Repository;
using Desafio.Ioasys.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Infra.Data.Repository
{
    public class DiretorRepository : Repository<Diretor>, IDiretorRepository
    {
        public DiretorRepository(DesafioIOContext context) : base(context)
        {
        }
    }
}
