using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalAPI.Models;

namespace FinalAPI.Services
{
    public class ProcesosService
    {

        private readonly ApiDBContext apiDBContext;

        public ProcesosService(ApiDBContext _apiDBContext) 
        {
            apiDBContext = _apiDBContext;
        }

        //Obtener los registros del stock
        public List<Stock> ObtenerEntradas() 
        {
            var resultado = apiDBContext.Stock.ToList();
            return resultado;
        }

        //Obtener los registros del stock filtrando por producto
        public List<Stock> ObtenerEntradasPorProducto(int prodID) 
        {
            var resultado = apiDBContext.Stock.Where(x => x.ProductoID == prodID).ToList();
            return resultado;
        }

        //Obtener los registros del stock filtrando por fecha
        public List<Stock> ObtenerEntradasPorFecha(DateTime fecha)
        {
            var resultado = apiDBContext.Stock.Where(x => x.Fecha == fecha).ToList();
            return resultado;
        }

        //Obtener los registros del stock filtrando por proveedor
        public List<Stock> ObtenerEntradasPorProveedor(int provID)
        {
            var resultado = apiDBContext.Stock.Where(x => x.ProveedorID == provID).ToList();
            return resultado;
        }

        //Obtener los registros del stock filtrando por producto y proveedor
        public Stock ObtenerEntradasProductoProveedor(int prodID, int provID)
        {
            var resultado = apiDBContext.Stock.Where(x=>x.ProductoID == prodID && x.ProveedorID == provID).FirstOrDefault();
            
            if (resultado != null) 
            {
                return resultado;
            }
            else 
            {
                resultado = new Stock
                {
                    StockID = -1,
                    ProductoID = -1,
                    Cantidad = 0,
                    ProveedorID = -1,
                    Fecha = DateTime.Parse("03-09-1999")
                };
                return resultado;
            }
        }

        //Agregar entrada al stock/inventario
        public bool AgregarEntrada(Stock stock) 
        {
            try 
            {
                apiDBContext.Stock.Add(stock);
                apiDBContext.SaveChanges();
                return true;
            }
            catch(Exception e) 
            {
                return false;
            }
        }

        //Editar entrada al stock/inventario
        public bool EditarEntrada(Stock stock) 
        {
            try 
            {
                var entradaDB = apiDBContext.Stock.Where(x => x.StockID == stock.StockID).FirstOrDefault();
                entradaDB.ProductoID = stock.ProductoID;
                entradaDB.Cantidad = stock.Cantidad;
                entradaDB.ProveedorID = stock.ProveedorID;
                entradaDB.Fecha = stock.Fecha;
                apiDBContext.SaveChanges();
                return true;
            }
            catch (Exception e) 
            {
                return false;
            }
        }

        //Eliminar entrada (Cuando la cantidad de un producto en el stock llegue a 0)
        public bool EliminarEntrada(int stockID) 
        {
            try 
            {
                var entradaDB = apiDBContext.Stock.Where(x => x.StockID == stockID).FirstOrDefault();
                apiDBContext.Stock.Remove(entradaDB);
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