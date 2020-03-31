using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuiaController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { 
                "Los modulos de esta API estan listados debajo:", 
                "1 - mantenimiento", 
                "2 - procesos",
                "Para la guia de un modulo, dirijase: /api/guia/mantenimiento o /api/guia/procesos"
            };
        }

        [HttpGet]
        [Route("mantenimiento")]
        public string[] GuiaMantenimiento()
        {
            return new string[] {
                "Las distintas opciones en este modulo son: ",
                "1 - Obtener listado de productos (GET): /api/mantenimiento/obtener_productos",
                "2 - Obtener un producto mediante id (GET): /api/mantenimiento/obtener_producto/{id}",
                "3 - Obtener un producto mediante su nombre (GET): /api/mantenimiento/obtener_producto_nombre/{nombre}",
                "4 - Agregar un producto (POST): /api/mantenimiento/agregar_producto",
                "5 - Editar un producto (PUT): /api/mantenimiento/editar_producto",
                "6 - Eliminar un producto (DELETE): /api/mantenimiento/eliminar_producto/{id}",
                "7 - Obtener listado de proveedores (GET): /api/mantenimiento/obtener_proveedores",
                "8 - Obtener un proveedor mediante id (GET): /api/mantenimiento/obtener_proveedor/{id}",
                "9 - Obtener un proveedor mediante su nombre (GET): /api/mantenimiento/obtener_proveedor_nombre/{nombre}",
                "10 - Obtener un proveedor mediante su email (GET): /api/mantenimiento/obtener_proveedor_email/{email}",
                "11 - Agregar un proveedor (POST): /api/mantenimiento/agregar_proveedor",
                "12 - Editar un proveedor (PUT): /api/mantenimiento/editar_proveedor",
                "13 - Eliminar un proveedor (DELETE): /api/mantenimiento/eliminar_proveedor/{id}",
                "14 - Obtener clientes (GET): /api/mantenimiento/obtener_clientes",
                "15 - Obtener un cliente mediante id (GET): /api/mantenimiento/obtener_cliente/{id}",
                "16 - Obtener un cliente mediante su nombre (GET): /api/mantenimiento/obtener_cliente_nombre/{nombre}",
                "17 - Obtener listado de clientes por categoria (GET): /api/mantenimiento/obtener_clientes_categoria/{categoria}",
                "18 - Agregar un cliente (POST): /api/mantenimiento/agregar_cliente",
                "19 - Editar un cliente (PUT): /api/mantenimiento/editar_cliente",
                "20 - Eliminar un cliente (DELETE): /api/mantenimiento/eliminar_cliente/{id}",
            };
        }

        [HttpGet]
        [Route("procesos")]
        public string[] GuiaProcesos()
        {
            return new string[]
            {
                "Las distintas opciones en este modulo son: ",
                "1 - Obtener listado de entradas(stock) (GET): /api/procesos/obtener_entradas",
                "2 - Obtener listado de entradas(stock) por producto (GET): /api/procesos/obtener_entradas_producto/{prodID}",
                "3 - Obtener listado de entradas(stock) por fecha (GET): /api/procesos/obtener_entradas_fecha/{fecha}",
                "4 - Obtener listado de entradas(stock) por proveedor (GET): /api/procesos/obtener_entradas_proveedor/{provID}",
                "5 - Obtener listado de entradas(stock) por producto y proveedor (GET): /api/procesos/obtener_entradas_producto_proveedor/{prodID}&&{provID}",
                "6 - Agregar una entrada(stock) (POST): /api/procesos/agregar_entrada",
                "7 - Editar una entrada(stock) (PUT): /api/procesos/editar_entrada",
                "6 - Eliminar una entrada(stock) (DELETE): /api/procesos/eliminar_entrada/{id}",
                "8 - Obtener listado de facturas (GET): /api/procesos/obtener_facturas",
                "9 - Obtener listado de facturas por fecha (GET): /api/procesos/obtener_facturas_fecha/{fecha}",
                "10 - Obtener listado de facturas por clientes (GET): /api/procesos/obtener_facturas_cliente/{clienteID}",
                "11 - Agregar una factura (POST): /api/procesos/agregar_factura",
            };
        }
    }
}
