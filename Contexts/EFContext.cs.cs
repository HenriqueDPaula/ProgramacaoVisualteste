using HenriquedePaula.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace HenriquedePaula.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("OracleDbContext")
        {

            Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("UPPERCASE_SCHEMA_NAME");
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("SYSTEM");
            // retira o pluralização das tabelas
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            modelBuilder
                .Properties()
                .Where(p => p.PropertyType == typeof(string) &&
                p.GetCustomAttributes(typeof(MaxLengthAttribute), false).Length == 0)
                .Configure(p => p.HasMaxLength(2000));
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
