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

        public IEnumerable<Productos> GetAll()
        {
            return _context.Productos
                .Include( producto => producto.Estados);
        }

        public Productos GetById(int id)
        {
            return _context.Productos
                 .Include(producto => producto.Estados)
                 .FirstOrDefault(producto => producto.Id == id);
        }

        public int GetCantidadProducto(int id)
        {
            return _context.Productos
                .Include( producto => producto.Estados)
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
                .FirstOrDefault(producto => producto.Id == id)
                .NombreProducto;
        }

        public double GetPrecioProducto(int id)
        {
            return _context.Productos
                .Include(producto => producto.Estados)
                .FirstOrDefault(producto => producto.Id == id)
                .Costo;
        }
    }
}
