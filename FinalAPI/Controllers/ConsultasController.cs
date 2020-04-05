using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalAPI.Services;

namespace FinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly ConsultasService consultasService;

        public ConsultasController(ConsultasService _consultasService) 
        {
            consultasService = _consultasService;
        }

        [Route("obtener_stats/{tabla}/{campo}/{busqueda}")]
        public IActionResult obtenerEstadisticas(string tabla, string campo, string busqueda) 
        {
            var resultado = consultasService.obtenerEstadisticas(tabla, campo, busqueda);
            return Ok(resultado);
        }
    }
}