using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HenriquedePaula.Models
{
    public class VendaItem
    {
        public int VendaId { get; set; }

        public int ProdutoId { get; set; }

        public double Quantidade { get; set; }

        public double ValorUnitario { get; set; }

        public Boolean Excluido { get; set; }

    }
}