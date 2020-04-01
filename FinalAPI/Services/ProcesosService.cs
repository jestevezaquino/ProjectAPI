using Microsoft.EntityFrameworkCore;
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

        //Obtener los registros de la tabla entradas.
        public List<Entrada> ObtenerEntradas()
        {
            var resultado = apiDBContext.Entrada.Include(x => x.ProductoID).Include(x => x.ProveedorID).ToList();
            return resultado;
        }

        //Obtener los registros de entradas filtrando por producto
        public List<Entrada> ObtenerEntradasPorProducto(int prodID)
        {
            var resultado = apiDBContext.Entrada.Where(x => x.ProductoID == prodID).Include(x => x.ProductoID).Include(x => x.ProveedorID).ToList();
            return resultado;
        }

        //Obtener los registros de entradas filtrando por fecha
        public List<Entrada> ObtenerEntradasPorFecha(DateTime fecha)
        {
            var resultado = apiDBContext.Entrada.Where(x => x.Fecha == fecha).Include(x => x.ProductoID).Include(x => x.ProveedorID).ToList();
            return resultado;
        }

        //Obtener los registros de entradas filtrando por proveedor
        public List<Entrada> ObtenerEntradasPorProveedor(int provID)
        {
            var resultado = apiDBContext.Entrada.Where(x => x.ProveedorID == provID).Include(x => x.ProductoID).Include(x => x.ProveedorID).ToList(); ;
            return resultado;
        }

        //Obtener los registros de entradas filtrando por producto y proveedor
        public Entrada ObtenerEntradaProductoProveedor(int prodID, int provID)
        {
            var resultado = apiDBContext.Entrada.Where(x => x.ProductoID == prodID && x.ProveedorID == provID).Include(x => x.ProductoID).Include(x => x.ProveedorID).FirstOrDefault();

            if (resultado != null)
            {
                return resultado;
            }
            else
            {
                resultado = new Entrada
                {
                    EntradaID = -1,
                    ProductoID = -1,
                    Cantidad = 0,
                    ProveedorID = -1,
                    Fecha = DateTime.Parse("03-09-1999")
                };
                return resultado;
            }
        }

        //Agregar entrada
        public bool AgregarEntrada(Entrada entrada)
        {
            try
            {
                apiDBContext.Entrada.Add(entrada);
                apiDBContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //Editar entrada
        public bool EditarEntrada(Entrada entrada)
        {
            try
            {
                var entradaDB = apiDBContext.Entrada.Where(x => x.EntradaID == entrada.EntradaID).FirstOrDefault();
                entradaDB.ProductoID = entrada.ProductoID;
                entradaDB.Cantidad = entrada.Cantidad;
                entradaDB.ProveedorID = entrada.ProveedorID;
                entradaDB.Fecha = entrada.Fecha;
                apiDBContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //Eliminar entrada
        public bool EliminarEntrada(int stockID)
        {
            try
            {
                var entradaDB = apiDBContext.Entrada.Where(x => x.EntradaID == stockID).FirstOrDefault();
                apiDBContext.Entrada.Remove(entradaDB);
                apiDBContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //Obtener todas las facturas
        public List<Factura> ObtenerFacturas()
        {
            var resultado = apiDBContext.Factura.Include(x=>x.Cliente).ToList();
            return resultado;
        }

        //Obtener facturas por fecha
        public List<Factura> ObtenerFacturasPorFecha(DateTime fecha)
        {
            var resultado = apiDBContext.Factura.Where(x => x.Fecha == fecha).Include(x => x.Cliente).ToList();
            return resultado;
        }

        //Obtener facturas por cliente
        public List<Factura> ObtenerFacturasPorCliente(int clienteID)
        {
            var resultado = apiDBContext.Factura.Where(x => x.ClienteID == clienteID).Include(x => x.Cliente).ToList();
            return resultado;
        }

        //Agregar factura
        public bool AgregarFactura(Factura factura)
        {
            try
            {
                var resultado = apiDBContext.Factura.Add(factura);
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