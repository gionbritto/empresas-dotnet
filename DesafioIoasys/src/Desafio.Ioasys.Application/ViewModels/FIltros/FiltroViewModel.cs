using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Ioasys.Application.ViewModels.FIltros
{
    public class FiltroViewModel : FiltroBaseViewModel
    {
        public FiltroViewModel() : base()
        {
            this.Limite = 5;
        }
        public string Filtro { get; set; }
        public override object Clone()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject(jsonString, this.GetType());
        }
    }
}
