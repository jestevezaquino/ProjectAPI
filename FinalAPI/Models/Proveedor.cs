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
        public string  Telefono { get; set; }
        public string Email { get; set; }
    }
}
