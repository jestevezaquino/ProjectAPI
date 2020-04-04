using FinalAPI.Models;
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
                var busquedaEnEntrada = apiDBContext.Entrada.Where(x => x.ProductoID == resultado.ProductoID).ToList();
                var busquedaEnStock = apiDBContext.Stock.Where(x => x.ProductoID == resultado.ProductoID).FirstOrDefault();

                if (busquedaEnEntrada.Count > 0) 
                {

                    foreach(Entrada entrada in busquedaEnEntrada)
                    {
                        apiDBContext.Entrada.Remove(entrada);
                    }      
                }

                if (busquedaEnStock != null)
                {
                    apiDBContext.Stock.Remove(busquedaEnStock);
                }

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

        //Obten un unico proveedor pasando por parametro un id
        public Proveedor ObtenerProveedorPorId(int id)
        {
            var resultado = apiDBContext.Proveedor.Where(busqueda => busqueda.ProveedorID == id).FirstOrDefault();

            if (resultado != null)
            {
                return resultado;
            }
            else
            {
                resultado = new Proveedor
                {
                    ProveedorID = -1,
                    Cedula = "NOT FOUND",
                    Nombre = "NOT FOUND",
                    Telefono = "NOT FOUND",
                    Email = "NOT FOUND"
                };
                return resultado;
            }
        }

        //Obten un unico proveedor pasando por parametro su cedula
        public Proveedor ObtenerProveedorPorCedula(string cedula)
        {
            var resultado = apiDBContext.Proveedor.Where(busqueda => busqueda.Cedula == cedula).FirstOrDefault();

            if (resultado != null)
            {
                return resultado;
            }
            else
            {
                resultado = new Proveedor
                {
                    ProveedorID = -1,
                    Cedula = "NOT FOUND",
                    Nombre = "NOT FOUND",
                    Telefono = "NOT FOUND",
                    Email = "NOT FOUND"
                };
                return resultado;
            }
        }

        //Busqueda de proveedor por nombre
        public Proveedor ObtenerProveedorPorNombre(string nombre)
        {
            var resultado = apiDBContext.Proveedor.Where(x => x.Nombre == nombre).FirstOrDefault();

            if (resultado != null)
            {
                return resultado;
            }
            else
            {
                resultado = new Proveedor
                {
                    ProveedorID = -1,
                    Cedula = "NOT FOUND",
                    Nombre = "NOT FOUND",
                    Telefono = "NOT FOUND",
                    Email = "NOT FOUND"
                };
                return resultado;
            }
        }

        //Busqueda de proveedor por Email
        public Proveedor ObtenerProveedorPorEmail(string email)
        {
            var resultado = apiDBContext.Proveedor.Where(x => x.Email == email).FirstOrDefault();

            if (resultado != null)
            {
                return resultado;
            }
            else
            {
                resultado = new Proveedor
                {
                    ProveedorID = -1,
                    Cedula = "NOT FOUND",
                    Nombre = "NOT FOUND",
                    Telefono = "NOT FOUND",
                    Email = "NOT FOUND"
                };
                return resultado;
            }
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
                List<int> productoProveedor = new List<int>();
                List<int> cantidadProductos = new List<int>();
                List<Stock> proveedoresEnStock = new List<Stock>();
                var campoProveedoresStock = new List<string>();

                var resultado = apiDBContext.Proveedor.Where(x => x.ProveedorID == id).FirstOrDefault();
                var busquedaEnEntrada = apiDBContext.Entrada.Where(x => x.ProveedorID == resultado.ProveedorID).ToList();

                if (busquedaEnEntrada.Count > 0)
                { 
                    foreach (Entrada entrada in busquedaEnEntrada)
                    {
                        productoProveedor.Add(entrada.ProductoID);
                        cantidadProductos.Add(entrada.Cantidad);
                        apiDBContext.Entrada.Remove(entrada);
                    }
                }

                foreach (int i in productoProveedor)
                {
                    if(apiDBContext.Stock.Where(x => x.ProductoID == i).FirstOrDefault() != null)
                    {
                        proveedoresEnStock.Add(apiDBContext.Stock.Where(x => x.ProductoID == i).FirstOrDefault());
                    }
                }

                int contador = 0;

                if (proveedoresEnStock.Count > 0) 
                {
                    foreach (Stock ps in proveedoresEnStock)
                    {
                        if (ps.Proveedores == resultado.Nombre)
                        {
                            apiDBContext.Stock.Remove(ps);
                        }
                        else if (ps.Proveedores.StartsWith(resultado.Nombre))
                        {
                            int final = ps.Proveedores.IndexOf(resultado.Nombre);
                            ps.Proveedores = ps.Proveedores.Substring(resultado.Nombre.Length + 2);
                            ps.Cantidad -= cantidadProductos.ElementAt(contador);

                            if (ps.Cantidad <= 0)
                            {
                                apiDBContext.Stock.Remove(ps);
                            }
                        }
                        else if (ps.Proveedores.EndsWith(resultado.Nombre))
                        {
                            int final = ps.Proveedores.IndexOf(resultado.Nombre);
                            ps.Proveedores = ps.Proveedores.Substring(0, final - 2);
                            ps.Cantidad -= cantidadProductos.ElementAt(contador);

                            if (ps.Cantidad <= 0)
                            {
                                apiDBContext.Stock.Remove(ps);
                            }
                        }
                        else
                        {
                            int largoDelString = resultado.Nombre.Length;
                            int inicio = ps.Proveedores.IndexOf(resultado.Nombre);
                            string parte1 = ps.Proveedores.Substring(0, inicio - 2);
                            string parte2 = ps.Proveedores.Substring(inicio + largoDelString + 2);
                            ps.Proveedores = parte1 + ", " + parte2;
                            ps.Cantidad -= cantidadProductos.ElementAt(contador);

                            if (ps.Cantidad <= 0)
                            {
                                apiDBContext.Stock.Remove(ps);
                            }
                        }
                        contador++;
                    }
                }
                
                apiDBContext.Proveedor.Remove(resultado);
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

        //Obten un unico cliente pasando por parametro un id
        public Cliente ObtenerClientePorId(int id)
        {
            var resultado = apiDBContext.Cliente.Where(busqueda => busqueda.ClienteID == id).FirstOrDefault();

            if (resultado != null)
            {
                return resultado;
            }
            else
            {
                resultado = new Cliente
                {
                    ClienteID = -1,
                    Cedula = "NOT FOUND",
                    Nombre = "NOT FOUND",
                    Telefono = "NOT FOUND",
                    Email = "NOT FOUND",
                    Categoria = "NOT FOUND"
                };
                return resultado;
            }
        }

        //Obten un unico cliente pasando por parametro su cedula
        public Cliente ObtenerClientePorCedula(string cedula)
        {
            var resultado = apiDBContext.Cliente.Where(busqueda => busqueda.Cedula == cedula).FirstOrDefault();

            if (resultado != null)
            {
                return resultado;
            }
            else
            {
                resultado = new Cliente
                {
                    ClienteID = -1,
                    Cedula = "NOT FOUND",
                    Nombre = "NOT FOUND",
                    Telefono = "NOT FOUND",
                    Email = "NOT FOUND",
                    Categoria = "NOT FOUND"
                };
                return resultado;
            }
        }

        //Busqueda de cliente por nombre
        public Cliente ObtenerClientePorNombre(string nombre)
        {
            var resultado = apiDBContext.Cliente.Where(x => x.Nombre == nombre).FirstOrDefault();

            if (resultado != null)
            {
                return resultado;
            }
            else
            {
                resultado = new Cliente
                {
                    ClienteID = -1,
                    Cedula = "NOT FOUND",
                    Nombre = "NOT FOUND",
                    Telefono = "NOT FOUND",
                    Email = "NOT FOUND",
                    Categoria = "NOT FOUND"
                };
                return resultado;
            }
        }

        //Busqueda de cliente por categoria
        public List<Cliente> ObtenerClientesPorCategoria(string categoria)
        {
            var resultado = apiDBContext.Cliente.Where(x => x.Categoria == categoria).ToList();
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
