using FinalAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAPI
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions options)  : base (options)
        {

        }

        public DbSet<Producto> Producto { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Factura> Factura { get; set; }

        protected override void OnModelCreating(ModelBuilder modeloCreador) 
        {
            new Producto.Mapeo(modeloCreador.Entity<Producto>());
            new Proveedor.Mapeo(modeloCreador.Entity<Proveedor>());
            new Cliente.Mapeo(modeloCreador.Entity<Cliente>());
            new Stock.Mapeo(modeloCreador.Entity<Stock>());
            new Factura.Mapeo(modeloCreador.Entity<Factura>());
        }
    }
}
