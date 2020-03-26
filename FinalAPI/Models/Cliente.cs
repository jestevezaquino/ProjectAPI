using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAPI.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Categoria { get; set; }

        public class Mapeo 
        {
            public Mapeo(EntityTypeBuilder<Cliente> mapeoCliente) 
            {
                mapeoCliente.HasKey(x => x.ClienteID);
                mapeoCliente.Property(x => x.Cedula).HasColumnName("Cedula");
                mapeoCliente.Property(x => x.Nombre).HasColumnName("Nombre");
                mapeoCliente.Property(x => x.Telefono).HasColumnName("Telefono");
                mapeoCliente.Property(x => x.Email).HasColumnName("Email");
                mapeoCliente.Property(x => x.Categoria).HasColumnName("Categoria");
                mapeoCliente.ToTable("Clientes");
            }
        }
    }
}
