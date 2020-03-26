using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAPI.Models
{
    public class Factura
    {
        public int FacturaID { get; set; }
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }
        public int CantidadProductos { get; set; }
        public decimal SubTotal { get; set; }
        public int DescuentoPorciento { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Factura> mapeoFactura) 
            {
                mapeoFactura.HasKey(x => x.FacturaID);
                mapeoFactura.Property(x => x.ClienteID).HasColumnName("ClienteID");
                mapeoFactura.Property(x => x.CantidadProductos).HasColumnName("CantidadProductos");
                mapeoFactura.Property(x => x.SubTotal).HasColumnName("SubTotal");
                mapeoFactura.Property(x => x.DescuentoPorciento).HasColumnName("DescuentoPorciento");
                mapeoFactura.Property(x => x.Total).HasColumnName("Total");
                mapeoFactura.Property(x => x.Fecha).HasColumnName("Fecha");
                mapeoFactura.ToTable("Facturacion");
                mapeoFactura.HasOne(x => x.Cliente);
            }
        }
    }
}
