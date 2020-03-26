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
    }
}
