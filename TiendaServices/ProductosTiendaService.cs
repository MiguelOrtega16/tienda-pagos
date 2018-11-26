using Microsoft.EntityFrameworkCore;
using ProductsData;
using System;
using System.Collections.Generic;
using System.Linq;
using TiendaData;
using TiendaData.Models;

namespace TiendaServices
{
    public class ProductosTiendaService : IProductosTienda
    {
        private TiendaContext _context;

        public ProductosTiendaService(TiendaContext context)
        {
            _context = context;
        }

        public void Add(Productos nuevoProducto)
        {
            _context.Add(nuevoProducto);
            _context.SaveChanges();
        }

        public void RestarCantidadProducto(int id, int cantidadProducto)
        {

            var producto = GetById(id);

            _context.Update(producto);

            producto.CantidadProducto = producto.CantidadProducto - cantidadProducto;

            if (producto.CantidadProducto == 0)
            {
                ActualizarEstadoProducto(producto, "Agotado");
            }

            _context.SaveChanges();

        }

        public IEnumerable<Productos> GetAll()
        {
            return _context.Productos
                .Include( producto => producto.Estados)
                .Include( producto => producto.CategoriaProducto);
        }

        public Productos GetById(int id)
        {
            return _context.Productos
                 .Include(producto => producto.Estados)
                 .Include(producto => producto.CategoriaProducto)
                 .FirstOrDefault(producto => producto.Id == id);
        }

        public int GetCantidadProducto(int id)
        {
            return _context.Productos
                .Include( producto => producto.Estados)
                .Include(producto => producto.CategoriaProducto)
                .FirstOrDefault(producto => producto.Id == id)
                .CantidadProducto;
        }

        public decimal GetCapacidadProducto(int id)
        {
            return _context.Productos
                .Include(producto => producto.Estados)
                .FirstOrDefault(producto => producto.Id == id)
                .Capacidad;
        }

        public string GetDescripcionProducto(int id)
        {
            return GetAll()
                .FirstOrDefault(producto => producto.Id == id)
                .DescripcionProducto;
        }

        public string GetEstadoProducto(int id)
        {
            var idEstado = _context.Productos
                 .FirstOrDefault(producto => producto.Id == id)
                 .Estados.Id;

            return _context.Estados
                .FirstOrDefault(estados => estados.Id == idEstado)
                .Nombre;
        }

        public string GetNombreProducto(int id)
        {
            return _context.Productos
                .Include(producto => producto.Estados)
                .Include(producto => producto.CategoriaProducto)
                .FirstOrDefault(producto => producto.Id == id)
                .NombreProducto;
        }

        public double GetPrecioProducto(int id)
        {
            return _context.Productos
                .Include(producto => producto.Estados)
                .Include(producto => producto.CategoriaProducto)
                .FirstOrDefault(producto => producto.Id == id)
                .Costo;
        }



        private void ActualizarEstadoProducto(Productos producto, string nombreEstado)
        {
            _context.Update(producto);

            producto.Estados = _context.Estados
                .FirstOrDefault(ep => ep.Nombre == nombreEstado);

        }

        public IEnumerable<CategoriaProducto> GetCategorias()
        {
            return _context.CategoriaProducto;
        }
    }
}
