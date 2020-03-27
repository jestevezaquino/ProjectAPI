using FinalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAPI.Services
{
    public class MantenimientoService
    {
        private readonly ApiDBContext apiDBContext;
        public MantenimientoService(ApiDBContext _apiDBContext) 
        {
            apiDBContext = _apiDBContext;
        }

        public List<Producto> ObtenerProductos() 
        {
            var resultado = apiDBContext.Producto.ToList();
            return resultado;
        }

        public bool AgregarProducto(Producto producto) 
        {
            try
            {
                apiDBContext.Add(producto);
                apiDBContext.SaveChanges();
                return true;
            }
            catch (Exception e) 
            {
                return false;                
            }
        }
    }
}
