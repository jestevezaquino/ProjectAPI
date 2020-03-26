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
    }
}
