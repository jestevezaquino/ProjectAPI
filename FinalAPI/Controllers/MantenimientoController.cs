using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [Route("obtener_productos")]
        public IActionResult ObtenerProductos() 
        {
            var resultado = mantenimientoService.ObtenerProductos();
            return Ok(resultado);
        }
    }
}