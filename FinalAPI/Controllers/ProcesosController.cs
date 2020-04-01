using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalAPI.Models;
using FinalAPI.Services;

namespace FinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcesosController : ControllerBase
    {

        private readonly ProcesosService procesosService;

        public ProcesosController(ProcesosService _procesosService) 
        {
            procesosService = _procesosService;
        }

        [HttpGet]
        [Route("obtener_entradas")]
        public IActionResult ObtenerEntrada() 
        {
            var resultado = procesosService.ObtenerEntradas();
            return Ok(resultado);
        }

        [HttpGet]
        [Route("obtener_entradas_producto/{prodID}")]
        public IActionResult ObtenerEntradasPorProducto(int prodID)
        {
            var resultado = procesosService.ObtenerEntradasPorProducto(prodID);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("obtener_entradas_fecha/{fecha}")]
        public IActionResult ObtenerEntradasPorFecha(DateTime fecha)
        {
            var resultado = procesosService.ObtenerEntradasPorFecha(fecha);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("obtener_entradas_proveedor/{provID}")]
        public IActionResult ObtenerEntradasPorProveedor(int provID)
        {
            var resultado = procesosService.ObtenerEntradasPorProveedor(provID);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("obtener_entradas_producto_proveedor/{prodID}&&{provID}")]
        public IActionResult ObtenerEntradaProductoProveedor(int prodID, int provID) 
        {
            var resultado = procesosService.ObtenerEntradaProductoProveedor(prodID, provID);
            return Ok(resultado);
        }

        [HttpPost]
        [Route("agregar_entrada")]
        public IActionResult AgregarEntrada([FromBody] Entrada entrada)
        {
            var resultado = procesosService.AgregarEntrada(entrada);

            if (resultado) 
            {
                return Ok();
            }
            else 
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("editar_entrada")]
        public IActionResult EditarEntrada([FromBody] Entrada entrada) 
        {
            var resultado = procesosService.EditarEntrada(entrada);

            if (resultado) 
            {
                return Ok();
            }
            else 
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("eliminar_entrada/{id}")]
        public IActionResult EliminarEntrada(int id) 
        {
            var resultado = procesosService.EliminarEntrada(id);
            if (resultado) 
            {
                return Ok();
            }
            else 
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("obtener_facturas")]
        public IActionResult ObtenerFacturas() 
        {
            var resultado = procesosService.ObtenerFacturas();
            return Ok(resultado);
        }

        [HttpGet]
        [Route("obtener_facturas_fecha/{fecha}")]
        public IActionResult ObtenerFacturasPorFecha(DateTime fecha)
        {
            var resultado = procesosService.ObtenerFacturasPorFecha(fecha);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("obtener_facturas_cliente/{clienteID}")]
        public IActionResult ObtenerFacturasPorCliente(int clienteID)
        {
            var resultado = procesosService.ObtenerFacturasPorCliente(clienteID);
            return Ok(resultado);
        }

        [HttpPost]
        [Route("agregar_factura")]
        public IActionResult AgregarFactura([FromBody] Factura factura) 
        {
            var resultado = procesosService.AgregarFactura(factura);
            if (resultado) 
            {
                return Ok();
            }
            else 
            {
                return BadRequest();
            }
        }
    }
}