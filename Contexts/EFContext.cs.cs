using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HenriquedePaula.Models;

namespace HenriquedePaula.Contexts
{
    public class EFContext : DbContext
    {

        public EFContext() : base("Asp_Net_MVC_CS") {
            Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Produto> Produtos { get; set; }        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaItem> VendasItens { get; set; }

    }
}