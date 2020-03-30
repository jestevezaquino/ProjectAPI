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

        [HttpGet]
        [Route("obtener_producto/{id}")]
        public IActionResult ObtenerProductoPorId(int id)
        {
            var resultado = mantenimientoService.ObtenerProductoPorId(id);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("obtener_producto_nombre/{nombre}")]
        public IActionResult ObtenerProductoPorNombre(string nombre)
        {
            var resultado = mantenimientoService.ObtenerProductoPorNombre(nombre);
            return Ok(resultado);
        }

        [HttpPost]
        [Route("agregar_producto")]
        public IActionResult AgregarProducto ([FromBody] Producto producto)
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

        [HttpPut]
        [Route("editar_producto")]
        public IActionResult EditarProducto ([FromBody] Producto producto)
        {
            var resultado = mantenimientoService.EditarProducto(producto);
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
        [Route("eliminar_producto/{id}")]
        public IActionResult EliminarProducto(int id)
        {
            var resultado = mantenimientoService.EliminarProducto(id);
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
        [Route("obtener_proveedores")]
        public IActionResult ObtenerProveedores()
        {
            var resultado = mantenimientoService.ObtenerProveedores();
            return Ok(resultado);
        }

        [HttpGet]
        [Route("obtener_proveedor/{id}")]
        public IActionResult ObtenerProveedorPorId(int id)
        {
            var resultado = mantenimientoService.ObtenerProveedorPorId(id);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("obtener_proveedor_nombre/{nombre}")]
        public IActionResult ObtenerProveedorPorNombre(string nombre)
        {
            var resultado = mantenimientoService.ObtenerProveedorPorNombre(nombre);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("obtener_proveedor_email/{email}")]
        public IActionResult ObtenerProveedorPorEmail(string email)
        {
            var resultado = mantenimientoService.ObtenerProveedorPorEmail(email);
            return Ok(resultado);
        }

        [HttpPost]
        [Route("agregar_proveedor")]
        public IActionResult AgregarProveedor ([FromBody] Proveedor proveedor)
        {
            var resultado = mantenimientoService.AgregarProveedor(proveedor);
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
        [Route("editar_proveedor")]
        public IActionResult EditarProveedor ([FromBody] Proveedor proveedor)
        {
            var resultado = mantenimientoService.EditarProveedor(proveedor);
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
        [Route("eliminar_proveedor/{id}")]
        public IActionResult EliminarProveedor(int id)
        {
            var resultado = mantenimientoService.EliminarProveedor(id);
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
        [Route("obtener_clientes")]
        public IActionResult ObtenerClientes()
        {
            var resultado = mantenimientoService.ObtenerClientes();
            return Ok(resultado);
        }

        [HttpGet]
        [Route("obtener_cliente/{id}")]
        public IActionResult ObtenerClienterPorId(int id)
        {
            var resultado = mantenimientoService.ObtenerClientePorId(id);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("obtener_cliente_nombre/{nombre}")]
        public IActionResult ObtenerClientePorNombre(string nombre)
        {
            var resultado = mantenimientoService.ObtenerClientePorNombre(nombre);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("obtener_cliente_categoria/{categoria}")]
        public IActionResult ObtenerClientePorCategoria(string categoria)
        {
            var resultado = mantenimientoService.ObtenerClientePorCategoria(categoria);
            return Ok(resultado);
        }

        [HttpPost]
        [Route("agregar_cliente")]
        public IActionResult AgregarCliente ([FromBody] Cliente cliente)
        {
            var resultado = mantenimientoService.AgregarCliente(cliente);
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
        [Route("editar_cliente")]
        public IActionResult EditarCliente ([FromBody] Cliente cliente)
        {
            var resultado = mantenimientoService.EditarCliente(cliente);
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
        [Route("eliminar_cliente/{id}")]
        public IActionResult EliminarCliente (int id) 
        {
            var resultado = mantenimientoService.EliminarCliente(id);
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