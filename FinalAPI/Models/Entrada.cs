using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAPI.Models
{
    public class Entrada
    {
        public int EntradaID { get; set; }
        public int ProductoID { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public int ProveedorID { get; set; }
        public Proveedor Proveedor { get; set; }
        public DateTime Fecha { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Entrada> mapeoEntrada)
            {
                mapeoEntrada.HasKey(x => x.EntradaID);
                mapeoEntrada.Property(x => x.ProductoID).HasColumnName("ProductoID");
                mapeoEntrada.Property(x => x.Cantidad).HasColumnName("Cantidad");
                mapeoEntrada.Property(x => x.ProveedorID).HasColumnName("ProveedorID");
                mapeoEntrada.Property(x => x.Fecha).HasColumnName("Fecha");
                mapeoEntrada.ToTable("Entrada");
                mapeoEntrada.HasOne(x => x.Producto);
                mapeoEntrada.HasOne(x => x.Proveedor);
            }
        }
    }
}
