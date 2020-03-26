using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAPI.Models
{
    public class Stock
    {
        public int StockID { get; set; }
        public int ProductoID { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public int ProveedorID { get; set; }
        public Proveedor Proveedor { get; set; }
        public DateTime Fecha { get; set; }

        public class Mapeo 
        {
            public Mapeo(EntityTypeBuilder<Stock> mapeoStock) 
            {
                mapeoStock.HasKey(x => x.StockID);
                mapeoStock.Property(x => x.ProductoID).HasColumnName("ProductoID");
                mapeoStock.Property(x => x.Cantidad).HasColumnName("Cantidad");
                mapeoStock.Property(x => x.ProveedorID).HasColumnName("ProveedorID");
                mapeoStock.Property(x => x.Fecha).HasColumnName("Fecha");
                mapeoStock.ToTable("Stock");
                mapeoStock.HasOne(x=>x.Producto);
                mapeoStock.HasOne(x => x.Proveedor);
            }
        }
    }
}
