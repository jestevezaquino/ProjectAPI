using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalAPI.Models;

namespace FinalAPI.Services
{
    public class ConsultasService
    {
        private readonly ApiDBContext apiDBContext;

        public ConsultasService(ApiDBContext _apiDBContext)
        {
            apiDBContext = _apiDBContext;
        }

        public Datos obtenerEstadisticas(string tabla, string campo, string busqueda) 
        {
            switch (tabla.ToLower())
            {
                case "clientes":
                    return ClienteStats(busqueda);
                    
                case "entrada":
                    return EntradaStats(campo, busqueda);

                case "facturaciones":
                    return FacturacionStats(campo, busqueda);

                default:
                    return new Datos
                    {
                        Conteo = -1,
                        Sumatoria = -1,
                        Promedio = -1,
                        Min = -1,
                        Max = -1
                    };
            }
        }

        public Datos ClienteStats(string busqueda) 
        {

            var query = from a in apiDBContext.Cliente
                        where a.Categoria == busqueda
                        select a;

            var stats = new Datos
            {
                Conteo = query.Count()
            };
            
            return stats;
        }

        public Datos EntradaStats(string campo, string busqueda) 
        {
            switch (campo.ToLower()) 
            {
                case "producto":
                    var query = from a in apiDBContext.Entrada
                                where a.Producto.Nombre == busqueda
                                select a;

                    var stats = new Datos
                    {
                        Conteo = query.Count(),
                        Sumatoria = query.Sum(a=>a.Cantidad),
                        Promedio = query.Average(a=>a.Cantidad),
                        Min = query.Min(a=>a.Cantidad),
                        Max = query.Max(a=>a.Cantidad)

                    };

                    return stats;

                case "fecha":
                    query = from a in apiDBContext.Entrada
                            where a.Fecha == DateTime.Parse(busqueda)
                            select a;

                    stats = new Datos
                    {
                        Conteo = query.Count(),
                        Sumatoria = query.Sum(a => a.Cantidad),
                        Promedio = query.Average(a => a.Cantidad),
                        Min = query.Min(a => a.Cantidad),
                        Max = query.Max(a => a.Cantidad)

                    };

                    return stats;

                case "proveedor":
                    query = from a in apiDBContext.Entrada
                            where a.Proveedor.Nombre == busqueda
                            select a;

                    stats = new Datos
                    {
                        Conteo = query.Count(),
                        Sumatoria = query.Sum(a => a.Cantidad),
                        Promedio = query.Average(a => a.Cantidad),
                        Min = query.Min(a => a.Cantidad),
                        Max = query.Max(a => a.Cantidad)
                    };

                    return stats;

                default:
                    stats = new Datos
                    {
                        Conteo = -1,
                        Sumatoria = -1,
                        Promedio = -1,
                        Min = -1,
                        Max = -1
                    };

                    return stats;
            }
        }

        public Datos FacturacionStats(string campo, string busqueda)
        {
            switch (campo.ToLower())
            {
                case "fecha":
                var query = from a in apiDBContext.Factura
                            where a.Fecha == DateTime.Parse(busqueda)
                            select a;
                    
                    var stats = new Datos
                    {
                        Conteo = query.Count(),
                        Sumatoria = query.Sum(a => a.Total),
                        Promedio = (double)query.Average(a => a.Total),
                        Min = query.Min(a => a.Total),
                        Max = query.Max(a => a.Total)

                    };

                    return stats;

                case "cliente":
                    query = from a in apiDBContext.Factura
                            where a.Cliente.Nombre == busqueda
                            select a;

                    stats = new Datos
                    {
                        Conteo = query.Count(),
                        Sumatoria = query.Sum(a => a.Total),
                        Promedio = (double)query.Average(a => a.Total),
                        Min = query.Min(a => a.Total),
                        Max = query.Max(a => a.Total)

                    };

                    return stats;

                default:
                    stats = new Datos
                    {
                        Conteo = -1,
                        Sumatoria = -1,
                        Promedio = -1,
                        Min = -1,
                        Max = -1
                    };

                    return stats;
            }
        }
    }
}
