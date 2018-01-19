using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAppRestaurante.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebAppRestaurante.DAL
{
    public class RestauranteContext : DbContext
    {
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Prato> Pratos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Restaurante>().MapToStoredProcedures();

            modelBuilder.Entity<Prato>().Property(p => p.Preco);
        }
    }
}