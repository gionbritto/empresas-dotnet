using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Desafio.Ioasys.Application.ViewModels
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            ValidationResult = new FluentValidation.Results.ValidationResult();
        }

        [JsonIgnore]
        public FluentValidation.Results.ValidationResult ValidationResult { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data de Modificação")]
        public DateTime DataModificacao { get; set; }

        public DateTime? DataExclusao { get; set; }

        public bool Ativo { get; set; }

        public string IdCriadoPor { get; set; }

        public string IdAtualizadoPor { get; set; }

        public string IdExcluidoPor { get; set; }
    }
}
