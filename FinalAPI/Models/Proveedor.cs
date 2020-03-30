using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAPI.Models
{
    public class Proveedor
    {
        public int ProveedorID { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Proveedor> mapeoProveedor)
            {
                mapeoProveedor.HasKey(x => x.ProveedorID);
                mapeoProveedor.Property(x => x.Cedula).HasColumnName("Cedula");
                mapeoProveedor.Property(x => x.Nombre).HasColumnName("Nombre");
                mapeoProveedor.Property(x => x.Telefono).HasColumnName("Telefono");
                mapeoProveedor.Property(x => x.Email).HasColumnName("Email");
                mapeoProveedor.ToTable("Proveedores");
            }
        }
    }
}
