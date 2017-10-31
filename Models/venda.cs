using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HenriquedePaula.Models
{
    public class Venda
    {
        public int Codigo { get; set; }
        [Display(Name = "Data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? Data { get; set; }

        public string CompradorNome { get; set; }

        public string CompradorCPF { get; set; }

        public string Fone { get; set; }

        public int SerieNF { get; set; }

        public int NumeroNF { get; set; }

    }
}