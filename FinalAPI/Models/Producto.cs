using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAPI.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Producto> mapeoProducto)
            {
                mapeoProducto.HasKey(x => x.ProductoID);
                mapeoProducto.Property(x => x.Nombre).HasColumnName("Nombre");
                mapeoProducto.Property(x => x.Precio).HasColumnName("Precio");
                mapeoProducto.ToTable("Productos");
            }
        }
    }
}
