using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalAPI.Models;
using FinalAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoController : ControllerBase
    {
        private readonly MantenimientoService mantenimientoService;

        public MantenimientoController(MantenimientoService _mantenimientoService) 
        {
            mantenimientoService = _mantenimientoService;
        }

        [HttpGet]
        [Route("obtener_productos")]
        public IActionResult ObtenerProductos() 
        {
            var resultado = mantenimientoService.ObtenerProductos();
            return Ok(resultado);
        }

        [HttpPost]
        [Route("agregar_producto")]
        public IActionResult AgregarProducto([FromBody] Producto producto) 
        {
            var resultado = mantenimientoService.AgregarProducto(producto);
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