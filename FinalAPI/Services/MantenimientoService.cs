﻿using FinalAPI.Models;
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

        //Obten una lista de todos los productos
        public List<Producto> ObtenerProductos() 
        {
            var resultado = apiDBContext.Producto.ToList();
            return resultado;
        }

        //Obten un unico producto pasando por parametro un id
        public Producto ObtenerProductoPorId(int id) 
        {
            var resultado = apiDBContext.Producto.Where(busqueda => busqueda.ProductoID == id).FirstOrDefault();
            
            if (resultado != null)
            {
                return resultado;
            }
            else
            {
                resultado = new Producto
                {
                    ProductoID = -1,
                    Nombre = "NOT FOUND",
                    Precio = 0
                };
                return resultado;
            }
        }

        //Busqueda de producto por nombre
        public Producto ObtenerProductoPorNombre(string nombre)
        {
            var resultado = apiDBContext.Producto.Where(x => x.Nombre == nombre).FirstOrDefault();
            
            if (resultado != null) 
            {
                return resultado;
            }
            else 
            {
                resultado = new Producto
                {
                    ProductoID = -1,
                    Nombre = "NOT FOUND",
                    Precio = 0
                };
                return resultado;
            }
        }

        //Agregar un producto a la BD
        public bool AgregarProducto(Producto producto) 
        {
            try
            {
                apiDBContext.Producto.Add(producto);
                apiDBContext.SaveChanges();
                return true;
            }
            catch (Exception e) 
            {
                return false;                
            }
        }

        //Editar un producto en BD
        public bool EditarProducto(Producto producto)
        {
            try 
            {
                var productoBD = apiDBContext.Producto.Where(busqueda => busqueda.ProductoID == producto.ProductoID).FirstOrDefault();
                productoBD.Nombre = producto.Nombre;
                productoBD.Precio = producto.Precio;
                apiDBContext.SaveChanges();

                return true;
            }
            catch (Exception e) 
            {
                return false;
            }
        }

        //Elimina un producto de la BD
        public bool EliminarProducto(int id) 
        {
            try
            {
                var resultado = apiDBContext.Producto.Where(x => x.ProductoID == id).FirstOrDefault();
                apiDBContext.Producto.Remove(resultado);
                apiDBContext.SaveChanges();
                
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        //Select de todos los proveedores
        public List<Proveedor> ObtenerProveedores() 
        {
            var resultado = apiDBContext.Proveedor.ToList();
            return resultado;
        }

        //Agregar un proveedor
        public bool AgregarProveedor(Proveedor proveedor) 
        {
            try
            {
                apiDBContext.Proveedor.Add(proveedor);
                apiDBContext.SaveChanges();
                return true;
            }
            catch (Exception e) 
            {
                return false;
            }
        }
        
        //Editar un proveedor
        public bool EditarProveedor(Proveedor proveedor) 
        {
            try 
            {
                var proveedorBD = apiDBContext.Proveedor.Where(x => x.ProveedorID == proveedor.ProveedorID).FirstOrDefault();
                proveedorBD.Cedula = proveedor.Cedula;
                proveedorBD.Nombre = proveedor.Nombre;
                proveedorBD.Telefono = proveedor.Telefono;
                proveedorBD.Email = proveedor.Email;
                apiDBContext.SaveChanges();

                return true;
            }
            catch (Exception e) 
            {
                return false;                
            }
        }

        //Eliminar un proveedor
        public bool EliminarProveedor(int id) 
        {
            try
            {
                var proveedorBD = apiDBContext.Proveedor.Where(x => x.ProveedorID == id).FirstOrDefault();
                apiDBContext.Proveedor.Remove(proveedorBD);
                apiDBContext.SaveChanges();

                return true;
            }
            catch (Exception e) 
            {
                return false;                
            }
        }

        //Select de Clientes
        public List<Cliente> ObtenerClientes() 
        {
            var resultado = apiDBContext.Cliente.ToList();
            return resultado;
        }

        //Agregar un cliente
        public bool AgregarCliente(Cliente cliente) 
        {
            try 
            {
                apiDBContext.Cliente.Add(cliente);
                apiDBContext.SaveChanges();
                return true;
            } 
            catch (Exception e) 
            {
                return false;
            }    
        }

        //Editar Cliente
        public bool EditarCliente(Cliente cliente) 
        {
            try
            {
                var clienteBD = apiDBContext.Cliente.Where(x => x.ClienteID == cliente.ClienteID).FirstOrDefault();
                clienteBD.Cedula = cliente.Cedula;
                clienteBD.Nombre = cliente.Nombre;
                clienteBD.Telefono = cliente.Telefono;
                clienteBD.Email = cliente.Email;
                clienteBD.Categoria = cliente.Categoria;
                apiDBContext.SaveChanges();
                
                return true;
            }
            catch (Exception e) 
            {
                return false;
            }
        }

        //Eliminar Cliente
        public bool EliminarCliente(int id) 
        {
            try 
            {
                var clienteBD = apiDBContext.Cliente.Where(x => x.ClienteID == id).FirstOrDefault();
                apiDBContext.Cliente.Remove(clienteBD);
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
